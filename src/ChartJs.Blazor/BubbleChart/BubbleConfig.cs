using ChartJs.Blazor.Common;
using ChartJs.Blazor.Common.Enums;

namespace ChartJs.Blazor.BubbleChart
{
    public class BubbleConfig : ConfigBase<BubbleOptions>
    {
        public BubbleConfig() : base(ChartType.Bubble) { }
    }
}
