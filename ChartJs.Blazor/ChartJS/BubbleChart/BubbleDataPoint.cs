using ChartJs.Blazor.ChartJS.Common;

namespace ChartJs.Blazor.ChartJS.BubbleChart
{
    public class BubbleDataPoint : Point
    {
        /// <summary>
        /// Bubble radius, in pixels, not scaled
        /// </summary>
        public double r { get; set; }
    }
}