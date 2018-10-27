var BlazorCharts = [];

Blazor.BlazorCharts = BlazorCharts;
window.ChartJSInterop = {
    
    InitializeChart: function(config) {
        if (!BlazorCharts.find(currentChart => currentChart.id === config.canvasId)) {
            let thisChart = initializeChartjsChart2(config);
            BlazorCharts.push({ id: config.canvasId, chart: thisChart });
        }

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
    
    UpdateChart: function(config) {
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
    let myChart = new Chart(ctx, config);

    return myChart;
}