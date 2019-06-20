using System.Collections.Generic;

namespace ChartJs.Blazor.ChartJS.PolarAreaChart
{
    public class PolarAreaData
    {
        public List<string> Labels { get; set; }
        public List<PolarAreaDataset> Datasets { get; set; }
    }
}