using ChartJs.Blazor.ChartJS.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChartJs.Blazor.ChartJS.LineChart
{
    /// <summary>
    /// https://www.chartjs.org/docs/latest/axes/cartesian/linear.html#tick-configuration-options
    /// </summary>
    public class LinearCartesianTicks : CartesianTicks
    {
        /// <summary>
        /// If true, scale will include 0 if it is not already included.
        /// </summary>
        public bool? BeginAtZero { get; set; }

        /// <summary>
        /// User defined minimum number for the scale, overrides minimum value from data.
        /// </summary>
        public int? Min { get; set; }

        /// <summary>
        /// User defined maximum number for the scale, overrides maximum value from data.
        /// </summary>
        public int? Max { get; set; }

        /// <summary>
        /// Maximum number of ticks and gridlines to show.
        /// </summary>
        public int MaxTicksLimit { get; set; } = 11;

        /// <summary>
        /// if defined and <see cref="StepSize"></see> is not specified, the step size will be rounded to this many decimal places.
        /// </summary>
        public int? Precision { get; set; }

        /// <summary>
        /// User defined fixed step size for the scale.
        /// <para>See https://www.chartjs.org/docs/latest/axes/cartesian/linear.html#step-size for details</para>
        /// </summary>
        public double? StepSize { get; set; }

        /// <summary>
        /// Adjustment used when calculating the maximum data value. This value is used as the highest value if it's higher than the maximum data-value.
        /// </summary>
        public int? SuggestedMax { get; set; }

        /// <summary>
        /// Adjustment used when calculating the minimum data value. This value is used as the lowest value if it's lower than the minimum data-value.
        /// </summary>
        public int? SuggestedMin { get; set; }
    }
}
