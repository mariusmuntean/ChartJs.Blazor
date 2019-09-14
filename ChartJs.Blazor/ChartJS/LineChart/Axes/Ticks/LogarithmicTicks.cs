
namespace ChartJs.Blazor.ChartJS.LineChart.Axes.Ticks
{
    public class LogarithmicTicks : CartesianTicks
    {
        /// <summary>
        /// User defined minimum number for the scale, overrides minimum value from data.
        /// </summary>
        public int Min { get; set; }

        /// <summary>
        /// User defined maximum number for the scale, overrides maximum value from data.
        /// </summary>
        public int Max { get; set; }
    }
}
