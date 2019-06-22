using ChartJs.Blazor.ChartJS.Common;
using ChartJs.Blazor.ChartJS.Common.Enums;

namespace ChartJs.Blazor.ChartJS.BarChart
{
    /// <summary>
    /// Config for a bar chart with mixed data
    /// <para>Either 'bar' or 'horizontalBar'</para>
    /// </summary>
    public class BarChartConfigMixed : BarChartConfig<object> { }

    /// <summary>
    /// Config for a bar chart with typesafe data
    /// <para>Either 'bar' or 'horizontalBar'</para>
    /// </summary>
    /// <typeparam name="TData">Defines the type of data in the bar chart</typeparam>
    public class BarChartConfig<TData> : ChartConfigBase<BarChartOptions, BarChartData<TData>>
    {
        public BarChartConfig(ChartTypes type = null) : base(type ?? ChartTypes.Bar) { }
    }
}