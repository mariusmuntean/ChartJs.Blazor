using System.Collections.Generic;

namespace ChartJs.Blazor.ChartJS.MixedChart
{
    public class MixedChartData<TData>
    {
        public List<string> Labels { get; set; } = new List<string>();

        public List<IMixableDataset<TData>> Datasets { get; set; }
    }
}