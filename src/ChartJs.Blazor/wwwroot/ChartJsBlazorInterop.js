/// <reference path="types/moment.d.ts" />
/// <reference path="types/Chart.min.d.ts" />   
class ChartJsInterop {
    constructor() {
        this.BlazorCharts = new Map();
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
        // replace the Legend's OnHover function name with the actual function (if present)
        this.WireUpOnHover(config);
        // replace the Legend's OnClick function name with the actual function (if present)
        this.WireUpOnClick(config);
        // replace the Label's GenerateLabels function name with the actual function (if present)
        this.WireUpGenerateLabelsFunc(config);
        // replace the Label's Filter function name with the actual function (if present)
        // see details here: http://www.chartjs.org/docs/latest/configuration/legend.html#legend-label-configuration
        this.WireUpLegendItemFilterFunc(config);
        let myChart = new Chart(ctx, config);
        return myChart;
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
    WireUpOnClick(config) {
        let getDefaultHandler = type => {
            let defaults = Chart.defaults[type] || Chart.defaults.global;
            if (defaults.legend &&
                defaults.legend.onClick) {
                return defaults.legend.onClick;
            }
            return Chart.defaults.global.legend.onClick;
        };
        if (config.options.legend.onClick) {
            // Js function
            if (typeof config.options.legend.onClick === "object" &&
                config.options.legend.onClick.hasOwnProperty('fullFunctionName')) {
                const onClickNamespaceAndFunc = config.options.legend.onClick.fullFunctionName.split(".");
                const onClickFunc = window[onClickNamespaceAndFunc[0]][onClickNamespaceAndFunc[1]];
                if (typeof onClickFunc === "function") {
                    config.options.legend.onClick = onClickFunc;
                }
                else { // fallback to the default
                    config.options.legend.onClick = getDefaultHandler(config.type);
                }
            }
            // .Net static method
            else if (typeof config.options.legend.onClick === "object" &&
                config.options.legend.onClick.hasOwnProperty('assemblyName') &&
                config.options.legend.onClick.hasOwnProperty('methodName')) {
                config.options.legend.onClick = (function () {
                    const assemblyName = config.options.legend.onClick.assemblyName;
                    const methodName = config.options.legend.onClick.methodName;
                    return async function (sender, args) {
                        await DotNet.invokeMethodAsync(assemblyName, methodName, sender, args);
                    };
                })();
            }
            // .Net instance method
            else if (typeof config.options.legend.onClick === "object" &&
                config.options.legend.onClick.hasOwnProperty('instanceRef') &&
                config.options.legend.onClick.hasOwnProperty('methodName')) {
                config.options.legend.onClick = (function () {
                    const instanceRef = config.options.legend.onClick.instanceRef;
                    const methodName = config.options.legend.onClick.methodName;
                    return async function (sender, args) {
                        await instanceRef.invokeMethodAsync(methodName, sender, args);
                    };
                })();
            }
        }
        else { // fallback to the default
            config.options.legend.onClick = getDefaultHandler(config.type);
        }
    }
    WireUpOnHover(config) {
        if (config.options.legend.onHover) {
            if (typeof config.options.legend.onHover === "object" &&
                config.options.legend.onHover.hasOwnProperty('fullFunctionName')) {
                const onHoverNamespaceAndFunc = config.options.legend.onHover.fullFunctionName.split(".");
                const onHoverFunc = window[onHoverNamespaceAndFunc[0]][onHoverNamespaceAndFunc[1]];
                if (typeof onHoverFunc === "function") {
                    config.options.legend.onHover = onHoverFunc;
                }
                else { // fallback to the default
                    config.options.legend.onHover = null;
                }
            }
            // .Net static method
            else if (typeof config.options.legend.onHover === "object" &&
                config.options.legend.onHover.hasOwnProperty('assemblyName') &&
                config.options.legend.onHover.hasOwnProperty('methodName')) {
                config.options.legend.onHover = (function () {
                    const assemblyName = config.options.legend.onHover.assemblyName;
                    const methodName = config.options.legend.onHover.methodName;
                    return async function (sender, mouseOverEvent) {
                        await DotNet.invokeMethodAsync(assemblyName, methodName, sender, mouseOverEvent);
                    };
                })();
            }
            // .Net instance method
            else if (typeof config.options.legend.onHover === "object" &&
                config.options.legend.onHover.hasOwnProperty('instanceRef') &&
                config.options.legend.onHover.hasOwnProperty('methodName')) {
                config.options.legend.onHover = (function () {
                    const instanceRef = config.options.legend.onHover.instanceRef;
                    const methodName = config.options.legend.onHover.methodName;
                    return async function (sender, mouseOverEvent) {
                        await instanceRef.invokeMethodAsync(methodName, sender, mouseOverEvent);
                    };
                })();
            }
        }
        else { // fallback to the default
            config.options.legend.onHover = null;
        }
    }
}
function AttachChartJsInterop() {
    window[ChartJsInterop.name] = new ChartJsInterop();
}
AttachChartJsInterop();
/* Set up all the momentjs interop stuff */
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
function AttachMomentJsInterop() {
    window[MomentJsInterop.name] = new MomentJsInterop();
}
AttachMomentJsInterop();
//# sourceMappingURL=ChartJsBlazorInterop.js.map