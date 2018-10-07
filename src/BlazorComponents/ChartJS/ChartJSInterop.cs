using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace BlazorComponents.ChartJS
{
    public class ChartJSInterop
    {
        public static Task<bool> InitializeLineChart(ChartJSChart lineChart)
        {
            return JSRuntime.Current.InvokeAsync<bool>("BlazorComponents.ChartJSInterop.InitializeLineChart", new[] { lineChart });
        }
        public static Task<bool> InitializePieChart(ChartJSChart pieChart)
        {
            return JSRuntime.Current.InvokeAsync<bool>("BlazorComponents.ChartJSInterop.InitializePieChart", new[] { pieChart });
        }
        public static Task<bool> InitializeDoughnutChart(ChartJSChart pieChart)
        {
            return JSRuntime.Current.InvokeAsync<bool>("BlazorComponents.ChartJSInterop.InitializeDoughnutChart", new[] { pieChart });
        }

        public static Task<bool> InitializeBubbleChart(ChartJSChart bubbleChart)
        {
            return JSRuntime.Current.InvokeAsync<bool>("BlazorComponents.ChartJSInterop.InitializeBubbleChart", new[] { bubbleChart });
        }

        public static Task<bool> InitializeBarChart(ChartJSChart barChart)
        {
            return JSRuntime.Current.InvokeAsync<bool>("BlazorComponents.ChartJSInterop.InitializeBarChart", new[] { barChart });
        }
        
        public static Task<bool> InitializeMixedChart(ChartJSChart mixedChart)
        {
            return JSRuntime.Current.InvokeAsync<bool>("BlazorComponents.ChartJSInterop.InitializeMixedChart", new[] { mixedChart });
        }

        public static Task<bool> UpdateLineChart(ChartJSChart lineChart)
        {
            return JSRuntime.Current.InvokeAsync<bool>("BlazorComponents.ChartJSInterop.UpdateLineChart", new[] { lineChart });
        }
        public static Task<bool> UpdatePieChart(ChartJSChart pieChart)
        {
            return JSRuntime.Current.InvokeAsync<bool>("BlazorComponents.ChartJSInterop.UpdatePieChart", new[] { pieChart });
        }
        public static Task<bool> UpdateDoughnutChart(ChartJSChart pieChart)
        {
            return JSRuntime.Current.InvokeAsync<bool>("BlazorComponents.ChartJSInterop.UpdateDoughnutChart", new[] { pieChart });
        }

        public static Task<bool> UpdateBarChart(ChartJSChart barChart)
        {
            return JSRuntime.Current.InvokeAsync<bool>("BlazorComponents.ChartJSInterop.UpdateBarChart", new[] { barChart });
        }

        public static Task<bool> UpdateMixedChart(ChartJSChart barChart)
        {
            return JSRuntime.Current.InvokeAsync<bool>("BlazorComponents.ChartJSInterop.UpdateMixedChart", new[] { barChart });
        }

        public static Task<bool> InitializeRadarChart(ChartJSChart radarChart)
        {
            return JSRuntime.Current.InvokeAsync<bool>("BlazorComponents.ChartJSInterop.InitializeRadarChart", new[] { radarChart });
        }

        public static Task<bool> UpdateRadarChart(ChartJSChart radarChart)
        {
            return JSRuntime.Current.InvokeAsync<bool>("BlazorComponents.ChartJSInterop.UpdateRadarChart", new[] { radarChart });
        }

        public static Task<bool> UpdateBubbleChart(ChartJSChart bubbleChart)
        {
            return JSRuntime.Current.InvokeAsync<bool>("BlazorComponents.ChartJSInterop.UpdateBubbleChart", new[] { bubbleChart });
        }
    }
}