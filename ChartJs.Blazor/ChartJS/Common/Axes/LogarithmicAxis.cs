using ChartJs.Blazor.ChartJS.Common.Enums;
using ChartJs.Blazor.ChartJS.Common.Axes.Ticks;

namespace ChartJs.Blazor.ChartJS.Common.Axes
{
    /// <summary>
    /// The logarithmic scale is use to chart numerical data. It can be placed on either the x or y axis. 
    /// As the name suggests, logarithmic interpolation is used to determine where a value lies on the axis.
    /// <para>As per documentation here https://www.chartjs.org/docs/latest/axes/cartesian/logarithmic.html </para>
    /// </summary>
    public class LogarithmicAxis : CartesianAxis<LogarithmicTicks>
    {
        /// <summary>
        /// The type of axis this instance represents.
        /// <para>For js-interop/serialization purposes so chart.js knows what axis to use.</para>
        /// </summary>
        public override AxisType Type => AxisType.Logarithmic;
    }
}
