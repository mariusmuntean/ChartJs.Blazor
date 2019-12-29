window.SampleInterop = {

    PrintEventAndArgs: function (event, args) {
        console.log("event: ");
        console.log(event);
        console.log("args: ");
        console.log(args)
    },

    CreateLabels: chart => {
        let labels = Chart.defaults.pie.legend.labels.generateLabels(chart);
        for (var i = 0; i < labels.length; i++) {
            labels[i].lineWidth *= 2;
            labels[i].text += ' [from callback]';
        }

        return labels;
    },

    Filter: (item, chart) => {
        let result = item.index % 3 !== 0;

        console.log(typeof result);
        console.log(result);

        return result;
    },
    AsyncFilter: (item, chart) => new Promise((resolve, reject) => resolve(false))
}