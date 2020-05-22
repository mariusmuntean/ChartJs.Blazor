using ChartJs.Blazor.ChartJS.Common.Enums;
using ChartJs.Blazor.ChartJS.Common.Handlers;
using ChartJs.Blazor.Util;
using ChartJs.Blazor.Interop;

namespace ChartJs.Blazor.ChartJS.Common.Properties
{
    /// <summary>
    /// The legend label configuration is nested below the legend configuration
    /// </summary>
    public class LegendLabels
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
        /// Gets or sets the callback to generate legend items for a chart.
        /// Default implementation returns the text + styling for the color box.
        /// <para>See <see cref="JavaScriptHandler{T}"/> and <see cref="DelegateHandler{T}"/>.</para>
        /// </summary>
        public IMethodHandler<LegendLabelsGenerator> GenerateLabels { get; set; }

        /// <summary>
        /// Gets or sets the callback to filter legend items out of the legend.
        /// Receives 2 parameters, a <see cref="LegendItem"/> and the chart data. The chart data large so
        /// consider applying a <see cref="IgnoreCallbackValueAttribute"/> if you don't use the value.
        /// <para>See <see cref="JavaScriptHandler{T}"/> and <see cref="DelegateHandler{T}"/>.</para>
        /// </summary>
        public IMethodHandler<LegendLabelFilter> Filter { get; set; }

        /// <summary>
        /// Label style will match corresponding point style (size is based on <see cref="FontSize"/>, <see cref="BoxWidth"/> is not used in this case).
        /// </summary>
        public bool UsePointStyle { get; set; } = false;
    }
}