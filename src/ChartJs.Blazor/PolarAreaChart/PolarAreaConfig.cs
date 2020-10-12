using ChartJs.Blazor.Common;
using ChartJs.Blazor.Common.Enums;

namespace ChartJs.Blazor.PolarAreaChart
{
    /// <summary>
    /// Config for a <see cref="ChartJsPolarAreaChart"/>
    /// </summary>
    public class PolarAreaConfig : ConfigBase<PolarAreaOptions>
    {
        /// <summary>
        /// Creates a new instance of <see cref="PolarAreaConfig"/>
        /// </summary>
        public PolarAreaConfig() : base(ChartType.PolarArea)
        {
        }
    }
}
