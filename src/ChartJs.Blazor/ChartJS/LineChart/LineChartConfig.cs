namespace ChartJs.Blazor.ChartJS.LineChart
{
    public class LineChartConfig
    {
        public string CanvasId { get; set; }
        public string Type { get; set; } = ChartTypes.LINE.ToString();
        public LineChartOptions Options { get; set; }
        public LineChartData Data { get; set; }
    }
}