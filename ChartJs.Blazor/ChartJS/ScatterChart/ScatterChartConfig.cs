using ChartJs.Blazor.ChartJS.Common;
using ChartJs.Blazor.ChartJS.Common.Enums;

namespace ChartJs.Blazor.ChartJS.ScatterChart
{
    public class ScatterChartConfig : ChartConfigBase<ScatterChartOptions, ScatterChartData>
    {
        public ScatterChartConfig() : base(ChartTypes.Scatter) { }
    }
}