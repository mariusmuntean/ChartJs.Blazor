
namespace ChartJs.Blazor.ChartJS.DoughnutChart
{
    using ChartJs.Blazor.ChartJS.Common;
    using ChartJs.Blazor.ChartJS.Common.Enums;

    /// <summary>
    /// Config for a <see cref="DoughnutChartConfig"/>.
    /// </summary>
    public class DoughnutChartConfig : ChartConfigBase<DoughnutOptions, DoughnutData>
    {
        /// <summary>
        /// Creates a new instance of <see cref="DoughnutChartConfig"/>.
        /// </summary>
        public DoughnutChartConfig() : base(ChartTypes.Doughnut) { }
    }
}