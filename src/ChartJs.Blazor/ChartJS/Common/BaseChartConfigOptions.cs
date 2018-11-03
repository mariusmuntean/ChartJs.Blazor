using ChartJs.Blazor.Util.Color;

namespace ChartJs.Blazor.ChartJS.Common
{
    public class BaseChartConfigOptions
    {
        public string Text { get; set; }
        public bool Display { get; set; }
        public bool Responsive { get; set; }

        public Legend Legend { get; set; } = new Legend();
    }

    /// <summary>
    /// The chart legend displays data about the datasets that are appearing on the chart.
    /// <para>Link: http://www.chartjs.org/docs/latest/configuration/legend.html </para>
    /// </summary>
    public class Legend
    {
        /// <summary>
        /// is the legend shown
        /// </summary>
        public bool Display { get; set; } = true;

        /// <summary>
        /// Position of the legend
        /// </summary>
        public string Position { get; set; } = LegendPosition.TOP.ToString();

        /// <summary>
        /// Marks that this box should take the full width of the canvas (pushing down other boxes). This is unlikely to need to be changed in day-to-day use.
        /// </summary>
        public bool FullWidth { get; set; } = true;

        /// <summary>
        /// The name of a callback that is called when a click event is registered on a label item.
        /// <para>E.g. "MyProjectNamespace.MyOnClickFunctionName" </para>
        /// </summary>
        public string OnClick { get; set; }

        /// <summary>
        /// The name of a callback that is called when a 'mousemove' event is registered on top of a label item
        /// <para> E.g. "MyProjectNamespace.MyOnHoverFuncName" </para>
        /// </summary>
        public string OnHover { get; set; }

        /// <summary>
        /// Legend will show datasets in reverse order.
        /// </summary>
        public bool Reverse { get; set; } = false;

        public Labels Labels { get; set; } = new Labels();
    }

    /// <summary>
    /// The legend label configuration is nested below the legend configuration
    /// </summary>
    public class Labels
    {
        /// <summary>
        /// width of coloured box
        /// </summary>
        public int BoxWidth { get; set; } = 40;

        /// <summary>
        /// Font size of text
        /// </summary>
        public int FontSize { get; set; } = 12;

        /// <summary>
        /// Font style of text.
        ///
        /// <para>Supported fonts: http://www.chartjs.org/docs/latest/configuration/legend.html#legend-label-configuration </para>
        /// </summary>
        public string FontStyle { get; set; } = "normal";

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
        /// <para> See Legend Item: <see cref="http://www.chartjs.org/docs/latest/configuration/legend.html#legend-item-interface"/>  </para>
        /// </summary>
        //public object GenerateLabels { get; set; }

        ///
        /// Filters legend items out of the legend. Receives 2 parameters, a Legend Item and the chart data.
        ///
        //public object Filter { get; set; }

        /// <summary>
        ///Label style will match corresponding point style (size is based on fontSize, boxWidth is not used in this case).
        /// </summary>
        public bool UsePointStyle { get; set; } = false;
    }
}