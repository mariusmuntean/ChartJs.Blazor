using ChartJs.Blazor.ChartJS.Common.Enums;

namespace ChartJs.Blazor.ChartJS.LineChart.Axes.Ticks
{
    public class TimeTicks : CartesianTicks
    {
        /// <summary>
        /// How ticks are generated. 
        /// </summary>
        public TickSource Source { get; set; }
    }
}
