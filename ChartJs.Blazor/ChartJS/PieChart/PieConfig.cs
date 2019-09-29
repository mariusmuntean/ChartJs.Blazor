using ChartJs.Blazor.ChartJS.Common;
using ChartJs.Blazor.ChartJS.Common.Enums;

namespace ChartJs.Blazor.ChartJS.PieChart
{
    /// <summary>
    /// Config for a <see cref="PieConfig"/>.
    /// </summary>
    public class PieConfig : ConfigBase<PieOptions, PieData>
    {
        /// <summary>
        /// Creates a new instance of <see cref="PieConfig"/>.
        /// </summary>
        public PieConfig() : base(ChartType.Pie)
        {
        }
    }
}