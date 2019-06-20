using ChartJs.Blazor.ChartJS.Common;

namespace ChartJs.Blazor.ChartJS.RadarChart
{
    public class RadarChartConfig : ChartConfigBase<RadarChartOptions, RadarChartData>
    {
        public RadarChartConfig() : base(ChartTypes.RADAR)
        {
        }
    }
}