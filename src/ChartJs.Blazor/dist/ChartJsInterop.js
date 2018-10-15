var BlazorCharts = [];

Blazor.BlazorCharts = BlazorCharts;
window.ChartJSInterop = {
    InitializeBarChart: function(config) {
        if (!BlazorCharts.find(currentChart => currentChart.id === config.canvasId)) {
            let thisChart = initializeChartjsChart2(config);
            BlazorCharts.push({ id: config.canvasId, chart: thisChart });
        }

        return true;
    },
    InitializeLineChart: function(config) {
        if (!BlazorCharts.find(currentChart => currentChart.id === config.canvasId)) {
            let thisChart = initializeChartjsChart2(config);
            BlazorCharts.push({ id: config.canvasId, chart: thisChart });
        }

        return true;
    },
    InitializePieChart: function(config) {
        if (!BlazorCharts.find(currentChart => currentChart.id === config.canvasId)) {
            let thisChart = initializeChartjsChart2(config);
            BlazorCharts.push({ id: config.canvasId, chart: thisChart });
        }

        return true;
    },
    InitializeDoughnutChart: function(config) {
        if (!BlazorCharts.find(currentChart => currentChart.id === config.canvasId)) {
            let thisChart = initializeChartjsChart2(config);
            BlazorCharts.push({ id: config.canvasId, chart: thisChart });
        }

        return true;
    },
    InitializeMixedChart: function(config) {
        if (!BlazorCharts.find(currentChart => currentChart.id === config.canvasId)) {
            let thisChart = initializeChartjsChart2(config);
            BlazorCharts.push({ id: config.canvasId, chart: thisChart });
        }

        return true;
    },
    InitializeRadarChart: function(config) {
        if (!BlazorCharts.find(currentChart => currentChart.id === config.canvasId)) {
            let thisChart = initializeChartjsChart2(config);
            BlazorCharts.push({ id: config.canvasId, chart: thisChart });
        }

        return true;
    },
    InitializeBubbleChart: function(config) {
        if (!BlazorCharts.find(currentChart => currentChart.id === config.canvasId)) {
            let thisChart = initializeChartjsChart2(config);
            BlazorCharts.push({ id: config.canvasId, chart: thisChart });
        }

        return true;
    },
    UpdateLineChart: function(config) {
        if (!BlazorCharts.find(currentChart => currentChart.id === config.canvasId))
            throw `Could not find a chart with the given id. ${config.canvasId}`;

        let myChart = BlazorCharts.find(currentChart => currentChart.id === config.canvasId);

        myChart.chart.destroy();
        myChart.chart = {};
        let newChart = initializeChartjsChart2(config);
        myChart.chart = newChart;

        return true;
    },
    UpdatePieChart: function(config) {
        if (!BlazorCharts.find(currentChart => currentChart.id === config.canvasId))
            throw `Could not find a chart with the given id. ${config.canvasId}`;

        let myChart = BlazorCharts.find(currentChart => currentChart.id === config.canvasId);

        myChart.chart.destroy();
        myChart.chart = {};
        let newChart = initializeChartjsChart2(config);
        myChart.chart = newChart;

        return true;
    },
    UpdateDoughnutChart: function(config) {
        if (!BlazorCharts.find(currentChart => currentChart.id === config.canvasId))
            throw `Could not find a chart with the given id. ${config.canvasId}`;

        let myChart = BlazorCharts.find(currentChart => currentChart.id === config.canvasId);

        myChart.chart.destroy();
        myChart.chart = {};
        let newChart = initializeChartjsChart2(config);
        myChart.chart = newChart;

        return true;
    },
    UpdateBarChart: function(config) {
        if (!BlazorCharts.find(currentChart => currentChart.id === config.canvasId))
            throw `Could not find a chart with the given id. ${config.canvasId}`;

        let myChart = BlazorCharts.find(currentChart => currentChart.id === config.canvasId);

        myChart.chart.destroy();
        myChart.chart = {};
        let newChart = initializeChartjsChart2(config);
        myChart.chart = newChart;

        return true;
    },

    ReloadChart: function(config) {
        if (!BlazorCharts.find(currentChart => currentChart.id === config.canvasId))
            throw `Could not find a chart with the given id. ${config.canvasId}`;

        let myChart = BlazorCharts.find(currentChart => currentChart.id === config.canvasId);

        myChart.chart.destroy();
        myChart.chart = {};
        let newChart = initializeChartjsChart2(config);
        myChart.chart = newChart;

        return true;
    },

    UpdateMixedChart: function(config) {
        if (!BlazorCharts.find(currentChart => currentChart.id === config.canvasId))
            throw `Could not find a chart with the given id. ${config.canvasId}`;

        let myChart = BlazorCharts.find(currentChart => currentChart.id === config.canvasId);

        myChart.chart.destroy();
        myChart.chart = {};
        let newChart = initializeChartjsChart2(config);
        myChart.chart = newChart;

        return true;
    },
    UpdateRadarChart: function(config) {
        if (!BlazorCharts.find(currentChart => currentChart.id === config.canvasId))
            throw `Could not find a chart with the given id. ${config.canvasId}`;

        let myChart = BlazorCharts.find(currentChart => currentChart.id === config.canvasId);

        myChart.chart.destroy();
        myChart.chart = {};
        let newChart = initializeChartjsChart2(config);
        myChart.chart = newChart;

        return true;
    },
    UpdateBubbleChart: function(config) {
        if (!BlazorCharts.find(currentChart => currentChart.id === config.canvasId))
            throw `Could not find a chart with the given id. ${config.canvasId}`;

        let myChart = BlazorCharts.find(currentChart => currentChart.id === config.canvasId);

        myChart.chart.destroy();
        myChart.chart = {};
        let newChart = initializeChartjsChart2(config);
        myChart.chart = newChart;

        return true;
    }
};

function initializeChartjsChart2(config) {
    let ctx = document.getElementById(config.canvasId);
    let myChart = new Chart(ctx, config);

    return myChart;
}