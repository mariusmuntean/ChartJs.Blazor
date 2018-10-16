using ChartJs.Blazor.ChartJS.Common;

namespace ChartJs.Blazor.ChartJS.MixedChart
{
    public class MixedChartConfig
    {
        public string Type { get;} = ChartTypes.BAR.ToString(); // This is not a mistake

        public MixedChartData Data { get; set; }

        public MixedChartOptions Options { get; set; }

        public string CanvasId { get; set; }
    }
}