using System;

namespace BlazorComponents.ChartJS
{
    public class ChartJSChart<T> where T: ChartJsDataset
    {
        public string ChartType { get; set; } = "bar";
        public ChartJsData<T> Data { get; set; }
        public ChartJsOptions Options { get; set; }
        public string CanvasId { get; set; } = $"BlazorChartJS_{new Random().Next(0, 1000000).ToString()}";
    }
}
