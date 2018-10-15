using System.Threading.Tasks;
using ChartJs.Blazor.ChartJS.BarChart;
using ChartJs.Blazor.ChartJS.BubbleChart;
using ChartJs.Blazor.ChartJS.DoughnutChart;
using ChartJs.Blazor.ChartJS.LineChart;
using ChartJs.Blazor.ChartJS.MixedChart;
using ChartJs.Blazor.ChartJS.PieChart;
using ChartJs.Blazor.ChartJS.RadarChart;
using Microsoft.JSInterop;

namespace ChartJs.Blazor.ChartJS
{
    public static class ChartJsInterop
    {
        public static Task<bool> InitializeLineChart(LineChartConfig lineChartConfig)
        {
            return JSRuntime.Current.InvokeAsync<bool>("ChartJSInterop.InitializeLineChart", lineChartConfig);
        }

        public static Task<bool> InitializePieChart(PieChartConfig pieChart)
        {
            return JSRuntime.Current.InvokeAsync<bool>("ChartJSInterop.InitializePieChart", pieChart);
        }

        public static Task<bool> InitializeDoughnutChart(DoughnutChartConfig pieChart)
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

        public static Task<bool> InitializeMixedChart(MixedChartConfig mixedChart)
        {
            return JSRuntime.Current.InvokeAsync<bool>("ChartJSInterop.InitializeMixedChart", mixedChart);
        }

        public static Task<bool> UpdateLineChart(LineChartConfig lineChart)
        {
            return JSRuntime.Current.InvokeAsync<bool>("ChartJSInterop.UpdateLineChart", lineChart);
        }

        public static Task<bool> UpdatePieChart(PieChartConfig pieChart)
        {
            return JSRuntime.Current.InvokeAsync<bool>("ChartJSInterop.UpdatePieChart", pieChart);
        }

        public static Task<bool> UpdateDoughnutChart(DoughnutChartConfig doughnutChartConfig)
        {
            return JSRuntime.Current.InvokeAsync<bool>("ChartJSInterop.UpdateDoughnutChart", doughnutChartConfig);
        }

        public static Task<bool> ReloadBarChart(BarChartConfig barChartConfig)
        {
            return JSRuntime.Current.InvokeAsync<bool>("ChartJSInterop.ReloadChart", barChartConfig);
        }

        public static Task<bool> UpdateMixedChart(MixedChartConfig mixedChartConfig)
        {
            return JSRuntime.Current.InvokeAsync<bool>("ChartJSInterop.UpdateMixedChart", mixedChartConfig);
        }

        public static Task<bool> InitializeRadarChart(RadarChartConfig radarChart)
        {
            return JSRuntime.Current.InvokeAsync<bool>("ChartJSInterop.InitializeRadarChart", radarChart);
        }

        public static Task<bool> UpdateRadarChart(RadarChartConfig radarChart)
        {
            return JSRuntime.Current.InvokeAsync<bool>("ChartJSInterop.UpdateRadarChart", radarChart);
        }

        public static Task<bool> UpdateBubbleChart(BubbleChartConfig bubbleChart)
        {
            return JSRuntime.Current.InvokeAsync<bool>("ChartJSInterop.UpdateBubbleChart", bubbleChart);
        }
    }
}