using Microsoft.AspNetCore.Blazor.Browser.Interop;

namespace BlazorComponents.ChartJS
{
    public class ChartJSInterop
    {
        public static bool InitializeLineChart(ChartJSChart<ChartJsLineDataset> lineChart)
        {
            return RegisteredFunction.Invoke<bool>("BlazorComponents.ChartJSInterop.InitializeLineChart", new[] { lineChart });
        }

        public static bool InitializeBarChart(ChartJSChart<ChartJsBarDataset> barChart)
        {
            return RegisteredFunction.Invoke<bool>("BlazorComponents.ChartJSInterop.InitializeBarChart", new[] { barChart });
        }

        public static bool UpdateLineChart(ChartJSChart<ChartJsLineDataset> lineChart)
        {
            return RegisteredFunction.Invoke<bool>("BlazorComponents.ChartJSInterop.UpdateLineChart", new[] { lineChart });
        }

        public static bool UpdateBarChart(ChartJSChart<ChartJsBarDataset> barChart)
        {
            return RegisteredFunction.Invoke<bool>("BlazorComponents.ChartJSInterop.UpdateBarChart", new[] { barChart });
        }

        public static bool InitializeRadarChart(ChartJSChart<ChartJSRadarDataset> radarChart)
        {
            return RegisteredFunction.Invoke<bool>("BlazorComponents.ChartJSInterop.InitializeRadarChart", new[] { radarChart });
        }

        public static bool UpdateRadarChart(ChartJSChart<ChartJSRadarDataset> radarChart)
        {
            return RegisteredFunction.Invoke<bool>("BlazorComponents.ChartJSInterop.UpdateRadarChart", new[] { radarChart });
        }
    }
}
