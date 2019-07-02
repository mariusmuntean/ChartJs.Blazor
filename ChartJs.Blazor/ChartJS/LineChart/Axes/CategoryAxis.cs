using System;
using System.Collections.Generic;
using System.Text;
using ChartJs.Blazor.ChartJS.Common.Enums;
using ChartJs.Blazor.ChartJS.LineChart.Axes.Ticks;

namespace ChartJs.Blazor.ChartJS.LineChart.Axes
{
    public class CategoryAxis : CartesianAxis<CategoryTicks>
    {
        public override AxisType Type => AxisType.Category;
    }
}
