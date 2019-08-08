using ChartJs.Blazor.ChartJS.Common;
using ChartJs.Blazor.ChartJS.Common.Enums;

namespace ChartJs.Blazor.ChartJS.PieChart
{
    /// <summary>
    /// Config for a <see cref="PieChartConfig"/>.
    /// </summary>
    public class PieChartConfig : ChartConfigBase<PieChartOptions, PieChartData>
    {
        /// <summary>
        /// Creates a new instance of <see cref="PieChartConfig"/>.
        /// </summary>
        public PieChartConfig() : base(ChartTypes.Pie)
        {
        }
    }
}