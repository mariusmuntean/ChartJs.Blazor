using System.Collections.Generic;

namespace ChartJs.Blazor.ChartJS.RadarChart
{
    public class RadarData
    {
        public List<string> Labels { get; set; }

        public List<RadarDataset> Datasets { get; set; }   
    }
}