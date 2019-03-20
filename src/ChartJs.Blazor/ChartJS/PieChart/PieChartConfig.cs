using ChartJs.Blazor.ChartJS.Common;

namespace ChartJs.Blazor.ChartJS.PieChart
{
    public class PieChartConfig : ChartConfigBase<PieChartOptions, PieChartData>
    {
        public PieChartConfig() : base(ChartTypes.PIE)
        {
        }
    }
}