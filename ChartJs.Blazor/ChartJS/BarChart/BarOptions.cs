using ChartJs.Blazor.ChartJS.Common;

namespace ChartJs.Blazor.ChartJS.BarChart
{
    /// <summary>
    /// Bar Chart Config Options. Source: http://www.chartjs.org/docs/latest/charts/bar.html#configuration-options
    /// </summary>
    public class BarOptions : BaseConfigOptions
    {
        // TODO: Make sure these properties are where they're supposed to be. From the looks of the docs they should be in each axis, not in the options itself.

        /// <summary>
        /// Percent (0-1) of the available width each bar should be within the category width. 1.0 will take the whole category width and put the bars right next to each other
        /// </summary>
        public double BarPercentage { get; set; } = 0.9;

        /// <summary>
        /// Percent (0-1) of the available width each category should be within the sample width.
        /// </summary>
        public double CategoryPercentage { get; set; } = 0.8;

        /// <summary>
        /// Manually set width of each bar in pixels. If set to 'flex', it computes "optimal" sample widths that globally arrange bars side by side. If not set (default), bars are equally sized based on the smallest interval.
        /// </summary>
        public object BarThickness { get; set; }

        /// <summary>
        /// Set this to ensure that bars are not sized thicker than this.
        /// </summary>
        public object MaxBarThickness { get; set; }

        public BarOptionsScales Scales { get; set; }
    }
}