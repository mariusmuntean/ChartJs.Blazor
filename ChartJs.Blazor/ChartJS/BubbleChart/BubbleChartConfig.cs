using ChartJs.Blazor.ChartJS.Common;
using ChartJs.Blazor.ChartJS.Common.Enums;

namespace ChartJs.Blazor.ChartJS.BubbleChart
{
    public class BubbleChartConfig : ChartConfigBase<BubbleChartOptions, BubbleChartData>
    {
        public BubbleChartConfig() : base(ChartTypes.Bubble) { }
    }
}