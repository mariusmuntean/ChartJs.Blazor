using ChartJs.Blazor.ChartJS.Common;
using ChartJs.Blazor.ChartJS.Common.Enums;

namespace ChartJs.Blazor.ChartJS.PolarAreaChart
{
    public class PolarAreaChartConfig : ChartConfigBase<PolarAreaOptions, PolarAreaData>
    {
        public PolarAreaChartConfig() : base(ChartTypes.PolarArea) { }
    }
}