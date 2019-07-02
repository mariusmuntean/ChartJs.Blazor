using System;
using ChartJs.Blazor.ChartJS.Common;
using ChartJs.Blazor.ChartJS.Common.Legends;

namespace ChartJs.Blazor.ChartJS.DoughnutChart
{
    public class DoughnutOptions : BaseChartConfigOptions
    {
        /// <summary>
        /// The percentage of the chart that is cut out of the middle.
        /// </summary>
        public int CutoutPercentage { get; set; } = 50;

        public DoughnutAnimation Animation { get; set; }

        /// <summary>
        /// Starting angle to draw arcs from.
        /// </summary>
        public double Rotation { get; set; } = -0.5 * Math.PI;

        /// <summary>
        /// Sweep to allow arcs to cover
        /// </summary>
        public double Circumferences { get; set; } = 2 * Math.PI;
    }
}