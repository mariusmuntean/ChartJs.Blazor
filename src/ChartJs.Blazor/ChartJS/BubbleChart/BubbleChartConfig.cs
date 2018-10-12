namespace ChartJs.Blazor.ChartJS.BubbleChart
{
    public class BubbleChartConfig
    {
        public string Type { get; set; } = ChartTypes.BUBBLE.ToString();

        public BubbleChartData Data { get; set; }

        public BubbleChartOptions Options { get; set; }

        public string CanvasId { get; set; }
    }
}