using ChartJs.Blazor.ChartJS.Common;

namespace ChartJs.Blazor.ChartJS.RadarChart
{
    public class RadarChartOptions
    {
        public RadarChartLegend Legend { get; set; }
        public OptionsTitle Title { get; set; }
        public Scale Scale { get; set; }
        public string Text { get; set; }
        public bool Display { get; set; }
    }
}