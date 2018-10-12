using System.Collections.Generic;

namespace ChartJs.Blazor.ChartJS.BarChart
{
    public class BarChartData
    {
        public List<string> Labels { get; set; } = new List<string>();

        public List<BarChartDataset> Datasets { get; set; }
    }
}
