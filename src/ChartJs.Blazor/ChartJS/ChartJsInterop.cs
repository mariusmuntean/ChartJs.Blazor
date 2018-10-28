using ChartJs.Blazor.ChartJS.BarChart;
using ChartJs.Blazor.ChartJS.BubbleChart;
using ChartJs.Blazor.ChartJS.DoughnutChart;
using ChartJs.Blazor.ChartJS.LineChart;
using ChartJs.Blazor.ChartJS.MixedChart;
using ChartJs.Blazor.ChartJS.PieChart;
using ChartJs.Blazor.ChartJS.PolarAreaChart;
using ChartJs.Blazor.ChartJS.RadarChart;
using Microsoft.JSInterop;
using System.Threading.Tasks;
using ChartJs.Blazor.ChartJS.ScatterChart;

namespace ChartJs.Blazor.ChartJS
{
    public static class ChartJsInterop
    {
        #region initialize

        public static Task<bool> InitializeLineChart(LineChartConfig lineChartConfig)
        {
            return JSRuntime.Current.InvokeAsync<bool>("ChartJSInterop.InitializeChart", lineChartConfig);
        }
        public static Task<bool> InitializeScatterChart(ScatterChartConfig scatterChartConfig)
        {
            return JSRuntime.Current.InvokeAsync<bool>("ChartJSInterop.InitializeChart", scatterChartConfig);
        }

        public static Task<bool> InitializePieChart(PieChartConfig pieChart)
        {
            return JSRuntime.Current.InvokeAsync<bool>("ChartJSInterop.InitializeChart", pieChart);
        }

        public static Task<bool> InitializeDoughnutChart(DoughnutChartConfig doughnutChartConfig)
        {
            return JSRuntime.Current.InvokeAsync<bool>("ChartJSInterop.InitializeChart", doughnutChartConfig);
        }

        public static Task<bool> InitializeBubbleChart(BubbleChartConfig bubbleChart)
        {
            return JSRuntime.Current.InvokeAsync<bool>("ChartJSInterop.InitializeChart", bubbleChart);
        }

        public static Task<bool> InitializePolarAreaChart(PolarAreaChartConfig polarAreaChartConfig)
        {
            return JSRuntime.Current.InvokeAsync<bool>("ChartJSInterop.InitializeChart", polarAreaChartConfig);
        }

        public static Task<bool> InitializeBarChart(BarChartConfig barChartConfig)
        {
            return JSRuntime.Current.InvokeAsync<bool>("ChartJSInterop.InitializeChart", barChartConfig);
        }

        public static Task<bool> InitializeMixedChart(MixedChartConfig mixedChart)
        {
            return JSRuntime.Current.InvokeAsync<bool>("ChartJSInterop.InitializeChart", mixedChart);
        }
        
        public static Task<bool> InitializeRadarChart(RadarChartConfig radarChartConfig)
        {
            return JSRuntime.Current.InvokeAsync<bool>("ChartJSInterop.InitializeChart", radarChartConfig);
        }

        #endregion initialize

        #region update

        public static Task<bool> UpdateLineChart(LineChartConfig lineChart)
        {
            return JSRuntime.Current.InvokeAsync<bool>("ChartJSInterop.UpdateChart", lineChart);
        }

        public static Task<bool> UpdateScatterChart(ScatterChartConfig scatterChartConfig)
        {
            return JSRuntime.Current.InvokeAsync<bool>("ChartJSInterop.UpdateChart", scatterChartConfig);
        }

        public static Task<bool> UpdatePieChart(PieChartConfig pieChart)
        {
            return JSRuntime.Current.InvokeAsync<bool>("ChartJSInterop.UpdateChart", pieChart);
        }

        public static Task<bool> UpdateDoughnutChart(DoughnutChartConfig doughnutChartConfig)
        {
            return JSRuntime.Current.InvokeAsync<bool>("ChartJSInterop.UpdateChart", doughnutChartConfig);
        }

        public static Task<bool> UpdateBarChart(BarChartConfig barChartConfig)
        {
            return JSRuntime.Current.InvokeAsync<bool>("ChartJSInterop.UpdateChart", barChartConfig);
        }

        public static Task<bool> UpdateMixedChart(MixedChartConfig mixedChartConfig)
        {
            return JSRuntime.Current.InvokeAsync<bool>("ChartJSInterop.UpdateChart", mixedChartConfig);
        }

        public static Task<bool> UpdateRadarChart(RadarChartConfig radarChart)
        {
            return JSRuntime.Current.InvokeAsync<bool>("ChartJSInterop.UpdateChart", radarChart);
        }

        public static Task<bool> UpdateBubbleChart(BubbleChartConfig bubbleChart)
        {
            return JSRuntime.Current.InvokeAsync<bool>("ChartJSInterop.UpdateChart", bubbleChart);
        }

        public static Task<bool> UpdatePolarAreaChart(PolarAreaChartConfig polarAreaChartConfig)
        {
            return JSRuntime.Current.InvokeAsync<bool>("ChartJSInterop.UpdateChart", polarAreaChartConfig);
        }

        #endregion update

        #region reload

        public static Task<bool> ReloadBarChart(BarChartConfig barChartConfig)
        {
            return JSRuntime.Current.InvokeAsync<bool>("ChartJSInterop.ReloadChart", barChartConfig);
        }

        public static Task<bool> ReloadLineChart(LineChartConfig lineChartConfig)
        {
            return JSRuntime.Current.InvokeAsync<bool>("ChartJSInterop.ReloadChart", lineChartConfig);
        }
       public static Task<bool> ReloadScatterChart(ScatterChartConfig scatterChartConfig)
        {
            return JSRuntime.Current.InvokeAsync<bool>("ChartJSInterop.ReloadChart", scatterChartConfig);
        }

        public static Task<bool> ReloadPieChart(PieChartConfig pieChart)
        {
            return JSRuntime.Current.InvokeAsync<bool>("ChartJSInterop.ReloadChart", pieChart);
        }

        public static Task<bool> ReloadDoughnutChart(DoughnutChartConfig pieChart)
        {
            return JSRuntime.Current.InvokeAsync<bool>("ChartJSInterop.ReloadChart", pieChart);
        }

        public static Task<bool> ReloadBubbleChart(BubbleChartConfig bubbleChart)
        {
            return JSRuntime.Current.InvokeAsync<bool>("ChartJSInterop.ReloadChart", bubbleChart);
        }

        public static Task<bool> ReloadPolarAreaChart(PolarAreaChartConfig polarAreaChartConfig)
        {
            return JSRuntime.Current.InvokeAsync<bool>("ChartJSInterop.ReloadChart", polarAreaChartConfig);
        }
        
        public static Task<bool> ReloadRadarChart(RadarChartConfig radarChartConfig)
        {
            return JSRuntime.Current.InvokeAsync<bool>("ChartJSInterop.ReloadChart", radarChartConfig);
        }

        public static Task<bool> ReloadMixedChart(MixedChartConfig mixedChart)
        {
            return JSRuntime.Current.InvokeAsync<bool>("ChartJSInterop.ReloadChart", mixedChart);
        }

        #endregion reload
    }
}