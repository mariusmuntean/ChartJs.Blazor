using System.Collections.Generic;
using ChartJs.Blazor.ChartJS.BarChart.Dataset;
using ChartJs.Blazor.ChartJS.MixedChart;

namespace ChartJs.Blazor.ChartJS.BarChart
{
    public class BarData
    {
        public List<string> Labels { get; set; } = new List<string>();

        // TODO: implement like LineData
        public List<IMixableDataset<object>> Datasets { get; set; }
    }
}
