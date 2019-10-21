using ChartJs.Blazor.Util;
using ChartJs.Blazor.ChartJS.Common.Enums;

namespace ChartJs.Blazor.ChartJS.Common.Axes.Ticks
{
    /// <summary>
    /// The ticks-subconfig of the axis-configuration (see <see cref="Axis"/>).
    /// <para>As per documentation here https://www.chartjs.org/docs/latest/axes/styling.html#tick-configuration </para>
    /// </summary>
    public abstract class Ticks
    {
        /// <summary>
        /// Gets or sets the value indicating whether this shows <see cref="Ticks"/> marks.
        /// </summary>
        public bool Display { get; set; } = true;

        /// <summary>
        /// Gets or sets the font color for <see cref="Ticks"/> labels.
        /// <para>See <see cref="ColorUtil"/> for working with colors.</para>
        /// </summary>
        public string FontColor { get; set; }

        /// <summary>
        /// Gets or sets the font family for the <see cref="Ticks"/> labels.
        /// </summary>
        public string FontFamily { get; set; }

        /// <summary>
        /// Gets or sets the font size for the <see cref="Ticks"/> labels.
        /// </summary>
        public int FontSize { get; set; } = 12;

        /// <summary>
        /// Gets or sets the font style for the <see cref="Ticks"/> labels.
        /// </summary>
        public FontStyle FontStyle { get; set; }

        /// <summary>
        /// Gets or sets the height of an individual line of text.
        /// <para>As per documentation here https://developer.mozilla.org/en-US/docs/Web/CSS/line-height </para>
        /// </summary>
        public double LineHeight { get; set; } = 1.2;

        /// <summary>
        /// Gets or sets the value indicating whether the order of <see cref="Ticks"/> labels is reversed.
        /// </summary>
        public bool Reverse { get; set; } = false;

        /// <summary>
        /// Gets or sets the minor ticks configuration. Omitted options are inherited from options above (see <see cref="Ticks"/>).
        /// </summary>
        public MinorTicks Minor { get; set; }

        /// <summary>
        /// Gets or sets the major ticks configuration. Omitted options are inherited from options above (see <see cref="Ticks"/>).
        /// </summary>
        public MajorTicks Major { get; set; }

        /// <summary>
        /// Gets or sets the offset of the tick labels from the axis
        /// </summary>
        public int Padding { get; set; } = 0;
    }
}