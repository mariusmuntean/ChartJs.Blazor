using System;
using System.Collections.Generic;
using System.Text;

namespace ChartJs.Blazor.ChartJS.LineChart
{
    /// <summary>
    /// As per documentation here https://www.chartjs.org/docs/latest/charts/line.html#stepped-line
    /// </summary>
    public static class SteppedLine
    {
        /// <summary>
        /// No Step Interpolation (default)
        /// </summary>
        public static object False { get; } = false;

        /// <summary>
        /// Step-before Interpolation (same as <see cref="Before"></see>)
        /// </summary>
        public static object True { get; } = true;

        /// <summary>
        /// Step-before Interpolation
        /// </summary>
        public static object Before { get; } = "before";

        /// <summary>
        /// Step-after Interpolation
        /// </summary>
        public static object After { get; } = "after";

        /// <summary>
        /// Step-middle Interpolation
        /// </summary>
        public static object Middle { get; } = "middle";
    }
}
