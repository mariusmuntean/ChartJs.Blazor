using ChartJs.Blazor.Common;
using ChartJs.Blazor.Common.Enums;

namespace ChartJs.Blazor.BarChart
{
    /// <summary>
    /// Config for a <see cref="Charts.ChartJsBarChart"/>.
    /// </summary>
    public class BarConfig : ConfigBase<BarOptions>
    {
        /// <summary>
        /// Creates a new instance of the <see cref="BarConfig"/> class.
        /// </summary>
        public BarConfig(ChartType type = null) : base(type ?? ChartType.Bar) { }
    }
}
