using ChartJs.Blazor.ChartJS.Common;
using ChartJs.Blazor.ChartJS.Common.Enums;

namespace ChartJs.Blazor.ChartJS.PieChart
{
    public class PieChartConfig : ChartConfigBase<PieChartOptions, PieChartData>
    {
        public PieChartConfig() : base(ChartTypes.Pie) { }
    }
}