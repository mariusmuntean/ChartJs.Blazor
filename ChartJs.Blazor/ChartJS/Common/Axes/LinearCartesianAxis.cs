using ChartJs.Blazor.ChartJS.Common.Enums;
using ChartJs.Blazor.ChartJS.Common.Axes.Ticks;

namespace ChartJs.Blazor.ChartJS.Common.Axes
{
    /// <summary>
    /// The linear scale is use to chart numerical data. It can be placed on either the x or y axis. 
    /// As the name suggests, linear interpolation is used to determine where a value lies on the axis.
    /// <para>As per documentation here https://www.chartjs.org/docs/latest/axes/cartesian/linear.html </para>
    /// </summary>
    public class LinearCartesianAxis : CartesianAxis<LinearCartesianTicks>
    {
        /// <summary>
        /// The type of axis this instance represents.
        /// <para>For js-interop/serialization purposes so chart.js knows what axis to use.</para>
        /// </summary>
        public override AxisType Type => AxisType.Linear;
    }
}
