using ChartJs.Blazor.Common;
using ChartJs.Blazor.Common.Enums;

namespace ChartJs.Blazor.BubbleChart
{
    /// <summary>
    /// Represents the config for a bubble chart.
    /// </summary>
    public class BubbleConfig : ConfigBase<BubbleOptions>
    {
        /// <summary>
        /// Creates a new instance of <see cref="BubbleConfig"/>.
        /// </summary>
        public BubbleConfig() : base(ChartType.Bubble) { }
    }
}
