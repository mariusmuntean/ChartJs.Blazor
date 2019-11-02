using ChartJs.Blazor.ChartJS.Common;
using ChartJs.Blazor.ChartJS.Common.Enums;
using ChartJs.Blazor.Util;

namespace ChartJs.Blazor.ChartJS.Common.Axes
{
    /// <summary>
    /// The point labels sub-config of the linear-radial-axis-configuration (see <see cref="LinearRadialAxis"/>).
    /// <para>As per documentation here https://www.chartjs.org/docs/latest/axes/radial/linear.html#point-label-options </para>
    /// </summary>
    public class PointLabels
    {
        /// <summary>
        /// Gets or sets the font color for a point label.
        /// <para>See <see cref="ColorUtil"/> for working with colors.</para>
        /// </summary>
        public IndexableOption<string> FontColor { get; set; }

        /// <summary>
        /// Gets or sets the font size in pixels.
        /// </summary>
        public int FontSize { get; set; } = 10;

        /// <summary>
        /// Gets or sets the font style to use when rendering a point label.
        /// </summary>
        public FontStyle FontStyle { get; set; }

        /// <summary>
        /// Gets or sets the height of an individual line of text.
        /// <para>As per documentation here https://developer.mozilla.org/en-US/docs/Web/CSS/line-height </para>
        /// </summary>
        public double LineHeight { get; set; } = 1.2;
    }
}