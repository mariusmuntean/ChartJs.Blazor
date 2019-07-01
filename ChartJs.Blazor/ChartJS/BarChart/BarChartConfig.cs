using ChartJs.Blazor.ChartJS.Common;
using ChartJs.Blazor.ChartJS.Common.Enums;

namespace ChartJs.Blazor.ChartJS.BarChart
{
    /// <summary>
    /// Config for a bar chart with typesafe data
    /// <para>Either 'bar' or 'horizontalBar'</para>
    /// </summary>
    public class BarChartConfig : ChartConfigBase<BarChartOptions, BarChartData>
    {
        public BarChartConfig(ChartTypes type = null) : base(type ?? ChartTypes.Bar) { }
    }
}