using ChartJs.Blazor.ChartJS.Common;
using ChartJs.Blazor.ChartJS.Common.Enums;

namespace ChartJs.Blazor.ChartJS.MixedChart
{
    public class MixedConfig<TData> : ConfigBase<MixedOptions, MixedData<TData>>
    {
        public MixedConfig() : base(ChartType.Bar) // This is not a mistake
        {
        }
    }
}