using ChartJs.Blazor.ChartJS.Common.Axes.Ticks;

namespace ChartJs.Blazor.ChartJS.Common.Axes
{
    /// <summary>
    /// A linear radial axis.
    /// <para>As per documentation here https://www.chartjs.org/docs/latest/axes/radial/linear.html.</para>
    /// </summary>
    public class LinearRadialAxis
    {
        /// <summary>
        /// Gets or sets the angle lines configuration.
        /// <para>As per documentation here https://www.chartjs.org/docs/latest/axes/radial/linear.html#angle-line-options </para>
        /// </summary>
        public AngleLines AngleLines { get; set; }

        /// <summary>
        /// Gets or sets the grid lines configuration.
        /// <para>As per documentation here https://www.chartjs.org/docs/latest/axes/styling.html#grid-line-configuration </para>
        /// </summary>
        public GridLines GridLines { get; set; }

        /// <summary>
        /// Gets or sets the point labels configuration.
        /// <para>As per documentation here https://www.chartjs.org/docs/latest/axes/radial/linear.html#point-label-options </para>
        /// </summary>
        public PointLabels PointLabels { get; set; }

        /// <summary>
        /// Gets or sets the ticks configuration.
        /// <para>As per documentation here https://www.chartjs.org/docs/latest/axes/radial/linear.html#tick-options </para>
        /// </summary>
        public LinearRadialTicks Ticks { get; set; }
    }
}