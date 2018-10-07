using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace ChartJs.Blazor.ChartJS
{
    public static class ChartJsInterop
    {
        public static Task<bool> InitializeLineChart(ChartJSChart lineChart)
        {
            return JSRuntime.Current.InvokeAsync<bool>("ChartJSInterop.InitializeLineChart", new[] { lineChart });
        }
        public static Task<bool> InitializePieChart(ChartJSChart pieChart)
        {
            return JSRuntime.Current.InvokeAsync<bool>("ChartJSInterop.InitializePieChart", new[] { pieChart });
        }
        public static Task<bool> InitializeDoughnutChart(ChartJSChart pieChart)
        {
            return JSRuntime.Current.InvokeAsync<bool>("ChartJSInterop.InitializeDoughnutChart", new[] { pieChart });
        }

        public static Task<bool> InitializeBubbleChart(ChartJSChart bubbleChart)
        {
            return JSRuntime.Current.InvokeAsync<bool>("ChartJSInterop.InitializeBubbleChart", new[] { bubbleChart });
        }

        public static Task<bool> InitializeBarChart(ChartJSChart barChart)
        {
            return JSRuntime.Current.InvokeAsync<bool>("ChartJSInterop.InitializeBarChart", new[] { barChart });
        }
        
        public static Task<bool> InitializeMixedChart(ChartJSChart mixedChart)
        {
            return JSRuntime.Current.InvokeAsync<bool>("ChartJSInterop.InitializeMixedChart", new[] { mixedChart });
        }

        public static Task<bool> UpdateLineChart(ChartJSChart lineChart)
        {
            return JSRuntime.Current.InvokeAsync<bool>("ChartJSInterop.UpdateLineChart", new[] { lineChart });
        }
        public static Task<bool> UpdatePieChart(ChartJSChart pieChart)
        {
            return JSRuntime.Current.InvokeAsync<bool>("ChartJSInterop.UpdatePieChart", new[] { pieChart });
        }
        public static Task<bool> UpdateDoughnutChart(ChartJSChart pieChart)
        {
            return JSRuntime.Current.InvokeAsync<bool>("ChartJSInterop.UpdateDoughnutChart", new[] { pieChart });
        }

        public static Task<bool> UpdateBarChart(ChartJSChart barChart)
        {
            return JSRuntime.Current.InvokeAsync<bool>("ChartJSInterop.UpdateBarChart", new[] { barChart });
        }

        public static Task<bool> UpdateMixedChart(ChartJSChart barChart)
        {
            return JSRuntime.Current.InvokeAsync<bool>("ChartJSInterop.UpdateMixedChart", new[] { barChart });
        }

        public static Task<bool> InitializeRadarChart(ChartJSChart radarChart)
        {
            return JSRuntime.Current.InvokeAsync<bool>("ChartJSInterop.InitializeRadarChart", new[] { radarChart });
        }

        public static Task<bool> UpdateRadarChart(ChartJSChart radarChart)
        {
            return JSRuntime.Current.InvokeAsync<bool>("ChartJSInterop.UpdateRadarChart", new[] { radarChart });
        }

        public static Task<bool> UpdateBubbleChart(ChartJSChart bubbleChart)
        {
            return JSRuntime.Current.InvokeAsync<bool>("ChartJSInterop.UpdateBubbleChart", new[] { bubbleChart });
        }
    }
}