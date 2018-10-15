namespace ChartJs.Blazor.ChartJS.PieChart
{
    public class PieChartConfig
    {
        public string Type { get; set; } = ChartTypes.PIE.ToString();

        public PieChartOptions Options { get; set; }

        public PieChartData Data { get; set; }

        public string CanvasId { get; set; }
    }
}