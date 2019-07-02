using ChartJs.Blazor.ChartJS.MixedChart;
using System;
using System.Collections.Generic;

namespace ChartJs.Blazor.ChartJS.LineChart
{
    public class LineChartData
    {
        public LineChartData()
        {
            Labels = new List<string>();
            Datasets = new HashSet<IMixableDataset<object>>();
        }

        public LineChartData(List<string> labels, HashSet<IMixableDataset<object>> datasets)
        {
            if (labels == null) throw new ArgumentNullException(nameof(labels));
            if (datasets == null) throw new ArgumentNullException(nameof(datasets));

            if (labels.Count != datasets.Count) throw new ArgumentException("The amount of labels has to be the same as the amount of datasets.");

            Labels = labels;
            Datasets = datasets;
        }

        public List<string> Labels { get; }
        public HashSet<IMixableDataset<object>> Datasets { get; }
    }
}