using ChartJs.Blazor.ChartJS.Common.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChartJs.Blazor.ChartJS.LineChart
{
    /// <summary>
    /// As per documentation here https://www.chartjs.org/docs/latest/axes/cartesian/linear.html
    /// </summary>
    public class LinearCartesianAxis : CartesianAxis<LinearCartesianTicks>
    {
        public override AxisType Type => AxisType.Linear;
    }
}
