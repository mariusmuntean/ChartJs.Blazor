using ChartJs.Blazor.ChartJS.Common;
using ChartJs.Blazor.ChartJS.Common.Enums;

namespace ChartJs.Blazor.ChartJS.LineChart
{
    /// <summary>
    /// Config for a <see cref="Charts.ChartJsLineChart"/>
    /// </summary>
    public class LineConfig : ConfigBase<LineOptions, LineData>
    {
        /// <summary>
        /// Creates a new instance of <see cref="LineConfig"/>
        /// </summary>
        public LineConfig() : base(ChartType.Line) { }
    }
}