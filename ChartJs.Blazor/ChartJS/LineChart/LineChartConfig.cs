using ChartJs.Blazor.ChartJS.Common;
using ChartJs.Blazor.ChartJS.Common.Enums;

namespace ChartJs.Blazor.ChartJS.LineChart
{
    /// <summary>
    /// Config for a LineChart
    /// </summary>
    public class LineChartConfig : ChartConfigBase<LineChartOptions, LineChartData>
    {
        /// <summary>
        /// Creates a new instance of <see cref="LineChartConfig"/>
        /// </summary>
        public LineChartConfig() : base(ChartTypes.Line) { }
    }
}