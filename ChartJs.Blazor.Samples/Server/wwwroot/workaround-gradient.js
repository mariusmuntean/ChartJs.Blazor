window.workaroundGradient = function (canvasId) {
    let canvas = document.getElementById(canvasId);
    let ctx = canvas.getContext("2d");
    let gradient = ctx.createLinearGradient(0, 0, 0, canvas.clientHeight);
        gradient.addColorStop(0, 'rgba(250,174,50,1)');
        gradient.addColorStop(1, 'rgba(250,174,50,0)');

    let chart = window.ChartJsInterop.BlazorCharts.get(canvasId);
    let datasets = chart.config.data.datasets;
    for (let dataset of datasets) {
        dataset.backgroundColor = gradient;
    }
}
