using System.Collections.Generic;

namespace ChartJs.Blazor.ChartJS.PieChart
{
    public class PieChartData
    {
        public List<string> Labels { get; set; }

        public List<PieChartDataset> Datasets { get; set; } 
    }
}