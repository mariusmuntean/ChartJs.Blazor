using ChartJs.Blazor.ChartJS.BarChart;
using ChartJs.Blazor.ChartJS.Common;

namespace ChartJs.Blazor.ChartJS.BubbleChart
{
    public class BubbleChartConfig : ChartConfigBase<BarChartOptions, BarChartData>
    {
        public BubbleChartConfig() : base(ChartTypes.BUBBLE)
        {
        }
    }
}