using ChartJs.Blazor.ChartJS.Common;
using ChartJs.Blazor.ChartJS.Common.Enums;

namespace ChartJs.Blazor.ChartJS.ScatterChart
{
    /// <summary>
    /// Represents the config for a scatter chart.
    /// <para>
    /// Scatter charts are based on basic line charts with the x axis changed to a
    /// <see cref="Common.Axes.LinearCartesianAxis"/> (unless otherwise specified).
    /// Therefore, many configuration options are from the line chart.
    /// </para>
    /// </summary>
    public class ScatterConfig : ConfigBase<LineChart.LineOptions, ScatterData>
    {
        /// <summary>
        /// Creates a new instance of <see cref="ScatterConfig"/>.
        /// </summary>
        public ScatterConfig() : base(ChartType.Scatter) { }
    }
}
