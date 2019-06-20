using System.Collections.Generic;

namespace ChartJs.Blazor.ChartJS.RadarChart
{
    public class RadarChartData
    {
        public List<string> Labels { get; set; }
        public List<RadarChartDataset> Datasets { get; set; }   
    }
}