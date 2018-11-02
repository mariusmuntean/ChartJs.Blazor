using ChartJs.Blazor.ChartJS.Common;

namespace ChartJs.Blazor.ChartJS.RadarChart
{
    public class RadarChartOptions : BaseChartConfigOptions
    {
        public OptionsTitle Title { get; set; }
        public Scale Scale { get; set; }
    }
}