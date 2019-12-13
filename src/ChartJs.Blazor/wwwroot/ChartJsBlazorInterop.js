/* Set up all the chartjs interop stuff */
/// <reference path="types/Chart.min.d.ts" />   
class ChartJsInterop {
    constructor() {
        this.BlazorCharts = new Map();
        /**
         * Given an IClickHandler (see the C# code), it tries to recover the referenced handler.
         * It currently supports Javascript functions, which are expected to be attached to the window object; .Net static functions and .Net object instance methods
         *
         * Failing to recover any handler from the IClickHandler, it returns the default handler.
         *
         * @param iClickHandler
         * @param chartJsDefaultHandler
         * @constructor
         */
        this.GetHandler = (iClickHandler, chartJsDefaultHandler) => {
            if (iClickHandler) {
                // Js function
                if (typeof iClickHandler === "object" &&
                    iClickHandler.hasOwnProperty('fullFunctionName')) {
                    let onClickStringName = iClickHandler;
                    const onClickNamespaceAndFunc = onClickStringName.fullFunctionName.split(".");
                    const onClickFunc = window[onClickNamespaceAndFunc[0]][onClickNamespaceAndFunc[1]];
                    if (typeof onClickFunc === "function") {
                        return onClickFunc;
                    }
                    else { // fallback to the default
                        return chartJsDefaultHandler;
                    }
                }
                // .Net static method
                else if (typeof iClickHandler === "object" &&
                    iClickHandler.hasOwnProperty('assemblyName') &&
                    iClickHandler.hasOwnProperty('methodName')) {
                    return (() => {
                        const onClickStatickHandler = iClickHandler;
                        const assemblyName = onClickStatickHandler.assemblyName;
                        const methodName = onClickStatickHandler.methodName;
                        return async (sender, args) => {
                            // This is sometimes necessary in order to avoid circular reference errors during JSON serialization
                            args = this.GetCleanArgs(args);
                            await DotNet.invokeMethodAsync(assemblyName, methodName, sender, args);
                        };
                    })();
                }
                // .Net instance method
                else if (typeof iClickHandler === "object" &&
                    iClickHandler.hasOwnProperty('instanceRef') &&
                    iClickHandler.hasOwnProperty('methodName')) {
                    return (() => {
                        const onClickInstanceHandler = iClickHandler;
                        const instanceRef = onClickInstanceHandler.instanceRef;
                        const methodName = onClickInstanceHandler.methodName;
                        return async (sender, args) => {
                            // This is sometimes necessary in order to avoid circular reference errors during JSON serialization
                            args = this.GetCleanArgs(args);
                            await instanceRef.invokeMethodAsync(methodName, sender, args);
                        };
                    })();
                }
            }
            else { // fallback to the default
                return chartJsDefaultHandler;
            }
        };
        this.GetCleanArgs = (args) => {
            // ToDo: refactor the function to clean up the args of each chart type 
            return typeof args['map'] === 'function' ?
                args.map(e => {
                    const newE = Object.assign({}, e, { _chart: undefined }, { _xScale: undefined }, { _yScale: undefined });
                    return newE;
                }) : args;
        };
    }
    SetupChart(config) {
        if (!this.BlazorCharts.has(config.canvasId)) {
            if (!config.options.legend)
                config.options.legend = {};
            let thisChart = this.initializeChartjsChart(config);
            this.BlazorCharts.set(config.canvasId, thisChart);
            return true;
        }
        else {
            return this.UpdateChart(config);
        }
    }
    UpdateChart(config) {
        if (!this.BlazorCharts.has(config.canvasId))
            throw `Could not find a chart with the given id. ${config.canvasId}`;
        let myChart = this.BlazorCharts.get(config.canvasId);
        /// Handle datasets
        this.HandleDatasets(myChart, config);
        /// Handle labels
        this.MergeLabels(myChart, config);
        // Redo any wiring up
        this.WireUpFunctions(config);
        // Handle options - mutating the Options seems better because the rest of the computed options members are preserved
        Object.entries(config.options).forEach(e => {
            myChart.config.options[e[0]] = e[1];
        });
        myChart.update();
        return true;
    }
    HandleDatasets(myChart, config) {
        // Remove any datasets the aren't in the new config
        let dataSetsToRemove = myChart.config.data.datasets.filter(d => config.data.datasets.find(newD => newD.id === d.id) === undefined);
        for (const d of dataSetsToRemove) {
            const indexToRemoveAt = myChart.config.data.datasets.indexOf(d);
            if (indexToRemoveAt != -1) {
                myChart.config.data.datasets.splice(indexToRemoveAt, 1);
            }
        }
        // Add new datasets
        let dataSetsToAdd = config.data.datasets.filter(newD => myChart.config.data.datasets.find(d => newD.id === d.id) === undefined);
        dataSetsToAdd.forEach(d => myChart.config.data.datasets.push(d));
        // Update any existing datasets
        let datasetsToUpdate = myChart.config.data.datasets
            .filter(d => config.data.datasets.find(newD => newD.id === d.id) !== undefined)
            .map(d => ({ oldD: d, newD: config.data.datasets.find(val => val.id === d.id) }));
        datasetsToUpdate.forEach(pair => {
            // pair.oldD.data.slice(0, pair.oldD.data.length);
            // pair.newD.data.forEach(newEntry => pair.oldD.data.push(newEntry));
            Object.entries(pair.newD).forEach(entry => pair.oldD[entry[0]] = entry[1]);
        });
    }
    MergeLabels(myChart, config) {
        if (config.data.labels === undefined || config.data.labels.length === 0) {
            myChart.config.data.labels = new Array();
            return;
        }
        if (!myChart.config.data.labels) {
            myChart.config.data.labels = new Array();
        }
        // clear existing labels
        myChart.config.data.labels.splice(0, myChart.config.data.labels.length);
        // add all the new labels
        config.data.labels.forEach(l => myChart.config.data.labels.push(l));
    }
    initializeChartjsChart(config) {
        let ctx = document.getElementById(config.canvasId);
        this.WireUpFunctions(config);
        let myChart = new Chart(ctx, config);
        return myChart;
    }
    WireUpFunctions(config) {
        // replace the Legend's OnHover function name with the actual function (if present)
        this.WireUpLegendOnHover(config);
        // replace the Options' OnClick function name with the actual function (if present)
        this.WireUpOptionsOnClickFunc(config);
        // replace the Options.Hover.OnHover func name with the actual function (if present)
        this.WireUpOptionsOnHoverFunc(config);
        // replace the Legend's OnClick function name with the actual function (if present)
        this.WireUpLegendOnClick(config);
        // replace the Label's GenerateLabels function name with the actual function (if present)
        this.WireUpGenerateLabelsFunc(config);
        // replace the Label's Filter function name with the actual function (if present)
        // see details here: http://www.chartjs.org/docs/latest/configuration/legend.html#legend-label-configuration
        this.WireUpLegendItemFilterFunc(config);
    }
    WireUpLegendItemFilterFunc(config) {
        if (config.options.legend.labels === undefined)
            config.options.legend.labels = {};
        if (config.options.legend.labels.filter &&
            typeof config.options.legend.labels.filter === "string" &&
            config.options.legend.labels.filter.includes(".")) {
            const filtersNamespaceAndFunc = config.options.legend.labels.filter.split(".");
            const filterFunc = window[filtersNamespaceAndFunc[0]][filtersNamespaceAndFunc[1]];
            if (typeof filterFunc === "function") {
                config.options.legend.labels.filter = filterFunc;
            }
            else { // fallback to the default, which is null
                config.options.legend.labels.filter = null;
            }
        }
        else { // fallback to the default, which is null
            config.options.legend.labels.filter = null;
        }
    }
    WireUpGenerateLabelsFunc(config) {
        let getDefaultFunc = function (type) {
            let defaults = Chart.defaults[type] || Chart.defaults.global;
            if (defaults.legend &&
                defaults.legend.labels &&
                defaults.legend.labels.generateLabels) {
                return defaults.legend.labels.generateLabels;
            }
            return Chart.defaults.global.legend.labels.generateLabels;
        };
        if (config.options.legend.labels === undefined)
            config.options.legend.labels = {};
        if (config.options.legend.labels.generateLabels &&
            typeof config.options.legend.labels.generateLabels === "string" &&
            config.options.legend.labels.generateLabels.includes(".")) {
            const generateLabelsNamespaceAndFunc = config.options.legend.labels.generateLabels.split(".");
            const generateLabelsFunc = window[generateLabelsNamespaceAndFunc[0]][generateLabelsNamespaceAndFunc[1]];
            if (typeof generateLabelsFunc === "function") {
                config.options.legend.labels.generateLabels = generateLabelsFunc;
            }
            else { // fallback to the default
                config.options.legend.labels.generateLabels = getDefaultFunc(config.type);
            }
        }
        else { // fallback to the default
            config.options.legend.labels.generateLabels = getDefaultFunc(config.type);
        }
    }
    WireUpOptionsOnClickFunc(config) {
        let getDefaultFunc = function (type) {
            var _a;
            let defaults = Chart.defaults[type] || Chart.defaults.global;
            return ((_a = defaults) === null || _a === void 0 ? void 0 : _a.onClick) || undefined;
        };
        config.options.onClick = this.GetHandler(config.options.onClick, getDefaultFunc(config.type));
    }
    WireUpOptionsOnHoverFunc(config) {
        let getDefaultFunc = function (type) {
            var _a, _b;
            let defaults = Chart.defaults[type] || Chart.defaults.global;
            return ((_b = (_a = defaults) === null || _a === void 0 ? void 0 : _a.hover) === null || _b === void 0 ? void 0 : _b.onHover) || undefined;
        };
        if (config.options.hover) {
            config.options.hover.onHover = this.GetHandler(config.options.hover.onHover, getDefaultFunc(config.type));
        }
    }
    WireUpLegendOnClick(config) {
        let getDefaultHandler = type => {
            var _a, _b, _c, _d;
            let chartDefaults = Chart.defaults[type];
            return ((_b = (_a = chartDefaults) === null || _a === void 0 ? void 0 : _a.legend) === null || _b === void 0 ? void 0 : _b.onClick) || ((_d = (_c = Chart.defaults.global) === null || _c === void 0 ? void 0 : _c.legend) === null || _d === void 0 ? void 0 : _d.onClick) || undefined;
        };
        config.options.legend.onClick = this.GetHandler(config.options.legend.onClick, getDefaultHandler(config.type));
    }
    WireUpLegendOnHover(config) {
        let getDefaultFunc = function (type) {
            var _a, _b, _c, _d;
            let chartDefaults = Chart.defaults[type];
            return ((_b = (_a = chartDefaults) === null || _a === void 0 ? void 0 : _a.legend) === null || _b === void 0 ? void 0 : _b.onHover) || ((_d = (_c = Chart.defaults.global) === null || _c === void 0 ? void 0 : _c.legend) === null || _d === void 0 ? void 0 : _d.onHover) || undefined;
        };
        config.options.legend.onHover = this.GetHandler(config.options.legend.onHover, getDefaultFunc(config.type));
    }
}
/* Set up all the momentjs interop stuff */
/// <reference path="types/moment.d.ts" />
class MomentJsInterop {
    getAvailableMomentLocales() {
        return moment.locales();
    }
    getCurrentLocale() {
        return moment.locale();
    }
    changeLocale(locale) {
        if (typeof locale !== 'string') {
            throw 'locale must be a string';
        }
        let cur = this.getCurrentLocale();
        // if the current locale is the one requested, we don't need to do anything
        if (locale === cur)
            return false;
        // set locale
        let newL = moment.locale(locale);
        // if the new locale is the same as the old one, it was not changed - probably because momentJs didn't find that locale
        if (cur === newL)
            throw 'the locale \'' + locale + '\' could not be set. It was probably not found.';
        return true;
    }
}
/// <reference path="ChartJsInterop.ts" />
/// <reference path="MomentJsInterop.ts" />
function AttachChartJsInterop() {
    window[ChartJsInterop.name] = new ChartJsInterop();
}
AttachChartJsInterop();
function AttachMomentJsInterop() {
    window[MomentJsInterop.name] = new MomentJsInterop();
}
AttachMomentJsInterop();
//# sourceMappingURL=ChartJsBlazorInterop.js.map