using ChartJs.Blazor.ChartJS.Common;
using ChartJs.Blazor.ChartJS.Common.Enums;

namespace ChartJs.Blazor.ChartJS.BarChart
{
    /// <summary>
    /// Config for a bar chart with type safe data
    /// <para>Either 'bar' or 'horizontalBar'</para>
    /// </summary>
    public class BarConfig : ConfigBase<BarOptions, BarData>
    {
        public BarConfig(ChartTypes type = null) : base(type ?? ChartTypes.Bar) { }
    }
}