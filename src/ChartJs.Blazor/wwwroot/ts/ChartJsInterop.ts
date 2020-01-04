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
        // replace the Axis' Ticks function name with the actual function (if present)
        this.WireUpTickCallback(config);
    }

    private WireUpOptionsOnClick(config: ChartConfiguration) {
        let getDefaultFunc = type => {
            let defaults = Chart.defaults[type] || Chart.defaults.global;
            return defaults?.onClick || Chart.defaults.global.onClick;
        };

        config.options.onClick = this.GetMethodHandler(config.options.onClick, getDefaultFunc(config.type));
    }

    private WireUpOptionsOnHover(config: ChartConfiguration) {
        let getDefaultFunc = type => {
            let defaults = Chart.defaults[type] || Chart.defaults.global;
            return defaults?.onHover || Chart.defaults.global.onHover;
        };

        config.options.onHover = this.GetMethodHandler(config.options.onHover, getDefaultFunc(config.type));
    }

    private WireUpLegendOnClick(config: ChartConfiguration) {
        let getDefaultHandler = type => {
            let chartDefaults = Chart.defaults[type] || Chart.defaults.global;
            return chartDefaults?.legend?.onClick || Chart.defaults.global.legend.onClick;
        };

        config.options.legend.onClick = this.GetMethodHandler(config.options.legend.onClick, getDefaultHandler(config.type));
    }

    private WireUpLegendOnHover(config: ChartConfiguration) {
        let getDefaultFunc = type => {
            let chartDefaults = Chart.defaults[type] || Chart.defaults.global;
            return chartDefaults?.legend?.onHover || Chart.defaults.global.legend.onHover;
        };

        config.options.legend.onHover = this.GetMethodHandler(config.options.legend.onHover, getDefaultFunc(config.type));
    }

    private WireUpLegendItemFilter(config: ChartConfiguration) {
        let getDefaultFunc = type => {
            let chartDefaults = Chart.defaults[type] || Chart.defaults.global;
            return chartDefaults?.legend?.labels?.filter || Chart.defaults.global.legend.labels.filter;
        };

        config.options.legend.labels.filter = this.GetMethodHandler(config.options.legend.labels.filter, getDefaultFunc(config.type));
    }

    private WireUpGenerateLabels(config: ChartConfiguration) {
        let getDefaultFunc = type => {
            let chartDefaults = Chart.defaults[type] || Chart.defaults.global;
            return chartDefaults?.legend?.labels?.generateLabels || Chart.defaults.global.legend.labels.generateLabels;
        };

        config.options.legend.labels.generateLabels = this.GetMethodHandler(config.options.legend.labels.generateLabels, getDefaultFunc(config.type));
    }

    private WireUpTickCallback(config: ChartConfiguration) {
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

        const assignCallbacks = axes => {
            if (axes) {
                for (var i = 0; i < axes.length; i++) {
                    if (!axes[i].ticks) continue;
                    axes[i].ticks.callback = this.GetMethodHandler(axes[i].ticks.callback, undefined);
                    if (!axes[i].ticks.callback) {
                        delete axes[i].ticks.callback; // undefined != deleted, chartJs throws an error if it's undefined so we have to delete it
                    }
                }
            }
        }

        assignCallbacks(config.options.scales?.xAxes);
        assignCallbacks(config.options.scales?.yAxes);

        if (config.options.scale?.ticks) {
            config.options.scale.ticks.callback = this.GetMethodHandler(config.options.scale.ticks.callback, undefined);
        }
    }

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
    private GetMethodHandler = (iMethodHandler, defaultFunc: Function) => {
        if (!iMethodHandler ||
            typeof iMethodHandler !== "object" ||
            !iMethodHandler.hasOwnProperty('methodName')) {
            return defaultFunc;
        }

        if (iMethodHandler.hasOwnProperty('handlerReference')) {
            const handler: { handlerReference: DotNetObjectReference, methodName: string, returnsValue: boolean } = <any>iMethodHandler;
            // remove all circular references so it can be stringifyied and later deserialized by C#. This requires cycle.js.
            const cleanArgs = args => args.map(element => JSON.decycle(element));

            if (!handler.returnsValue) {
                // https://stackoverflow.com/questions/59543973/use-async-function-when-consumer-doesnt-expect-a-promise
                return (...args) => handler.handlerReference.invokeMethodAsync(handler.methodName, cleanArgs(args));
            } else {
                if (window.hasOwnProperty('MONO')) {
                    return (...args) => handler.handlerReference.invokeMethod(handler.methodName, cleanArgs(args)); // only works on client side
                } else {
                    console.warn("Using C# delegates that return values in chart.js callbacks is not supported on " +
                        "server side blazor because the server side dispatcher doesn't support synchronous interop calls. Falling back to default value.")

                    return defaultFunc;
                }
            }
        } else {
            const handler: { methodName: string } = <any>iMethodHandler;
            try {
                const namespaceAndFunc = handler.methodName.split(".");
                const func = window[namespaceAndFunc[0]][namespaceAndFunc[1]];
                if (typeof func === "function") {
                    return func;
                } else {
                    return defaultFunc;
                }
            } catch {
                return defaultFunc;
            }
        }
    };
}
