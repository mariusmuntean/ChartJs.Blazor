using ChartJs.Blazor.ChartJS.Common;
using ChartJs.Blazor.ChartJS.Common.Enums;

namespace ChartJs.Blazor.ChartJS.MixedChart
{
    public class MixedChartConfig<TData> : ChartConfigBase<MixedChartOptions, MixedChartData<TData>>
    {
        public MixedChartConfig() : base(ChartTypes.Bar) // This is not a mistake
        {
        }
    }
}