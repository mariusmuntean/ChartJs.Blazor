using ChartJs.Blazor.ChartJS.Common;

namespace ChartJs.Blazor.ChartJS.MixedChart
{
    public class MixedChartConfig : ChartConfigBase<MixedChartOptions, MixedChartData>
    {
        public MixedChartConfig() : base(ChartTypes.BAR) // This is not a mistake
        {
        }
    }
}