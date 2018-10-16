using ChartJs.Blazor.ChartJS.Common;

namespace ChartJs.Blazor.ChartJS.PolarAreaChart
{
    public class PolarAreaChartConfig
    {
        public string Type { get; set; } = ChartTypes.POLARAREA.ToString();
        public string CanvasId { get; set; }

        public PolarAreaOptions Options { get; set; }

        public PolarAreaData Data { get; set; }
    }
}