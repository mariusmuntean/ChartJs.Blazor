using Newtonsoft.Json.Linq;

namespace ChartJs.Blazor.ChartJS.Common.Handlers
{
    /// <summary>
    /// A filter for legend items. Should return <see langword="true"/> if you want to show the legend item;
    /// <see langword="false"/> if not.
    /// </summary>
    /// <param name="legendItem">The <see cref="LegendItem"/> to either include or filter out.</param>
    /// <param name="chartData">The chart data.</param>
    /// <returns><see langword="true"/> if you want to show the legend item; <see langword="false"/> if not.</returns>
    public delegate bool LegendLabelFilter(LegendItem legendItem, JObject chartData);
}