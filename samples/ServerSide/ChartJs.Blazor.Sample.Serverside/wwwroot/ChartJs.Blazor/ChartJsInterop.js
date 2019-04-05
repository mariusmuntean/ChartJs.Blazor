var BlazorCharts = [];

Blazor.BlazorCharts = BlazorCharts;
window.ChartJSInterop = {
    SetupChart: function (config) {

        if (!BlazorCharts.find(currentChart => currentChart.id === config.canvasId)) {
            if (!config.options.legend)
                config.options.legend = {};

            let thisChart = initializeChartjsChart2(config);
            BlazorCharts.push({ id: config.canvasId, chart: thisChart });
        }
        else {
            let myChart = BlazorCharts.find(currentChart => currentChart.id === config.canvasId);

            myChart.chart.destroy();
            myChart.chart = {};

            let newChart = initializeChartjsChart2(config);
            myChart.chart = newChart;

        }

        return true;
    },

    UpdateChart: function (config) {

        if (!BlazorCharts.find(currentChart => currentChart.id === config.canvasId))
            throw `Could not find a chart with the given id. ${config.canvasId}`;

        let myChart = BlazorCharts.find(currentChart => currentChart.id === config.canvasId);

        myChart.chart.config.data.datasets = config.data.datasets;
        myChart.chart.config.data.labels = config.data.labels;

        myChart.chart.render({
            duration: 800,
            lazy: false,
            easing: 'easeOutBounce'
        });
        myChart.chart.update();

        return true;
    }
};

function initializeChartjsChart2(config) {
    let ctx = document.getElementById(config.canvasId);

    // replace the Legend's OnHover function name with the actual function (if present)
    WireUpOnHover(config);

    // replace the Legend's OnClick function name with the actual function (if present)
    WireUpOnClick(config);

    // replace the Label's GenerateLabels function name with the actual function (if present)
    WireUpGenerateLabelsFunc(config);

    // replace the Label's Filter function name with the actual function (if present)
    // see details here: http://www.chartjs.org/docs/latest/configuration/legend.html#legend-label-configuration
    WireUpLegendItemFilterFunc(config);

    let myChart = new Chart(ctx, config);

    return myChart;
}

function WireUpLegendItemFilterFunc(config) {
    if (config.options.legend.labels === undefined)
        config.options.legend.labels = {};

    if (config.options.legend.labels.filter &&
        typeof config.options.legend.labels.filter === "string" &&
        config.options.legend.labels.filter.includes(".")) {
        var filtersNamespaceAndFunc = config.options.legend.labels.filter.split(".");
        var filterFunc = window[filtersNamespaceAndFunc[0]][filtersNamespaceAndFunc[1]];
        if (typeof filterFunc === "function") {
            config.options.legend.labels.filter = filterFunc;
        } else { // fallback to the default, which is null
            config.options.legend.labels.filter = null;
        }
    } else { // fallback to the default, which is null
        config.options.legend.labels.filter = null;
    }
}

function WireUpGenerateLabelsFunc(config) {
    if (config.options.legend.labels === undefined)
        config.options.legend.labels = {};

    if (config.options.legend.labels.generateLabels &&
        typeof config.options.legend.labels.generateLabels === "string" &&
        config.options.legend.labels.generateLabels.includes(".")) {
        var generateLabelsNamespaceAndFunc = config.options.legend.labels.generateLabels.split(".");
        var generateLabelsFunc = window[generateLabelsNamespaceAndFunc[0]][generateLabelsNamespaceAndFunc[1]];
        if (typeof generateLabels === "function") {
            config.options.legend.labels.generateLabels = generateLabelsFunc;
        } else { // fallback to the default
            config.options.legend.labels.generateLabels = Chart.defaults.global.legend.labels.generateLabels;
        }
    } else { // fallback to the default
        config.options.legend.labels.generateLabels = Chart.defaults.global.legend.labels.generateLabels;
    }
}

function WireUpOnClick(config) {
    if (config.options.legend.onClick) {
        // Js function
        if (typeof config.options.legend.onClick === "object" &&
            config.options.legend.onClick.hasOwnProperty('fullFunctionName')) {
            var onClickNamespaceAndFunc = config.options.legend.onClick.fullFunctionName.split(".");
            var onClickFunc = window[onClickNamespaceAndFunc[0]][onClickNamespaceAndFunc[1]];
            if (typeof onClickFunc === "function") {
                config.options.legend.onClick = onClickFunc;
            } else { // fallback to the default
                config.options.legend.onClick = Chart.defaults.global.legend.onClick;
            }
        }
        // .Net static method
        else if (typeof config.options.legend.onClick === "object" &&
            config.options.legend.onClick.hasOwnProperty('assemblyName') &&
            config.options.legend.onClick.hasOwnProperty('methodName')) {
            config.options.legend.onClick = (function () {
                var assemblyName = config.options.legend.onClick.assemblyName;
                var methodName = config.options.legend.onClick.methodName;
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
                var instanceRef = config.options.legend.onClick.instanceRef;
                var methodName = config.options.legend.onClick.methodName;
                return async function (sender, args) {
                    await instanceRef.invokeMethodAsync(methodName, sender, args);
                };
            })();
        }
    } else { // fallback to the default
        config.options.legend.onClick = Chart.defaults.global.legend.onClick;
    }
}

function WireUpOnHover(config) {
    if (config.options.legend.onHover) {
        if (typeof config.options.legend.onHover === "object" &&
            config.options.legend.onHover.hasOwnProperty('fullFunctionName')) {
            var onHoverNamespaceAndFunc = config.options.legend.onHover.fullFunctionName.split(".");
            var onHoverFunc = window[onHoverNamespaceAndFunc[0]][onHoverNamespaceAndFunc[1]];
            if (typeof onHoverFunc === "function") {
                config.options.legend.onHover = onHoverFunc;
            } else { // fallback to the default
                config.options.legend.onHover = null;
            }
        }
        // .Net static method
        else if (typeof config.options.legend.onHover === "object" &&
            config.options.legend.onHover.hasOwnProperty('assemblyName') &&
            config.options.legend.onHover.hasOwnProperty('methodName')) {
            config.options.legend.onHover = (function () {
                var assemblyName = config.options.legend.onHover.assemblyName;
                var methodName = config.options.legend.onHover.methodName;
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
                var instanceRef = config.options.legend.onHover.instanceRef;
                var methodName = config.options.legend.onHover.methodName;
                return async function (sender, mouseOverEvent) {
                    await instanceRef.invokeMethodAsync(methodName, sender, mouseOverEvent);
                };
            })();
        }
    } else { // fallback to the default
        config.options.legend.onHover = null;
    }
}