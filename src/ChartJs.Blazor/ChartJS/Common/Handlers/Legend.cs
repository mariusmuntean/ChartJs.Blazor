using ChartJs.Blazor.ChartJS.Common.Enums;
using ChartJs.Blazor.ChartJS.Common.Handlers.OnClickHandler;
using ChartJs.Blazor.ChartJS.Common.Handlers.OnHover;

namespace ChartJs.Blazor.ChartJS.Common.Handlers
{
    /// <summary>
    /// The chart legend displays data about the datasets that are appearing on the chart.
    /// <para>Link: http://www.chartjs.org/docs/latest/configuration/legend.html </para>
    /// </summary>
    public class Legend
    {
        /// <summary>
        /// Determines if the legend is displayed
        /// </summary>
        public bool Display { get; set; } = true;

        /// <summary>
        /// Position of the legend
        /// </summary>
        public Position Position { get; set; } = Position.Top;

        /// <summary>
        /// Marks that this box should take the full width of the canvas (pushing down other boxes). This is unlikely to need to be changed in day-to-day use.
        /// </summary>
        public bool FullWidth { get; set; } = true;

        /// <summary>
        /// The callback that is called when a click event is registered on a label item.
        /// <para>See <see cref="DotNetInstanceClickHandler"></see>, <see cref="DotNetStaticClickHandler"></see> and <see cref="JsClickHandler"></see></para>
        /// </summary>
        public IClickHandler OnClick { get; set; }

        /// <summary>
        /// The callback that is called when a 'mousemove' event is registered on top of a label item
        /// <para>See <see cref="DotNetInstanceHoverHandler"></see>, <see cref="DotNetStaticHoverHandler"></see> and <see cref="JsHoverHandler"></see></para>
        /// </summary>
        public IHoverHandler OnHover { get; set; }

        /// <summary>
        /// Legend will show datasets in reverse order.
        /// </summary>
        public bool Reverse { get; set; } = false;

        /// <summary>
        /// Configuration options for the legend-labels
        /// </summary>
        public LegendLabelConfiguration Labels { get; set; } = new LegendLabelConfiguration();
    }
}