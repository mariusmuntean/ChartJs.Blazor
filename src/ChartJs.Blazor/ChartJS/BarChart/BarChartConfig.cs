namespace ChartJs.Blazor.ChartJS.BarChart
{
    public class BarChartConfig
    {
        public string Type { get; set; } = ChartTypes.BAR.ToString();

        public BarChartData Data { get; set; }

        public BarChartOptions Options { get; set; }

        public string CanvasId { get; set; }
    }
}