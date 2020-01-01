using System.Collections.Generic;
using System.Text.Json;

namespace ChartJs.Blazor.ChartJS.Common.Handlers
{
    /// <summary>
    /// A delegate used for customizing tick marks on an axis. If this callback returns <c>null</c> (or undefined), the associated grid line will be hidden.
    /// </summary>
    /// <param name="value">The value. It's usually a double but can also be other types like string (e.g. in a category axis).</param>
    /// <param name="index">The index of the tick mark.</param>
    /// <param name="values">An array of labels. Normally those are just strings but in a <see cref="Axes.TimeAxis"/> they have a 'label' and a 'major' field.</param>
    /// <returns>The new value of the tick mark or null if you want to hide that grid line.</returns>
    public delegate string AxisTickCallback(JsonElement value, int index, JsonElement[] values);
}