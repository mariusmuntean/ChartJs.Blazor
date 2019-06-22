using ChartJs.Blazor.ChartJS.Common;
using ChartJs.Blazor.ChartJS.Common.Enums;

namespace ChartJs.Blazor.ChartJS.LineChart
{
    /// <summary>
    /// Config for a linechart with typesafe data
    /// </summary>
    /// <typeparam name="TData">Defines the type of data in the line chart</typeparam>
    public class LineChartConfig<TData> : ChartConfigBase<LineChartOptions, LineChartData<TData>>
    {
        public LineChartConfig() : base(ChartTypes.Line) { }
    }
}