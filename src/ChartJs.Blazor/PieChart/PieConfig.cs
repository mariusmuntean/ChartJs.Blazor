using ChartJs.Blazor.Common;
using ChartJs.Blazor.Common.Enums;

namespace ChartJs.Blazor.PieChart
{
    /// <summary>
    /// Config for a <see cref="PieConfig"/>.
    /// </summary>
    public class PieConfig : ConfigBase<PieOptions>
    {
        /// <summary>
        /// Creates a new instance of <see cref="PieConfig"/>.
        /// </summary>
        public PieConfig() : base(ChartType.Pie)
        {
        }
    }
}
