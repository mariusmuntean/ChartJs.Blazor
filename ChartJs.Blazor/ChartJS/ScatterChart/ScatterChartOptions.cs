using ChartJs.Blazor.ChartJS.Common;
using ChartJs.Blazor.ChartJS.Common.Enums;

namespace ChartJs.Blazor.ChartJS.ScatterChart
{
    public class ScatterChartOptions : BaseChartConfigOptions
    {
        public InteractionMode HoverMode { get; set; } = InteractionMode.Nearest;

        public bool Intersect { get; set; }

        public OptionsTitle Title { get; set; }

        public ScatterChartScales Scales { get; set; }
    }
}