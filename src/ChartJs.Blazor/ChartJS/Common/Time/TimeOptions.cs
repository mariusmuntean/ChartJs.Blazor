using ChartJs.Blazor.ChartJS.Common.Enums;
using System.Collections.Generic;

namespace ChartJs.Blazor.ChartJS.Common.Time
{
    /// <summary>
    /// As per documentation here https://www.chartjs.org/docs/latest/axes/cartesian/time.html#configuration-options
    /// </summary>
    public class TimeOptions
    {
        /// <summary>
        /// Sets how different time units are displayed. See https://www.chartjs.org/docs/latest/axes/cartesian/time.html#data-sets for more details.
        /// <para>See <see cref="TimeDisplayFormats"/> for pre-made formats for certain locales.</para>
        /// </summary>
        public Dictionary<TimeMeasurement, string> DisplayFormats { get; set; }

        /// <summary>
        /// If true and the <see cref="Unit"></see> is set to <see cref="TimeMeasurement.Week"></see>, then the first day of the week will be Monday. Otherwise, it will be Sunday.
        /// </summary>
        public bool IsoWeek { get; set; }

        /// <summary>
        /// If defined, this will override the data maximum.
        /// </summary>
        public Moment Max { get; set; }

        /// <summary>
        /// If defined, this will override the data minimum.
        /// </summary>
        public Moment Min { get; set; }

        /// <summary>
        /// If defined, dates will be rounded to the start of this unit.
        /// </summary>
        public TimeMeasurement Round { get; set; }

        /// <summary>
        /// The Moment.js format string to use for the tooltip.
        /// <para>See https://momentjs.com/docs/#/displaying/format/ for possible formats</para>
        /// </summary>
        public string TooltipFormat { get; set; }

        /// <summary>
        /// If defined, will force the unit to be a certain type.
        /// </summary>
        public TimeMeasurement Unit { get; set; }

        /// <summary>
        /// The number of units between grid lines.
        /// </summary>
        public int StepSize { get; set; }

        /// <summary>
        /// The minimum display format to be used for a time unit.
        /// </summary>
        public TimeMeasurement MinUnit { get; set; }
    }
}
