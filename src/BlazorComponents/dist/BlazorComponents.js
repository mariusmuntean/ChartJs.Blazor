
var BlazorCharts = [];

Blazor.BlazorCharts = BlazorCharts;
window.BlazorComponents = window.BlazorComponents || {};
window.BlazorComponents.ChartJSInterop = {
    InitializeBarChart: function (data) {
        let thisChart = initializeChartjsChart(data, 'bar');

        if (!BlazorCharts.find(currentChart => currentChart.id === data.canvasId))
            BlazorCharts.push({ id: data.canvasId, chart: thisChart });

        return true;
    },
    InitializeLineChart: function (data) {
        let thisChart = initializeChartjsChart(data, 'line');

        if (!BlazorCharts.find(currentChart => currentChart.id === data.canvasId))
            BlazorCharts.push({ id: data.canvasId, chart: thisChart });

        return true;
    },
    InitializeRadarChart: function (data) {
        let thisChart = initializeChartjsChart(data, 'radar');

        if (!BlazorCharts.find(currentChart => currentChart.id === data.canvasId))
            BlazorCharts.push({ id: data.canvasId, chart: thisChart });

        return true;
    },
    UpdateLineChart: function (data) {
        if (!BlazorCharts.find(currentChart => currentChart.id === data.canvasId))
            throw `Could not find a chart with the given id. ${data.canvasId}`;

        let myChart = BlazorCharts.find(currentChart => currentChart.id === data.canvasId);

        let myChartIndex = BlazorCharts.findIndex(currentChart => currentChart.id === data.canvasId);

        myChart.chart = {};
        let newChart = initializeChartjsChart(data, 'line');
        myChart.chart = newChart;

        return true;
    },
    UpdateBarChart: function (data) {
        if (!BlazorCharts.find(currentChart => currentChart.id === data.canvasId))
            throw `Could not find a chart with the given id. ${data.canvasId}`;

        let myChart = BlazorCharts.find(currentChart => currentChart.id === data.canvasId);

        let myChartIndex = BlazorCharts.findIndex(currentChart => currentChart.id === data.canvasId);

        myChart.chart = {};
        let newChart = initializeChartjsChart(data, 'bar');
        myChart.chart = newChart;

        return true;
    },
    UpdateRadarChart: function (data) {
        if (!BlazorCharts.find(currentChart => currentChart.id === data.canvasId))
            throw `Could not find a chart with the given id. ${data.canvasId}`;

        let myChart = BlazorCharts.find(currentChart => currentChart.id === data.canvasId);

        let myChartIndex = BlazorCharts.findIndex(currentChart => currentChart.id === data.canvasId);

        myChart.chart = {};
        let newChart = initializeChartjsChart(data, 'radar');
        myChart.chart = newChart;

        return true;
    }
};


function initializeChartjsChart(data, type) {
    
    let ctx = document.getElementById(data.canvasId);
    let myChart = new Chart(ctx, {
        type: type,
        data: data.data,
        options: data.options
    });

    return myChart;
}