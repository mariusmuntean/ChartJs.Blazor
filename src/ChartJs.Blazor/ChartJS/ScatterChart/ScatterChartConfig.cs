using ChartJs.Blazor.ChartJS.Common;

namespace ChartJs.Blazor.ChartJS.ScatterChart
{
    public class ScatterChartConfig
    {
        public string Type { get; private set; } = ChartTypes.SCATTER.ToString();

        public string CanvasId { get; set; }

        public ScatterConfigData Data { get; set; }

        public ScatterConfigOptions Options { get; set; }
    }
}