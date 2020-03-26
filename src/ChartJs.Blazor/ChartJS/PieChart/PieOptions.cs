using System;
using ChartJs.Blazor.ChartJS.Common;
using ChartJs.Blazor.ChartJS.Common.Properties;

namespace ChartJs.Blazor.ChartJS.PieChart
{
    /// <summary>
    /// The options-subconfig of a <see cref="PieConfig"/>.
    /// </summary>
    public class PieOptions : BaseConfigOptions
    {
        /// <summary>
        /// Creates a new instance of <see cref="PieOptions"/>
        /// </summary>
        /// <param name="doughnutCutout">If true, the start-value for <see cref="CutoutPercentage"/> will be 50 (default for Doughnut) instead of 0 (default for Pie).</param>
        public PieOptions(bool doughnutCutout = false)
        {
            if (doughnutCutout) CutoutPercentage = 50;
        }

        /// <summary>
        /// Gets or sets the percentage of the chart that is cut out of the middle.
        /// <para>Default for Pie is 0, Default for Doughnut is 50. See constructor-parameter.</para>
        /// </summary>
        public int CutoutPercentage { get; set; } = 0;

        /// <summary>
        /// Gets or sets the animation-configuration for this chart.
        /// </summary>
        public new ArcAnimation Animation { get; set; }

        /// <summary>
        /// Gets or sets the starting angle to draw arcs from.
        /// </summary>
        public double Rotation { get; set; } = -0.5 * Math.PI;

        /// <summary>
        /// Gets or sets the sweep to allow arcs to cover.
        /// </summary>
        public double Circumference { get; set; } = 2 * Math.PI;
    }
}