namespace ChartJs.Blazor.ChartJS.DoughnutChart
{
    public class DoughnutChartConfig
    {
        public string Type { get; set; } = ChartTypes.DOUGHNUT.ToString();
        public string CanvasId { get; set; }

        public DoughnutData Data { get; set; }

        public DoughnutOptions Options { get; set; }
    }
}