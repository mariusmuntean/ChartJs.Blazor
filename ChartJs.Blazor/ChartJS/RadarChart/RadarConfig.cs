using ChartJs.Blazor.ChartJS.Common;
using ChartJs.Blazor.ChartJS.Common.Enums;

namespace ChartJs.Blazor.ChartJS.RadarChart
{
    public class RadarConfig : ConfigBase<RadarOptions, RadarData>
    {
        public RadarConfig() : base(ChartType.Radar) { }
    }
}