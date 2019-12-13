/* Set up all the chartjs interop stuff */

/// <reference path="types/Chart.min.d.ts" />   

interface ChartConfiguration extends Chart.ChartConfiguration {
    canvasId: string;
}

interface DotNetType {
    invokeMethodAsync(assemblyName, methodName, sender, args): Promise<any>;
}

interface DotNetObjectReference {
    invokeMethodAsync(methodName, sender, args): Promise<any>;
}

declare var DotNet: DotNetType;

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

    private WireUpLegendItemFilterFunc(config) {
        if (config.options.legend.labels === undefined)
            config.options.legend.labels = {};
        if (config.options.legend.labels.filter &&
            typeof config.options.legend.labels.filter === "string" &&
            config.options.legend.labels.filter.includes(".")) {
            const filtersNamespaceAndFunc = config.options.legend.labels.filter.split(".");
            const filterFunc = window[filtersNamespaceAndFunc[0]][filtersNamespaceAndFunc[1]];
            if (typeof filterFunc === "function") {
                config.options.legend.labels.filter = filterFunc;
            } else { // fallback to the default, which is null
                config.options.legend.labels.filter = null;
            }
        } else { // fallback to the default, which is null
            config.options.legend.labels.filter = null;
        }
    }

    private WireUpGenerateLabelsFunc(config) {
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
            } else { // fallback to the default
                config.options.legend.labels.generateLabels = getDefaultFunc(config.type);
            }
        } else { // fallback to the default
            config.options.legend.labels.generateLabels = getDefaultFunc(config.type);
        }
    }

    private WireUpOptionsOnClickFunc(config: ChartConfiguration) {
        let getDefaultFunc = function (type) {
            let defaults = Chart.defaults[type] || Chart.defaults.global;
            return defaults?.onClick || undefined;
        };

        config.options.onClick = this.GetHandler(config.options.onClick, getDefaultFunc(config.type));
    }

    private WireUpOptionsOnHoverFunc(config: ChartConfiguration) {
        let getDefaultFunc = function (type) {
            let defaults = Chart.defaults[type] || Chart.defaults.global;
            return defaults?.hover?.onHover || undefined;
        };

        if (config.options.hover) {
            config.options.hover.onHover = this.GetHandler(config.options.hover.onHover, getDefaultFunc(config.type));
        }
    }

    private WireUpLegendOnClick(config) {
        let getDefaultHandler = type => {
            let chartDefaults = Chart.defaults[type];
            return chartDefaults?.legend?.onClick || Chart.defaults.global?.legend?.onClick || undefined;
        };

        config.options.legend.onClick = this.GetHandler(config.options.legend.onClick, getDefaultHandler(config.type));
    }

    private WireUpLegendOnHover(config) {
        let getDefaultFunc = function (type) {
            let chartDefaults = Chart.defaults[type];
            return chartDefaults?.legend?.onHover || Chart.defaults.global?.legend?.onHover || undefined;
        };

        config.options.legend.onHover = this.GetHandler(config.options.legend.onHover, getDefaultFunc(config.type));
    }

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
    private GetHandler = (iClickHandler, chartJsDefaultHandler: Function) => {
        if (iClickHandler) {
            // Js function
            if (typeof iClickHandler === "object" &&
                iClickHandler.hasOwnProperty('fullFunctionName')) {
                let onClickStringName: { fullFunctionName: string } = <any>iClickHandler;
                const onClickNamespaceAndFunc = onClickStringName.fullFunctionName.split(".");
                const onClickFunc = window[onClickNamespaceAndFunc[0]][onClickNamespaceAndFunc[1]];
                if (typeof onClickFunc === "function") {
                    return onClickFunc;
                } else { // fallback to the default
                    return chartJsDefaultHandler;
                }
            }
            // .Net static method
            else if (typeof iClickHandler === "object" &&
                iClickHandler.hasOwnProperty('assemblyName') &&
                iClickHandler.hasOwnProperty('methodName')) {
                return (() => {
                    const onClickStatickHandler: { assemblyName: string, methodName: string } = <any>iClickHandler;
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
                    const onClickInstanceHandler: { instanceRef: DotNetObjectReference, methodName: string } = <any>iClickHandler;
                    const instanceRef = onClickInstanceHandler.instanceRef;
                    const methodName = onClickInstanceHandler.methodName;

                    return async (sender, args) => {

                        // This is sometimes necessary in order to avoid circular reference errors during JSON serialization
                        args = this.GetCleanArgs(args);

                        await instanceRef.invokeMethodAsync(methodName, sender, args);
                    };
                })();
            }
        } else { // fallback to the default
            return chartJsDefaultHandler;
        }
    };

    private GetCleanArgs = (args) => {
        // ToDo: refactor the function to clean up the args of each chart type 
        return typeof args['map'] === 'function' ?
            args.map(e => {
                    const newE = Object.assign({}, e, {_chart: undefined}, {_xScale: undefined}, {_yScale: undefined});
                    return newE;
                }
            ) : args;
    };
}
