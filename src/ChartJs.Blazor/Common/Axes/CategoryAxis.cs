using ChartJs.Blazor.Common.Enums;
using ChartJs.Blazor.Common.Axes.Ticks;
using ChartJs.Blazor.LineChart;

namespace ChartJs.Blazor.Common.Axes
{
    /// <summary>
    /// This axis is to be used when you want to display <see cref="string"/> values for an axis.
    /// <para>This axis has to be used when using/defining <see cref="ChartData.Labels"/>, <see cref="ChartData.XLabels"/> and/or <see cref="ChartData.YLabels"/>.</para>
    /// <para>As per documentation here https://www.chartjs.org/docs/latest/axes/cartesian/category.html </para>
    /// </summary>
    public class CategoryAxis : CartesianAxis<CategoryTicks>
    {
        /// <summary>
        /// The type of axis this instance represents.
        /// <para>For js-interop/serialization purposes so chart.js knows what axis to use.</para>
        /// </summary>
        public override AxisType Type => AxisType.Category;
    }
}
