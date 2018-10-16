using System;
using ChartJs.Blazor.ChartJS.Common;

namespace ChartJs.Blazor.ChartJS.PieChart
{
    public class PieChartOptions : BaseChartConfigOptions
    {
        /// <summary>
        /// The percentage of the chart that is cut out of the middle.
        /// </summary>
        public int CutoutPercentage { get; set; } = 0;

        /// <summary>
        /// Starting angle to draw arcs from.
        /// </summary>
        public double Rotation { get; set; } = -0.5 * Math.PI;

        /// <summary>
        /// Sweep to allow arcs to cover
        /// </summary>
        public double Circumference { get; set; } = 2 * Math.PI;

        public DoughnutAnimation Animation { get; set; }
    }
}