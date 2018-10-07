using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace ChartJs.Blazor.ChartJS
{
    public static class ChartJsInterop
    {
        public static Task<bool> InitializeLineChart(ChartJSChart lineChart)
        {
            return JSRuntime.Current.InvokeAsync<bool>("ChartJsInterop.ChartJSInterop.InitializeLineChart", new[] { lineChart });
        }
        public static Task<bool> InitializePieChart(ChartJSChart pieChart)
        {
            return JSRuntime.Current.InvokeAsync<bool>("ChartJsInterop.ChartJSInterop.InitializePieChart", new[] { pieChart });
        }
        public static Task<bool> InitializeDoughnutChart(ChartJSChart pieChart)
        {
            return JSRuntime.Current.InvokeAsync<bool>("ChartJsInterop.ChartJSInterop.InitializeDoughnutChart", new[] { pieChart });
        }

        public static Task<bool> InitializeBubbleChart(ChartJSChart bubbleChart)
        {
            return JSRuntime.Current.InvokeAsync<bool>("ChartJsInterop.ChartJSInterop.InitializeBubbleChart", new[] { bubbleChart });
        }

        public static Task<bool> InitializeBarChart(ChartJSChart barChart)
        {
            return JSRuntime.Current.InvokeAsync<bool>("ChartJsInterop.ChartJSInterop.InitializeBarChart", new[] { barChart });
        }
        
        public static Task<bool> InitializeMixedChart(ChartJSChart mixedChart)
        {
            return JSRuntime.Current.InvokeAsync<bool>("ChartJsInterop.ChartJSInterop.InitializeMixedChart", new[] { mixedChart });
        }

        public static Task<bool> UpdateLineChart(ChartJSChart lineChart)
        {
            return JSRuntime.Current.InvokeAsync<bool>("ChartJsInterop.ChartJSInterop.UpdateLineChart", new[] { lineChart });
        }
        public static Task<bool> UpdatePieChart(ChartJSChart pieChart)
        {
            return JSRuntime.Current.InvokeAsync<bool>("ChartJsInterop.ChartJSInterop.UpdatePieChart", new[] { pieChart });
        }
        public static Task<bool> UpdateDoughnutChart(ChartJSChart pieChart)
        {
            return JSRuntime.Current.InvokeAsync<bool>("ChartJsInterop.ChartJSInterop.UpdateDoughnutChart", new[] { pieChart });
        }

        public static Task<bool> UpdateBarChart(ChartJSChart barChart)
        {
            return JSRuntime.Current.InvokeAsync<bool>("ChartJsInterop.ChartJSInterop.UpdateBarChart", new[] { barChart });
        }

        public static Task<bool> UpdateMixedChart(ChartJSChart barChart)
        {
            return JSRuntime.Current.InvokeAsync<bool>("ChartJsInterop.ChartJSInterop.UpdateMixedChart", new[] { barChart });
        }

        public static Task<bool> InitializeRadarChart(ChartJSChart radarChart)
        {
            return JSRuntime.Current.InvokeAsync<bool>("ChartJsInterop.ChartJSInterop.InitializeRadarChart", new[] { radarChart });
        }

        public static Task<bool> UpdateRadarChart(ChartJSChart radarChart)
        {
            return JSRuntime.Current.InvokeAsync<bool>("ChartJsInterop.ChartJSInterop.UpdateRadarChart", new[] { radarChart });
        }

        public static Task<bool> UpdateBubbleChart(ChartJSChart bubbleChart)
        {
            return JSRuntime.Current.InvokeAsync<bool>("ChartJsInterop.ChartJSInterop.UpdateBubbleChart", new[] { bubbleChart });
        }
    }
}