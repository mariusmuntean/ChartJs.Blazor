using ChartJs.Blazor.ChartJS.Common.Enums;
using ChartJs.Blazor.Util;

namespace ChartJs.Blazor.ChartJS.Common.Properties
{
    /// <summary>
    /// The title-subconfig of <see cref="BaseConfigOptions"/>. Specifies how the chart title is displayed.
    /// </summary>
    public class OptionsTitle
    {
        /// <summary>
        /// Gets or sets a value indicating whether the title should be displayed or not.
        /// </summary>
        public bool Display { get; set; }

        /// <summary>
        /// Gets or sets the position of the title.
        /// </summary>
        public Position Position { get; set; }

        /// <summary>
        /// Gets or sets the font size for the title text.
        /// </summary>
        public int FontSize { get; set; } = 12;

        /// <summary>
        /// Gets or sets the font family for the title text.
        /// </summary>
        public string FontFamily { get; set; }

        /// <summary>
        /// Gets or sets the font color for the title text.
        /// <para>See <see cref="ColorUtil"/> for working with colors.</para>
        /// </summary>
        public string FontColor { get; set; }

        /// <summary>
        /// Gets or sets the font style for the title text.
        /// </summary>
        public FontStyle FontStyle { get; set; }

        /// <summary>
        /// Gets or sets the number of pixels to add above and below the title text.
        /// </summary>
        public int Padding { get; set; } = 10;

        /// <summary>
        /// Gets or sets the height of an individual line of text.
        /// <para>As per documentation here https://developer.mozilla.org/en-US/docs/Web/CSS/line-height </para>
        /// </summary>
        public double LineHeight { get; set; } = 1.2;

        /// <summary>
        /// Gets or sets the title text to display. If specified as an array, text is rendered on multiple lines.
        /// </summary>
        public IndexableOption<string> Text { get; set; }
    }
}