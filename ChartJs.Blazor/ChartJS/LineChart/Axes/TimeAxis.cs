using ChartJs.Blazor.ChartJS.Common.Enums;
using ChartJs.Blazor.ChartJS.LineChart.Axes.Ticks;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChartJs.Blazor.ChartJS.LineChart.Axes
{
    /// <summary>
    /// As per documentation here https://www.chartjs.org/docs/latest/axes/cartesian/time.html
    /// </summary>
    public class TimeAxis : CartesianAxis<TimeTicks>
    {
        public override AxisType Type => AxisType.Time;

        /// <summary>
        /// The distribution property controls the data distribution along the scale
        /// </summary>
        public TimeDistribution Distribution { get; set; }

        /// <summary>
        /// The bounds property controls the scale boundary strategy (bypassed by min/max time options).
        /// </summary>
        public ScaleBounds Bounds { get; set; }

        /// <summary>
        /// Configuration for time related stuff
        /// </summary>
        public TimeOptions Time { get; set; }
    }
}
