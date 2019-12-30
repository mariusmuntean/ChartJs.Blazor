using System.Text.Json;

namespace ChartJs.Blazor.ChartJS.Common.Handlers
{
    // TODO Use actual types instead of just JsonElement.
    /// <summary>
    /// A filter for legend items. Should return true if you want to show the legend item; false if not.
    /// </summary>
    /// <param name="legendItem">The <see cref="LegendItem"/> to either include or filter out.</param>
    /// <param name="chartData"></param>
    public delegate bool LegendLabelFilter(LegendItem legendItem, JsonElement chartData);
}