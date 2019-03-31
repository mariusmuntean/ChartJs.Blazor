using ChartJs.Blazor.ChartJS.Common;

namespace ChartJs.Blazor.ChartJS.BubbleChart
{
    public class BubbleChartConfig : ChartConfigBase<BubbleChartOptions, BubbleChartData>
    {
        public BubbleChartConfig() : base(ChartTypes.BUBBLE)
        {
        }
    }
}