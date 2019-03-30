using ChartJs.Blazor.ChartJS.Common;

namespace ChartJs.Blazor.ChartJS.PolarAreaChart
{
    public class PolarAreaChartConfig : ChartConfigBase<PolarAreaOptions, PolarAreaData>
    {
        public PolarAreaChartConfig() : base(ChartTypes.POLARAREA)
        {
        }
    }
}