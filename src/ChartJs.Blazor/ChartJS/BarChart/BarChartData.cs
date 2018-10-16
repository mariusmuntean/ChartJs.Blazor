using System.Collections.Generic;
using ChartJs.Blazor.ChartJS.BarChart.Dataset;

namespace ChartJs.Blazor.ChartJS.BarChart
{
    public class BarChartData
    {
        public List<string> Labels { get; set; } = new List<string>();

        public List<BaseBarChartDataset> Datasets { get; set; }
    }
}
