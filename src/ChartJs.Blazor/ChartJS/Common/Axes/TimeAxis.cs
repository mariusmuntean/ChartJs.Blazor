using ChartJs.Blazor.ChartJS.Common.Enums;
using ChartJs.Blazor.ChartJS.Common.Axes.Ticks;
using ChartJs.Blazor.ChartJS.Common.Time;

namespace ChartJs.Blazor.ChartJS.Common.Axes
{
    /// <summary>
    /// The time scale is used to display times and dates. 
    /// When building its ticks, it will automatically calculate the most comfortable unit base on the size of the scale.
    /// <para>As per documentation here https://www.chartjs.org/docs/latest/axes/cartesian/time.html </para>
    /// </summary>
    public class TimeAxis : CartesianAxis<TimeTicks>
    {
        /// <summary>
        /// The type of axis this instance represents.
        /// <para>For js-interop/serialization purposes so chart.js knows what axis to use.</para>
        /// </summary>
        public override AxisType Type => AxisType.Time;

        /// <summary>
        /// The distribution property controls the data distribution along the scale
        /// </summary>
        public TimeDistribution Distribution { get; set; }

        /// <summary>
        /// The bounds property controls the scale boundary strategy (bypassed by min/max time options).
        /// </summary>
        public ScaleBound Bounds { get; set; }

        /// <summary>
        /// Configuration for time related stuff
        /// </summary>
        public TimeOptions Time { get; set; }
    }
}
