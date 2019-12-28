/* Set up all the chartjs interop stuff */

/// <reference path="types/Chart.min.d.ts" />   

interface ChartConfiguration extends Chart.ChartConfiguration {
    canvasId: string;
}

interface DotNetObjectReference {
    invokeMethodAsync(methodName: string, ...args): Promise<any>;
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

    private WireUpLegendItemFilterFunc(config: ChartConfiguration) {
        let getDefaultFunc = type => {
            let chartDefaults = Chart.defaults[type] || Chart.defaults.global;
            return chartDefaults?.legend?.labels?.filter || Chart.defaults.global?.legend?.labels?.filter;
        };

        config.options.legend.labels.filter = this.GetMethodHandler(config.options.legend.labels.filter, getDefaultFunc(config.type));
    }

    private WireUpGenerateLabelsFunc(config: ChartConfiguration) {
        let getDefaultFunc = type => {
            let chartDefaults = Chart.defaults[type] || Chart.defaults.global;
            return chartDefaults?.legend?.labels?.generateLabels || Chart.defaults.global?.legend?.labels?.generateLabels;
        };

        config.options.legend.labels.generateLabels = this.GetMethodHandler(config.options.legend.labels.generateLabels, getDefaultFunc(config.type));
    }

    private WireUpOptionsOnClickFunc(config: ChartConfiguration) {
        let getDefaultFunc = type => {
            let defaults = Chart.defaults[type] || Chart.defaults.global;
            return defaults?.onClick || Chart.defaults.global?.onClick;
        };

        config.options.onClick = this.GetMethodHandler(config.options.onClick, getDefaultFunc(config.type));
    }

    private WireUpOptionsOnHoverFunc(config: ChartConfiguration) {
        let getDefaultFunc = type => {
            let defaults = Chart.defaults[type] || Chart.defaults.global;
            return defaults?.hover?.onHover || Chart.defaults.global?.hover?.onHover;
        };

        if (config.options.hover) {
            config.options.hover.onHover = this.GetMethodHandler(config.options.hover.onHover, getDefaultFunc(config.type));
        }
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

    /**
     * Given an IMethodHandler (see the C# code), it tries to resolve the referenced method.
     * It currently supports Javascript functions, which are expected to be attached to the window object; and .Net delegates which can be
     * bound to .Net static functions, .Net object instance methods and more.
     *
     * Failing to recover any handler from the IMethodHandler, it returns the default handler.
     *
     * @param iMethodHandler
     * @param chartJsDefaultHandler
     * @constructor
     */
    private GetMethodHandler = (iMethodHandler, chartJsDefaultHandler: Function) => {
        if (!iMethodHandler ||
            typeof iMethodHandler !== "object" ||
            !iMethodHandler.hasOwnProperty('methodName')) {
            return chartJsDefaultHandler;
        }

        if (iMethodHandler.hasOwnProperty('handlerReference')) {
            return (() => {
                const onClickInstanceHandler: { handlerReference: DotNetObjectReference, methodName: string } = <any>iMethodHandler;
                const instanceRef = onClickInstanceHandler.handlerReference;
                const methodName = onClickInstanceHandler.methodName;

                return async (...args) => {
                    await instanceRef.invokeMethodAsync(methodName, args);
                };
            })();
        } else {
            let onClickStringName: { fullFunctionName: string } = <any>iMethodHandler;
            const onClickNamespaceAndFunc = onClickStringName.fullFunctionName.split(".");
            const onClickFunc = window[onClickNamespaceAndFunc[0]][onClickNamespaceAndFunc[1]];
            if (typeof onClickFunc === "function") {
                return onClickFunc;
            } else { // fallback to the default
                return chartJsDefaultHandler;
            }
        }
    };

    //private GetCleanArgs = (args) => {
    //    // ToDo: refactor the function to clean up the args of each chart type 
    //    return typeof args['map'] === 'function' ?
    //        args.map(e => {
    //                const newE = Object.assign({}, e, {_chart: undefined}, {_xScale: undefined}, {_yScale: undefined});
    //                return newE;
    //            }
    //        ) : args;
    //};
}
