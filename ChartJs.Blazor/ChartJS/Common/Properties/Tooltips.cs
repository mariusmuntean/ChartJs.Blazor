using ChartJs.Blazor.ChartJS.Common.Enums;

namespace ChartJs.Blazor.ChartJS.Common.Properties
{
    // TODO: expand (https://www.chartjs.org/docs/latest/configuration/tooltip.html)
    /// <summary>
    /// Defines how tooltips are displayed
    /// </summary>
    public class Tooltips
    {
        /// <summary>
        /// Sets which elements appear in the tooltip. See <see cref="InteractionMode"/> for details.
        /// </summary>
        public InteractionMode Mode { get; set; }

        /// <summary>
        /// If true, the hover mode only applies when the mouse position intersects an item on the chart.
        /// </summary>
        public bool Intersect { get; set; }
    }
}