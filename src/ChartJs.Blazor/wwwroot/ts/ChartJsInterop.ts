/* Set up all the chartjs interop stuff */

/// <reference path="types/Chart.min.d.ts" />   

interface ChartConfiguration extends Chart.ChartConfiguration {
    canvasId: string;
}

interface DotNetObjectReference {
    invokeMethod(methodName: string, ...args): any;
    invokeMethodAsync(methodName: string, ...args): Promise<any>;
}

// cycle.js (minified from https://github.com/douglascrockford/JSON-js)
interface JSON {
    decycle(element: any, replacer?: (value: any) => any): any;
}

class ChartJsInterop {

    BlazorCharts = new Map<string, Chart>();

    public SetupChart(config: ChartConfiguration): boolean {
        if (!this.BlazorCharts.has(config.canvasId)) {
            if (!config.options.legend)
                config.options.legend = {};
            let thisChart = this.initializeChartjsChart(config);
            this.BlazorCharts.set(config.canvasId, thisChart);
            return true;
        } else {
            return this.UpdateChart(config);
        }
    }

    public UpdateChart(config: ChartConfiguration): boolean {
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

    private HandleDatasets(myChart: Chart, config: ChartConfiguration) {
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
            .map(d => ({oldD: d, newD: config.data.datasets.find(val => val.id === d.id)}));
        datasetsToUpdate.forEach(pair => {
            // pair.oldD.data.slice(0, pair.oldD.data.length);
            // pair.newD.data.forEach(newEntry => pair.oldD.data.push(newEntry));
            Object.entries(pair.newD).forEach(entry => pair.oldD[entry[0]] = entry[1]);
        });
    }

    private MergeLabels(myChart: Chart, config: ChartConfiguration) {
        if (config.data.labels === undefined || config.data.labels.length === 0) {
            myChart.config.data.labels = new Array<string | string[]>();
            return;
        }
        if (!myChart.config.data.labels) {
            myChart.config.data.labels = new Array<string | string[]>();
        }
        // clear existing labels
        myChart.config.data.labels.splice(0, myChart.config.data.labels.length);

        // add all the new labels
        config.data.labels.forEach(l => myChart.config.data.labels.push(l));
    }

    private initializeChartjsChart(config: ChartConfiguration): Chart {
        let ctx = <HTMLCanvasElement>document.getElementById(config.canvasId);

        this.WireUpFunctions(config);

        let myChart = new Chart(ctx, config);
        return myChart;
    }

    private WireUpFunctions(config: ChartConfiguration) {

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

    private WireUpOptionsOnClick(config: ChartConfiguration) {
        let getDefaultFunc = type => {
            let defaults = Chart.defaults[type] || Chart.defaults.global;
            return defaults?.onClick || Chart.defaults.global?.onClick;
        };

        config.options.onClick = this.GetMethodHandler(config.options.onClick, getDefaultFunc(config.type));
    }

    private WireUpOptionsOnHover(config: ChartConfiguration) {
        let getDefaultFunc = type => {
            let defaults = Chart.defaults[type] || Chart.defaults.global;
            return defaults?.onHover || Chart.defaults.global?.onHover;
        };

        config.options.onHover = this.GetMethodHandler(config.options.onHover, getDefaultFunc(config.type));
    }

    private WireUpLegendOnClick(config: ChartConfiguration) {
        let getDefaultHandler = type => {
            let chartDefaults = Chart.defaults[type] || Chart.defaults.global;
            return chartDefaults?.legend?.onClick || Chart.defaults.global?.legend?.onClick;
        };

        config.options.legend.onClick = this.GetMethodHandler(config.options.legend.onClick, getDefaultHandler(config.type));
    }

    private WireUpLegendOnHover(config: ChartConfiguration) {
        let getDefaultFunc = type => {
            let chartDefaults = Chart.defaults[type] || Chart.defaults.global;
            return chartDefaults?.legend?.onHover || Chart.defaults.global?.legend?.onHover;
        };

        config.options.legend.onHover = this.GetMethodHandler(config.options.legend.onHover, getDefaultFunc(config.type));
    }

    private WireUpLegendItemFilter(config: ChartConfiguration) {
        let getDefaultFunc = type => {
            let chartDefaults = Chart.defaults[type] || Chart.defaults.global;
            return chartDefaults?.legend?.labels?.filter || Chart.defaults.global?.legend?.labels?.filter;
        };

        config.options.legend.labels.filter = this.GetMethodHandler(config.options.legend.labels.filter, getDefaultFunc(config.type));
    }

    private WireUpGenerateLabels(config: ChartConfiguration) {
        let getDefaultFunc = type => {
            let chartDefaults = Chart.defaults[type] || Chart.defaults.global;
            return chartDefaults?.legend?.labels?.generateLabels || Chart.defaults.global?.legend?.labels?.generateLabels;
        };

        config.options.legend.labels.generateLabels = this.GetMethodHandler(config.options.legend.labels.generateLabels, getDefaultFunc(config.type));
    }

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
    private GetMethodHandler = (iMethodHandler, defaultFunc: Function) => {
        if (!iMethodHandler ||
            typeof iMethodHandler !== "object" ||
            !iMethodHandler.hasOwnProperty('methodName')) {
            return defaultFunc;
        }

        if (iMethodHandler.hasOwnProperty('handlerReference')) {
            const onClickInstanceHandler: { handlerReference: DotNetObjectReference, methodName: string } = <any>iMethodHandler;
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
        } else {
            let onClickStringName: { methodName: string } = <any>iMethodHandler;
            const onClickNamespaceAndFunc = onClickStringName.methodName.split(".");
            const onClickFunc = window[onClickNamespaceAndFunc[0]][onClickNamespaceAndFunc[1]];
            if (typeof onClickFunc === "function") {
                return onClickFunc;
            } else { // fallback to the default
                return defaultFunc;
            }
        }
    };
}
