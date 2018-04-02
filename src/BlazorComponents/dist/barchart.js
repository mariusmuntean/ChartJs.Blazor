
var BlazorCharts = [];

Blazor.BlazorCharts = BlazorCharts;

Blazor.registerFunction('initializeBarChart', (data) => {
    data = toCamel(data);
    let ctx = document.getElementById(data.canvasId);
    let myChart = new Chart(ctx, {
        type: 'bar',
        data: data.data,
        options: data.options
    });

    if (!BlazorCharts.find(currentChart => currentChart.id === data.canvasId))
        BlazorCharts.push({ id: data.canvasId, chart: myChart });

    return true;
});

Blazor.registerFunction('initializeLineChart', (data) => {
    data = toCamel(data);
    let ctx = document.getElementById(data.canvasId);
    console.log(data);
    let myChart = new Chart(ctx, {
        type: 'line',
        data: data.data,
        options: data.options
    });

    if (!BlazorCharts.find(currentChart => currentChart.id === data.canvasId))
        BlazorCharts.push({ id: data.canvasId, chart: myChart });

    return true;
});

Blazor.registerFunction('updateLineChart', (data) => {

    data = toCamel(data);
    
    if (!BlazorCharts.find(currentChart => currentChart.id === data.canvasId))
        throw `Could not find a chart with the given id. ${data.canvasId}`;

    let myChart = BlazorCharts.find(currentChart => currentChart.id === data.canvasId)

    myChart.chart.data = data.data;
    myChart.chart.options = data.options;
    
    myChart.chart.update();

    BlazorCharts = BlazorCharts.splice(BlazorCharts.findIndex(currentChart => currentChart.id === data.canvasId), 1);
    BlazorCharts.push({ id: data.canvasId, chart: myChart });
    
    return true;
});

// current JSON utility within Blazor is bare-bone and does not camelCase the response JSON.
// using the below snippet to perform camelCasing.
// source: https://stackoverflow.com/questions/12931828/convert-returned-json-object-properties-to-lower-first-camelcase/12932771
function toCamel(o) {
    var newO, origKey, newKey, value
    if (o instanceof Array) {
        return o.map(function (value) {
            if (typeof value === "object") {
                value = toCamel(value)
            }
            return value
        })
    } else {
        newO = {}
        for (origKey in o) {
            if (o.hasOwnProperty(origKey)) {
                newKey = (origKey.charAt(0).toLowerCase() + origKey.slice(1) || origKey).toString()
                value = o[origKey]
                if (value instanceof Array || (value !== null && value.constructor === Object)) {
                    value = toCamel(value)
                }
                newO[newKey] = value
            }
        }
    }
    return newO
}