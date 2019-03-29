
window.SampleFunctions = {
    GetElementValue: function(element) {
        return element.value;
    },
    CustomOnHoverFunc: function(event, item) {
        console.log(event);
        console.log(item);
    },
    HideOtherDatasetsFunc: function(e, legendItem) {
        var index = legendItem.datasetIndex;
        var ci = this.chart;

        for (var i = 0; i < ci.config.data.datasets.length; i++) {

            if (i !== index) {
                var meta = ci.getDatasetMeta(i);
                meta.hidden = meta.hidden === null ? !ci.data.datasets[i].hidden : null;
            }
        }

        // We hid a some datasets ... re-render the chart
        ci.update();
    }
};