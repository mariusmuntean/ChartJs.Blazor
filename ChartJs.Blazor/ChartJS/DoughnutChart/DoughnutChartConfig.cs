using ChartJs.Blazor.ChartJS.Common;
using ChartJs.Blazor.ChartJS.Common.Enums;

namespace ChartJs.Blazor.ChartJS.DoughnutChart
{
    public class DoughnutChartConfig : ChartConfigBase<DoughnutOptions, DoughnutData>
    {
        public DoughnutChartConfig() : base(ChartTypes.Doughnut) { }
    }
}