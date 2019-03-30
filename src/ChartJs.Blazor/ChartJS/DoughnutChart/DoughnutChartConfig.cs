using ChartJs.Blazor.ChartJS.Common;

namespace ChartJs.Blazor.ChartJS.DoughnutChart
{
    public class DoughnutChartConfig : ChartConfigBase<DoughnutOptions, DoughnutData>
    {
        public DoughnutChartConfig() : base(ChartTypes.DOUGHNUT)
        {
        }
    }
}