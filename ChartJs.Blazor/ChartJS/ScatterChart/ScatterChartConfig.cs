using ChartJs.Blazor.ChartJS.Common;

namespace ChartJs.Blazor.ChartJS.ScatterChart
{
    public class ScatterChartConfig : ChartConfigBase<ScatterConfigOptions, ScatterConfigData>
    {
        public ScatterChartConfig() : base(ChartTypes.SCATTER)
        {
        }
    }
}