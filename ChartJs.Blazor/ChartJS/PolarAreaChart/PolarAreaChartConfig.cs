using ChartJs.Blazor.ChartJS.Common;
using ChartJs.Blazor.ChartJS.Common.Enums;
using ChartJs.Blazor.Charts;

namespace ChartJs.Blazor.ChartJS.PolarAreaChart
{
    /// <summary>
    /// Config for a <see cref="ChartJsPolarAreaChart"/>
    /// </summary>
    public class PolarAreaChartConfig : ChartConfigBase<PolarAreaOptions, PolarAreaData>
    {
        /// <summary>
        /// Creates a new instance of <see cref="PolarAreaChartConfig"/>
        /// </summary>
        public PolarAreaChartConfig() : base(ChartTypes.PolarArea)
        {
        }
    }
}