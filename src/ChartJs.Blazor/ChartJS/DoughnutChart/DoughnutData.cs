using System.Collections.Generic;

namespace ChartJs.Blazor.ChartJS.DoughnutChart
{
    public class DoughnutData
    {
        public List<string> Labels { get; set; }

        public List<DoughnutDataset> Datasets { get; set; }
    }
}