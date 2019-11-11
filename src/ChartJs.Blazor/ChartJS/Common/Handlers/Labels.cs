using ChartJs.Blazor.ChartJS.Common.Enums;
using ChartJs.Blazor.Util;

namespace ChartJs.Blazor.ChartJS.Common.Handlers
{
    /// <summary>
    /// The legend label configuration is nested below the legend configuration
    /// </summary>
    public class LegendLabelConfiguration
    {
        /// <summary>
        /// width of colored box
        /// </summary>
        public int BoxWidth { get; set; } = 40;

        /// <summary>
        /// Font size of text
        /// </summary>
        public int FontSize { get; set; } = 12;

        /// <summary>
        /// Gets or sets the font style for the labels text.
        /// </summary>
        public FontStyle FontStyle { get; set; }

        /// <summary>
        /// Color of text.
        /// <para>See <see cref="ColorUtil"/> for working with colors.</para>
        /// </summary>
        public string FontColor { get; set; } = ColorUtil.ColorHexString(102, 102, 102);

        /// <summary>
        /// Padding between rows of colored boxes.
        /// </summary>
        public int Padding { get; set; } = 10;

        /// <summary>
        /// Generates legend items for each thing in the legend. Default implementation returns the text + styling for the color box. See Legend Item for details.
        /// <para> See Legend Item: http://www.chartjs.org/docs/latest/configuration/legend.html#legend-item-interface </para>
        /// </summary>
        public string GenerateLabels { get; set; }

        /// <summary>
        /// Filters legend items out of the legend. Receives 2 parameters, a Legend Item and the chart data.
        /// </summary>
        public string Filter { get; set; }

        /// <summary>
        /// Label style will match corresponding point style (size is based on <see cref="FontSize"/>, <see cref="BoxWidth"/> is not used in this case).
        /// </summary>
        public bool UsePointStyle { get; set; } = false;
    }
}