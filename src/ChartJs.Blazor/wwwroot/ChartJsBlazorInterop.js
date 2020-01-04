/* Set up all the chartjs interop stuff */
/// <reference path="types/Chart.min.d.ts" />   
class ChartJsInterop {
    constructor() {
        this.BlazorCharts = new Map();
        /**
         * Given an IMethodHandler (see C# code), it tries to resolve the referenced method.
         * It currently supports Javascript functions, which are expected to be attached to the window object, and .Net delegates which can be
         * bound to .Net static functions, .Net object instance methods and more.
         *
         * When failing to recover a method from the IMethodHandler, it returns the default handler.
         *
         * @param iMethodHandler the serialized IMethodHandler (see C# code)
         * @param defaultFunc the fallback value to use in case the method can't be resolved
         */
        this.GetMethodHandler = (iMethodHandler, defaultFunc) => {
            if (!iMethodHandler ||
                typeof iMethodHandler !== "object" ||
                !iMethodHandler.hasOwnProperty('methodName')) {
                return defaultFunc;
            }
            if (iMethodHandler.hasOwnProperty('handlerReference')) {
                const handler = iMethodHandler;
                // remove all circular references so it can be stringifyied and later deserialized by C#. This requires cycle.js.
                const cleanArgs = args => args.map(element => JSON.decycle(element));
                if (!handler.returnsValue) {
                    // https://stackoverflow.com/questions/59543973/use-async-function-when-consumer-doesnt-expect-a-promise
                    return (...args) => handler.handlerReference.invokeMethodAsync(handler.methodName, cleanArgs(args));
                }
                else {
                    if (window.hasOwnProperty('MONO')) {
                        return (...args) => handler.handlerReference.invokeMethod(handler.methodName, cleanArgs(args)); // only works on client side
                    }
                    else {
                        console.warn("Using C# delegates that return values in chart.js callbacks is not supported on " +
                            "server side blazor because the server side dispatcher doesn't support synchronous interop calls. Falling back to default value.");
                        return defaultFunc;
                    }
                }
            }
            else {
                const handler = iMethodHandler;
                try {
                    const namespaceAndFunc = handler.methodName.split(".");
                    const func = window[namespaceAndFunc[0]][namespaceAndFunc[1]];
                    if (typeof func === "function") {
                        return func;
                    }
                    else {
                        return defaultFunc;
                    }
                }
                catch (_a) {
                    return defaultFunc;
                }
            }
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
        // Handle datasets
        this.HandleDatasets(myChart, config);
        // Handle labels
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
        // replace the Option's OnClick function name with the actual function (if present)
        this.WireUpOptionsOnClick(config);
        // replace the Option's OnHover function name with the actual function (if present)
        this.WireUpOptionsOnHover(config);
        // replace the Legend's OnClick function name with the actual function (if present)
        this.WireUpLegendOnClick(config);
        // replace the Legend's OnHover function name with the actual function (if present)
        this.WireUpLegendOnHover(config);
        // replace the Label's Filter function name with the actual function (if present)
        // see details here: http://www.chartjs.org/docs/latest/configuration/legend.html#legend-label-configuration
        this.WireUpLegendItemFilter(config);
        // replace the Label's GenerateLabels function name with the actual function (if present)
        this.WireUpGenerateLabels(config);
        // replace the Axis' Ticks function name with the actual function (if present)
        this.WireUpTickCallback(config);
    }
    WireUpOptionsOnClick(config) {
        let getDefaultFunc = type => {
            var _a;
            let defaults = Chart.defaults[type] || Chart.defaults.global;
            return ((_a = defaults) === null || _a === void 0 ? void 0 : _a.onClick) || Chart.defaults.global.onClick;
        };
        config.options.onClick = this.GetMethodHandler(config.options.onClick, getDefaultFunc(config.type));
    }
    WireUpOptionsOnHover(config) {
        let getDefaultFunc = type => {
            var _a;
            let defaults = Chart.defaults[type] || Chart.defaults.global;
            return ((_a = defaults) === null || _a === void 0 ? void 0 : _a.onHover) || Chart.defaults.global.onHover;
        };
        config.options.onHover = this.GetMethodHandler(config.options.onHover, getDefaultFunc(config.type));
    }
    WireUpLegendOnClick(config) {
        let getDefaultHandler = type => {
            var _a, _b;
            let chartDefaults = Chart.defaults[type] || Chart.defaults.global;
            return ((_b = (_a = chartDefaults) === null || _a === void 0 ? void 0 : _a.legend) === null || _b === void 0 ? void 0 : _b.onClick) || Chart.defaults.global.legend.onClick;
        };
        config.options.legend.onClick = this.GetMethodHandler(config.options.legend.onClick, getDefaultHandler(config.type));
    }
    WireUpLegendOnHover(config) {
        let getDefaultFunc = type => {
            var _a, _b;
            let chartDefaults = Chart.defaults[type] || Chart.defaults.global;
            return ((_b = (_a = chartDefaults) === null || _a === void 0 ? void 0 : _a.legend) === null || _b === void 0 ? void 0 : _b.onHover) || Chart.defaults.global.legend.onHover;
        };
        config.options.legend.onHover = this.GetMethodHandler(config.options.legend.onHover, getDefaultFunc(config.type));
    }
    WireUpLegendItemFilter(config) {
        let getDefaultFunc = type => {
            var _a, _b, _c;
            let chartDefaults = Chart.defaults[type] || Chart.defaults.global;
            return ((_c = (_b = (_a = chartDefaults) === null || _a === void 0 ? void 0 : _a.legend) === null || _b === void 0 ? void 0 : _b.labels) === null || _c === void 0 ? void 0 : _c.filter) || Chart.defaults.global.legend.labels.filter;
        };
        config.options.legend.labels.filter = this.GetMethodHandler(config.options.legend.labels.filter, getDefaultFunc(config.type));
    }
    WireUpGenerateLabels(config) {
        let getDefaultFunc = type => {
            var _a, _b, _c;
            let chartDefaults = Chart.defaults[type] || Chart.defaults.global;
            return ((_c = (_b = (_a = chartDefaults) === null || _a === void 0 ? void 0 : _a.legend) === null || _b === void 0 ? void 0 : _b.labels) === null || _c === void 0 ? void 0 : _c.generateLabels) || Chart.defaults.global.legend.labels.generateLabels;
        };
        config.options.legend.labels.generateLabels = this.GetMethodHandler(config.options.legend.labels.generateLabels, getDefaultFunc(config.type));
    }
    WireUpTickCallback(config) {
        /* Defaults table (found out by checking Chart.defaults in console) -> everything undefined
         * Bar (scales): undefined
         * Bubble (scales): undefined
         * Pie & Doughnut: don't even have scale(s) field
         * HorizontalBar (scales): undefined
         * Line (scales): undefined
         * PolarArea (scale): undefined
         * Radar (scale): undefined
         * Scatter (scales): undefined
         */
        var _a, _b, _c;
        const assignCallbacks = axes => {
            if (axes) {
                for (var i = 0; i < axes.length; i++) {
                    if (!axes[i].ticks)
                        continue;
                    axes[i].ticks.callback = this.GetMethodHandler(axes[i].ticks.callback, undefined);
                    if (!axes[i].ticks.callback) {
                        delete axes[i].ticks.callback; // undefined != deleted, chartJs throws an error if it's undefined so we have to delete it
                    }
                }
            }
        };
        assignCallbacks((_a = config.options.scales) === null || _a === void 0 ? void 0 : _a.xAxes);
        assignCallbacks((_b = config.options.scales) === null || _b === void 0 ? void 0 : _b.yAxes);
        if ((_c = config.options.scale) === null || _c === void 0 ? void 0 : _c.ticks) {
            config.options.scale.ticks.callback = this.GetMethodHandler(config.options.scale.ticks.callback, undefined);
        }
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