namespace ChartJs.Blazor.ChartJS.RadarChart
{
    public class RadarChartConfig
    {
        public string CanvasId { get; set; }

        public string Type { get; set; } = ChartTypes.RADAR.ToString();

        public RadarChartOptions Options { get; set; }

        public RadarChartData Data { get; set; }
    }
}