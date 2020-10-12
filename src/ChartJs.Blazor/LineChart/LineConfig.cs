using ChartJs.Blazor.Common;
using ChartJs.Blazor.Common.Enums;

namespace ChartJs.Blazor.LineChart
{
    /// <summary>
    /// Config for a <see cref="Charts.ChartJsLineChart"/>
    /// </summary>
    public class LineConfig : ConfigBase<LineOptions, ChartData>
    {
        /// <summary>
        /// Creates a new instance of <see cref="LineConfig"/>
        /// </summary>
        public LineConfig() : base(ChartType.Line) { }
    }
}
