using System.Collections.Generic;
using System.Text.Json;

namespace ChartJs.Blazor.ChartJS.Common.Handlers
{
    // TODO Use actual types instead of just JsonElement.
    /// <summary>
    /// A generator for legend labels.
    /// </summary>
    /// <param name="chart">The chart for which to generate the labels.</param>
    public delegate ICollection<LegendItem> LegendLabelsGenerator(JsonElement chart);
}