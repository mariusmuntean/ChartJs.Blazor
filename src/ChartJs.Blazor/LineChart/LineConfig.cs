using ChartJs.Blazor.Common;
using ChartJs.Blazor.Common.Enums;

namespace ChartJs.Blazor.LineChart
{
    /// <summary>
    /// Represents the config for a line chart.
    /// </summary>
    public class LineConfig : ConfigBase<LineOptions>
    {
        /// <summary>
        /// Creates a new instance of <see cref="LineConfig"/>.
        /// </summary>
        public LineConfig() : base(ChartType.Line) { }
    }
}
