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
    MsTicksCallback: (value, index, values) => value + " ms"
}