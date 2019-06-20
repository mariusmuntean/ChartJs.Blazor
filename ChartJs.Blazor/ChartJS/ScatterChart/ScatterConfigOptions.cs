using ChartJs.Blazor.ChartJS.Common;

namespace ChartJs.Blazor.ChartJS.ScatterChart
{
    public class ScatterConfigOptions : BaseChartConfigOptions
    {
        public string HoverMode { get; set; } = HoverModes.NEAREST.ToString();

        public bool Intersect { get; set; }

        public OptionsTitle Title { get; set; }

        public ScatterChartScales Scales { get; set; }
    }
}