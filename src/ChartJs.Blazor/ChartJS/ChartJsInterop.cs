using System.Threading.Tasks;
using ChartJs.Blazor.ChartJS.BarChart;
using ChartJs.Blazor.ChartJS.BubbleChart;
using Microsoft.JSInterop;

namespace ChartJs.Blazor.ChartJS
{
    public static class ChartJsInterop
    {
        public static Task<bool> InitializeLineChart(ChartJSChart lineChart)
        {
            return JSRuntime.Current.InvokeAsync<bool>("ChartJSInterop.InitializeLineChart", lineChart);
        }

        public static Task<bool> InitializePieChart(ChartJSChart pieChart)
        {
            return JSRuntime.Current.InvokeAsync<bool>("ChartJSInterop.InitializePieChart", pieChart);
        }

        public static Task<bool> InitializeDoughnutChart(ChartJSChart pieChart)
        {
            return JSRuntime.Current.InvokeAsync<bool>("ChartJSInterop.InitializeDoughnutChart", pieChart);
        }

        public static Task<bool> InitializeBubbleChart(BubbleChartConfig bubbleChart)
        {
            return JSRuntime.Current.InvokeAsync<bool>("ChartJSInterop.InitializeBubbleChart", bubbleChart);
        }

        public static Task<bool> InitializeBarChart(BarChartConfig barChartConfig)
        {
            return JSRuntime.Current.InvokeAsync<bool>("ChartJSInterop.InitializeBarChart", barChartConfig);
        }

        public static Task<bool> InitializeMixedChart(ChartJSChart mixedChart)
        {
            return JSRuntime.Current.InvokeAsync<bool>("ChartJSInterop.InitializeMixedChart", mixedChart);
        }

        public static Task<bool> UpdateLineChart(ChartJSChart lineChart)
        {
            return JSRuntime.Current.InvokeAsync<bool>("ChartJSInterop.UpdateLineChart", lineChart);
        }

        public static Task<bool> UpdatePieChart(ChartJSChart pieChart)
        {
            return JSRuntime.Current.InvokeAsync<bool>("ChartJSInterop.UpdatePieChart", pieChart);
        }

        public static Task<bool> UpdateDoughnutChart(ChartJSChart pieChart)
        {
            return JSRuntime.Current.InvokeAsync<bool>("ChartJSInterop.UpdateDoughnutChart", pieChart);
        }

        public static Task<bool> ReloadBarChart(BarChartConfig barChartConfig)
        {
            return JSRuntime.Current.InvokeAsync<bool>("ChartJSInterop.ReloadChart", barChartConfig);
        }

        public static Task<bool> UpdateMixedChart(ChartJSChart barChart)
        {
            return JSRuntime.Current.InvokeAsync<bool>("ChartJSInterop.UpdateMixedChart", barChart);
        }

        public static Task<bool> InitializeRadarChart(ChartJSChart radarChart)
        {
            return JSRuntime.Current.InvokeAsync<bool>("ChartJSInterop.InitializeRadarChart", radarChart);
        }

        public static Task<bool> UpdateRadarChart(ChartJSChart radarChart)
        {
            return JSRuntime.Current.InvokeAsync<bool>("ChartJSInterop.UpdateRadarChart", radarChart);
        }

        public static Task<bool> UpdateBubbleChart(BubbleChartConfig bubbleChart)
        {
            return JSRuntime.Current.InvokeAsync<bool>("ChartJSInterop.ReloadChart", bubbleChart);
        }
    }
}