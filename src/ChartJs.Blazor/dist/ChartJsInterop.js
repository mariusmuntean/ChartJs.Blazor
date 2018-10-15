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
    InitializePieChart: function(data) {
        if (!BlazorCharts.find(currentChart => currentChart.id === data.canvasId)) {
            let thisChart = initializeChartjsChart(data, 'pie');
            BlazorCharts.push({ id: data.canvasId, chart: thisChart });
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
    InitializeRadarChart: function(data) {
        if (!BlazorCharts.find(currentChart => currentChart.id === data.canvasId)) {
            let thisChart = initializeChartjsChart(data, 'radar');
            BlazorCharts.push({ id: data.canvasId, chart: thisChart });
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
    UpdatePieChart: function(data) {
        if (!BlazorCharts.find(currentChart => currentChart.id === data.canvasId))
            throw `Could not find a chart with the given id. ${data.canvasId}`;

        let myChart = BlazorCharts.find(currentChart => currentChart.id === data.canvasId);

        myChart.chart.destroy();
        myChart.chart = {};
        let newChart = initializeChartjsChart(data, 'pie');
        myChart.chart = newChart;

        return true;
    },
    UpdateDoughnutChart: function(config) {
        if (!BlazorCharts.find(currentChart => currentChart.id === config.canvasId))
            throw `Could not find a chart with the given id. ${data.canvasId}`;

        let myChart = BlazorCharts.find(currentChart => currentChart.id === config.canvasId);

        myChart.chart.destroy();
        myChart.chart = {};
        let newChart = initializeChartjsChart2(config);
        myChart.chart = newChart;

        return true;
    },
    UpdateBarChart: function(config) {
        if (!BlazorCharts.find(currentChart => currentChart.id === config.canvasId))
            throw `Could not find a chart with the given id. ${data.canvasId}`;

        let myChart = BlazorCharts.find(currentChart => currentChart.id === config.canvasId);

        myChart.chart.destroy();
        myChart.chart = {};
        let newChart = initializeChartjsChart2(config);
        myChart.chart = newChart;

        return true;
    },

    ReloadChart: function(config) {
        if (!BlazorCharts.find(currentChart => currentChart.id === config.canvasId))
            throw `Could not find a chart with the given id. ${data.canvasId}`;

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
    UpdateRadarChart: function(data) {
        if (!BlazorCharts.find(currentChart => currentChart.id === data.canvasId))
            throw `Could not find a chart with the given id. ${data.canvasId}`;

        let myChart = BlazorCharts.find(currentChart => currentChart.id === data.canvasId);

        myChart.chart.destroy();
        myChart.chart = {};
        let newChart = initializeChartjsChart(data, 'radar');
        myChart.chart = newChart;

        return true;
    },
    UpdateBubbleChart: function(data) {
        if (!BlazorCharts.find(currentChart => currentChart.id === data.canvasId))
            throw `Could not find a chart with the given id. ${data.canvasId}`;

        let myChart = BlazorCharts.find(currentChart => currentChart.id === data.canvasId);

        myChart.chart.destroy();
        myChart.chart = {};
        let newChart = initializeChartjsChart(data, 'bubble');
        myChart.chart = newChart;

        return true;
    },
};

function initializeChartjsChart(data, type) {
    let ctx = document.getElementById(data.canvasId);
    let myChart = new Chart(ctx,
        {
            type: type,
            data: data.data,
            options: data.options
        });

    return myChart;
}

function initializeChartjsChart2(config) {
    let ctx = document.getElementById(config.canvasId);
    let myChart = new Chart(ctx, config);

    return myChart;
}