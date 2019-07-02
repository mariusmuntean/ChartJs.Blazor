using ChartJs.Blazor.ChartJS.Common.Enums;
using ChartJs.Blazor.ChartJS.LineChart.Axes.Ticks;

namespace ChartJs.Blazor.ChartJS.LineChart.Axes
{
    public class LogarithmicAxis : CartesianAxis<LogarithmicTicks>
    {
        public override AxisType Type => AxisType.Logarithmic;
    }
}
