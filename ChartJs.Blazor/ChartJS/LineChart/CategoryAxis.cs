using System;
using System.Collections.Generic;
using System.Text;
using ChartJs.Blazor.ChartJS.Common.Enums;

namespace ChartJs.Blazor.ChartJS.LineChart
{
    public class CategoryAxis : CartesianAxis<CategoryTicks>
    {
        public override AxisType Type => AxisType.Category;
    }
}
