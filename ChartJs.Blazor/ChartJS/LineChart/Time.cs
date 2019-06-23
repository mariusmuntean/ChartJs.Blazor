using ChartJs.Blazor.ChartJS.Common.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChartJs.Blazor.ChartJS.LineChart
{
    class Time
    {
        /// <summary>
        /// How ticks are generated. 
        /// </summary>
        public string Source { get; set; }
        
        /// <summary>
        /// Sets how different time units are displayed
        /// </summary>
        public object DisplayFormats { get; set; }

        /// <summary>
        /// If true and the <see cref="Unit"></see> is set to <see cref="TimeMeasurement.Week"></see>, then the first day of the week will be Monday. Otherwise, it will be Sunday.
        /// </summary>
        public bool IsoWeek { get; set; }

        /// <summary>
        /// If defined, this will override the data maximum.
        /// <para>Use <see cref="TimeHelper"></see> when working with times/dates.</para>
        /// </summary>
        public string Max { get; set; }

        /// <summary>
        /// If defined, will force the unit to be a certain type.
        /// </summary>
        public TimeMeasurement Unit { get; set; }
    }
}
