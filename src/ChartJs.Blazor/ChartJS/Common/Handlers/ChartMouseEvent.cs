using System.Text.Json;

namespace ChartJs.Blazor.ChartJS.Common.Handlers
{
    // TODO Use actual types instead of just JsonElement.
    /// <summary>
    /// A delegate for all sorts of mouse events on a chart.
    /// </summary>
    /// <param name="mouseEvent">The mouse event.</param>
    /// <param name="activeElements"></param>
    public delegate void ChartMouseEvent(JsonElement mouseEvent, object[] activeElements);
}