using ChartJs.Blazor.ChartJS.Common;
using ChartJs.Blazor.ChartJS.Common.Enums;

namespace ChartJs.Blazor.ChartJS.LineChart
{
    public class LineChartConfig : ChartConfigBase<LineChartOptions, LineChartData>
    {
        public LineChartConfig() : base(ChartTypes.Line) { }
    }
}