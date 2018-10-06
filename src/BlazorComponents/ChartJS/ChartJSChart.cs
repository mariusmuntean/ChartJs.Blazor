using System;

namespace BlazorComponents.ChartJS
{
    public class ChartJSChart<T> where T: ChartJsDataset
    {
        public ChartTypes ChartType { get; set; } = ChartTypes.bar;
        public ChartJsData<T> Data { get; set; }
        public ChartJsOptions Options { get; set; }
        public string CanvasId { get; set; } = $"BlazorChartJS_{new Random().Next(0, 1000000).ToString()}";
    }
}
