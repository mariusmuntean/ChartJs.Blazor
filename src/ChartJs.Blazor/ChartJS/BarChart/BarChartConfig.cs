using ChartJs.Blazor.ChartJS.Common;

namespace ChartJs.Blazor.ChartJS.BarChart
{
    public class BarChartConfig
    {
        /// <summary>
        /// Either 'bar' or 'horizontalBar'
        /// </summary>
        public string Type { get; set; } = ChartTypes.BAR.ToString();

        public BarChartData Data { get; set; }

        public BarChartOptions Options { get; set; }

        public string CanvasId { get; set; }
    }
}