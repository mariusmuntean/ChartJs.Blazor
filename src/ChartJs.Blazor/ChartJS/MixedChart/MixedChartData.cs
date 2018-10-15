using System.Collections.Generic;

namespace ChartJs.Blazor.ChartJS.MixedChart
{
    public class MixedChartData
    {
        public List<string> Labels { get; set; } = new List<string>();

        public List<IMixableDataset> Datasets { get; set; }
    }
}