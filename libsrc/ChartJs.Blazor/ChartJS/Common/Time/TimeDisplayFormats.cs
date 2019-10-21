using ChartJs.Blazor.ChartJS.Common.Enums;
using System.Collections.Generic;

namespace ChartJs.Blazor.ChartJS.Common.Time
{
    /// <summary>
    /// This is a helper class containing pre-made display formats to use in <see cref="TimeOptions.DisplayFormats"/> for certain locales.
    /// <para>Those <see cref="TimeMeasurement"/>s that are not defined, will use the default format from https://www.chartjs.org/docs/latest/axes/cartesian/time.html#display-formats </para>
    /// </summary>
    public static class TimeDisplayFormats
    {
        /// <summary>
        /// Pre-made format-string for the swiss (DE_CH) locale.
        /// </summary>
        public static Dictionary<TimeMeasurement, string> DE_CH => new Dictionary<TimeMeasurement, string>
        {
            { TimeMeasurement.Millisecond, "HH:mm:ss.SSS" },
            { TimeMeasurement.Second, "HH:mm:ss" },
            { TimeMeasurement.Minute, "HH:mm" },
            { TimeMeasurement.Hour, "HH:00" }
        };
    }
}
