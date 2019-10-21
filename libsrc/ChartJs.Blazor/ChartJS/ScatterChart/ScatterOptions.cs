using ChartJs.Blazor.ChartJS.Common;
using ChartJs.Blazor.ChartJS.Common.Enums;

namespace ChartJs.Blazor.ChartJS.ScatterChart
{
    public class ScatterOptions : BaseConfigOptions
    {
        public InteractionMode HoverMode { get; set; } = InteractionMode.Nearest;

        public bool Intersect { get; set; }

        public ScatterScales Scales { get; set; }
    }
}