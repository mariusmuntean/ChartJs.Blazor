using ChartJs.Blazor.ChartJS.Common;
using ChartJs.Blazor.ChartJS.Common.Enums;

namespace ChartJs.Blazor.ChartJS.RadarChart
{
    public class RadarChartConfig : ChartConfigBase<RadarChartOptions, RadarChartData>
    {
        public RadarChartConfig() : base(ChartTypes.Radar) { }
    }
}