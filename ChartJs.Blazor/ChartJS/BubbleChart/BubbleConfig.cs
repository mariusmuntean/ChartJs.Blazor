using ChartJs.Blazor.ChartJS.Common;
using ChartJs.Blazor.ChartJS.Common.Enums;

namespace ChartJs.Blazor.ChartJS.BubbleChart
{
    public class BubbleConfig : ConfigBase<BubbleOptions, BubbleData>
    {
        public BubbleConfig() : base(ChartType.Bubble) { }
    }
}