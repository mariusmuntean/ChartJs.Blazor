using ChartJs.Blazor.ChartJS.Common;
using ChartJs.Blazor.ChartJS.Common.Enums;

namespace ChartJs.Blazor.ChartJS.DoughnutChart
{
    /// <summary>
    /// Config for a <see cref="DoughnutChartConfig"/>.
    /// </summary>
    public class DoughnutChartConfig : ChartConfigBase<DoughnutChartOptions, DoughnutChartData>
    {
        /// <summary>
        /// Creates a new instance of <see cref="DoughnutChartConfig"/>.
        /// </summary>
        public DoughnutChartConfig() : base(ChartTypes.Doughnut)
        {
        }
    }
}