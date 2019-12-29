using System.Text.Json;

namespace ChartJs.Blazor.ChartJS.Common.Handlers
{
    // TODO Use actual types instead of just JsonElement.
    /// <summary>
    /// A delegate for all sorts of mouse events on a legend item.
    /// </summary>
    /// <param name="mouseEvent">The mouse event.</param>
    /// <param name="legendItem">The legend item which was clicked.</param>
    public delegate void LegendItemMouseEvent(JsonElement mouseEvent, JsonElement legendItem);
}