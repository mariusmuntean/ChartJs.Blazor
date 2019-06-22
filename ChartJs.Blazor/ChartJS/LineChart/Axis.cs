using ChartJs.Blazor.ChartJS.Common;
using Newtonsoft.Json;

namespace ChartJs.Blazor.ChartJS.LineChart
{
    public class Axis
    {
        public bool Display { get; set; } = true;
        public ScaleLabel ScaleLabel { get; set; }
        public GridLine GridLines { get; set; }
        public Ticks Ticks { get; set; }

        [JsonProperty("stacked")]
        public bool Stacked { get; set; }
    }
}