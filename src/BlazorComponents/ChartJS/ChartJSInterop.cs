using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace BlazorComponents.ChartJS
{
    public class ChartJSInterop
    {
        public static Task<bool> InitializeLineChart(ChartJSChart<ChartJsLineDataset> lineChart)
        {
            return JSRuntime.Current.InvokeAsync<bool>("BlazorComponents.ChartJSInterop.InitializeLineChart", new[] { lineChart });
        }

        public static Task<bool> InitializeBarChart(ChartJSChart<ChartJsBarDataset> barChart)
        {
            return JSRuntime.Current.InvokeAsync<bool>("BlazorComponents.ChartJSInterop.InitializeBarChart", new[] { barChart });
        }

        public static Task<bool> UpdateLineChart(ChartJSChart<ChartJsLineDataset> lineChart)
        {
            return JSRuntime.Current.InvokeAsync<bool>("BlazorComponents.ChartJSInterop.UpdateLineChart", new[] { lineChart });
        }

        public static Task<bool> UpdateBarChart(ChartJSChart<ChartJsBarDataset> barChart)
        {
            return JSRuntime.Current.InvokeAsync<bool>("BlazorComponents.ChartJSInterop.UpdateBarChart", new[] { barChart });
        }

        public static Task<bool> InitializeRadarChart(ChartJSChart<ChartJSRadarDataset> radarChart)
        {
            return JSRuntime.Current.InvokeAsync<bool>("BlazorComponents.ChartJSInterop.InitializeRadarChart", new[] { radarChart });
        }

        public static Task<bool> UpdateRadarChart(ChartJSChart<ChartJSRadarDataset> radarChart)
        {
            return JSRuntime.Current.InvokeAsync<bool>("BlazorComponents.ChartJSInterop.UpdateRadarChart", new[] { radarChart });
        }
    }
}
