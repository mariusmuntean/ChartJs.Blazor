/* Set up all the chartjs interop stuff */
/// <reference path="types/Chart.min.d.ts" />   
class ChartJsInterop {
    constructor() {
        this.BlazorCharts = new Map();
        /**
         * Given an IMethodHandler (see the C# code), it tries to resolve the referenced method.
         * It currently supports Javascript functions, which are expected to be attached to the window object, and .Net delegates which can be
         * bound to .Net static functions, .Net object instance methods and more.
         *
         * Failing to recover any handler from the IMethodHandler, it returns the default handler.
         *
         * @param iMethodHandler
         * @param defaultFunc
         * @constructor
         */
        this.GetMethodHandler = (iMethodHandler, defaultFunc) => {
            if (!iMethodHandler ||
                typeof iMethodHandler !== "object" ||
                !iMethodHandler.hasOwnProperty('methodName')) {
                return defaultFunc;
            }
            if (iMethodHandler.hasOwnProperty('handlerReference')) {
                const onClickInstanceHandler = iMethodHandler;
                const instanceRef = onClickInstanceHandler.handlerReference;
                const methodName = onClickInstanceHandler.methodName;
                return async (...args) => {
                    let cleanArgs = args.map(element => JSON.decycle(element)); // remove all circular references so it can be stringifyied and later deserialized. This requires cycle.js.
                    /* Currently this function is async meaning that it returns a Promise. Since Chart.Js may only check if the value is truthy
                     * (like in the case of legend.labels.filter) it gives wrong results because a promise that will resolve to be false is still seen
                     * as truthy at the point where the value is checked. Chart.Js simply does not expect a Promise from that function and therefore
                     * doesn't await it (see https://jsfiddle.net/jkcLyarh/1/). We somehow need to make sure we return the actual value here and not a promise.
                     * The wrapping with another non-async layer (...args) => (async args => {})(args) doesn't help. You can use the SampleInterop.AsyncFilter
                     * as example of it not working because the promise which will resolve to false will still fail to hide the labels because the promise object
                     * is seen as truthy.
                     * We cannot use the synchronous version instanceRef.invokeMethod because (at least for server-side) you get an error saying that
                     * the current dispatcher doesn't support synchronous calls.
                     */
                    // return instanceRef.invokeMethod(methodName, cleanArgs);
                    return await instanceRef.invokeMethodAsync(methodName, cleanArgs);
                };
            }
            else {
                let onClickStringName = iMethodHandler;
                const onClickNamespaceAndFunc = onClickStringName.methodName.split(".");
                const onClickFunc = window[onClickNamespaceAndFunc[0]][onClickNamespaceAndFunc[1]];
                if (typeof onClickFunc === "function") {
                    return onClickFunc;
                }
                else { // fallback to the default
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
    }
    WireUpOptionsOnClick(config) {
        let getDefaultFunc = type => {
            var _a, _b;
            let defaults = Chart.defaults[type] || Chart.defaults.global;
            return ((_a = defaults) === null || _a === void 0 ? void 0 : _a.onClick) || ((_b = Chart.defaults.global) === null || _b === void 0 ? void 0 : _b.onClick);
        };
        config.options.onClick = this.GetMethodHandler(config.options.onClick, getDefaultFunc(config.type));
    }
    WireUpOptionsOnHover(config) {
        let getDefaultFunc = type => {
            var _a, _b;
            let defaults = Chart.defaults[type] || Chart.defaults.global;
            return ((_a = defaults) === null || _a === void 0 ? void 0 : _a.onHover) || ((_b = Chart.defaults.global) === null || _b === void 0 ? void 0 : _b.onHover);
        };
        config.options.onHover = this.GetMethodHandler(config.options.onHover, getDefaultFunc(config.type));
    }
    WireUpLegendOnClick(config) {
        let getDefaultHandler = type => {
            var _a, _b, _c, _d;
            let chartDefaults = Chart.defaults[type] || Chart.defaults.global;
            return ((_b = (_a = chartDefaults) === null || _a === void 0 ? void 0 : _a.legend) === null || _b === void 0 ? void 0 : _b.onClick) || ((_d = (_c = Chart.defaults.global) === null || _c === void 0 ? void 0 : _c.legend) === null || _d === void 0 ? void 0 : _d.onClick);
        };
        config.options.legend.onClick = this.GetMethodHandler(config.options.legend.onClick, getDefaultHandler(config.type));
    }
    WireUpLegendOnHover(config) {
        let getDefaultFunc = type => {
            var _a, _b, _c, _d;
            let chartDefaults = Chart.defaults[type] || Chart.defaults.global;
            return ((_b = (_a = chartDefaults) === null || _a === void 0 ? void 0 : _a.legend) === null || _b === void 0 ? void 0 : _b.onHover) || ((_d = (_c = Chart.defaults.global) === null || _c === void 0 ? void 0 : _c.legend) === null || _d === void 0 ? void 0 : _d.onHover);
        };
        config.options.legend.onHover = this.GetMethodHandler(config.options.legend.onHover, getDefaultFunc(config.type));
    }
    WireUpLegendItemFilter(config) {
        let getDefaultFunc = type => {
            var _a, _b, _c, _d, _e, _f;
            let chartDefaults = Chart.defaults[type] || Chart.defaults.global;
            return ((_c = (_b = (_a = chartDefaults) === null || _a === void 0 ? void 0 : _a.legend) === null || _b === void 0 ? void 0 : _b.labels) === null || _c === void 0 ? void 0 : _c.filter) || ((_f = (_e = (_d = Chart.defaults.global) === null || _d === void 0 ? void 0 : _d.legend) === null || _e === void 0 ? void 0 : _e.labels) === null || _f === void 0 ? void 0 : _f.filter);
        };
        config.options.legend.labels.filter = this.GetMethodHandler(config.options.legend.labels.filter, getDefaultFunc(config.type));
    }
    WireUpGenerateLabels(config) {
        let getDefaultFunc = type => {
            var _a, _b, _c, _d, _e, _f;
            let chartDefaults = Chart.defaults[type] || Chart.defaults.global;
            return ((_c = (_b = (_a = chartDefaults) === null || _a === void 0 ? void 0 : _a.legend) === null || _b === void 0 ? void 0 : _b.labels) === null || _c === void 0 ? void 0 : _c.generateLabels) || ((_f = (_e = (_d = Chart.defaults.global) === null || _d === void 0 ? void 0 : _d.legend) === null || _e === void 0 ? void 0 : _e.labels) === null || _f === void 0 ? void 0 : _f.generateLabels);
        };
        config.options.legend.labels.generateLabels = this.GetMethodHandler(config.options.legend.labels.generateLabels, getDefaultFunc(config.type));
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