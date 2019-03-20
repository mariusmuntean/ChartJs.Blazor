using ChartJs.Blazor.ChartJS.Common;

namespace ChartJs.Blazor.ChartJS.LineChart
{
    public class LineChartConfig : ChartConfigBase<LineChartOptions, LineChartData>
    {
        public LineChartConfig() : base(ChartTypes.LINE)
        {
        }
    }
}