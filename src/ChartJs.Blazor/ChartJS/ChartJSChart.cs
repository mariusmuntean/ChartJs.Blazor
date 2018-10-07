using System;

namespace ChartJs.Blazor.ChartJS
{
    public class ChartJSChart
    {
        public string ChartType { get; set; } = ChartTypes.BAR.ToString();
        public ChartJsData Data { get; set; }
        public ChartJsOptions Options { get; set; }
        public string CanvasId { get; set; } = $"BlazorChartJS_{new Random().Next(0, 1000000).ToString()}";
    }
}