using ChartJs.Blazor.ChartJS.Common.Enums;
using ChartJs.Blazor.ChartJS.Common.Handlers;

namespace ChartJs.Blazor.ChartJS.Common
{
    /// <summary>
    /// The hover configuration contains general settings regarding hovering over a chart.
    /// </summary>
    public class Hover
    {
        /// <summary>
        /// Gets or sets which elements appear in the tooltip.
        /// </summary>
        public InteractionMode Mode { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether or not the hover mode only applies
        /// when the mouse position intersects an item on the chart.
        /// </summary>
        public bool? Intersect { get; set; }

        /// <summary>
        /// Gets or sets which directions are used in calculating distances. Can be set to 'x', 'y', or 'xy'.
        /// Defaults to 'x' for <see cref="Mode"/> == <see cref="InteractionMode.Index"/> and 'xy' for <see cref="Mode"/> == <see cref="InteractionMode.Dataset"/> or <see cref="InteractionMode.Nearest"/>.
        /// </summary>
        // TODO Make string enum
        public string Axis { get; set; }

        /// <summary>
        /// Gets or sets the duration in milliseconds it takes to animate hover style changes.
        /// </summary>
        public long? AnimationDuration { get; set; }
    }
}