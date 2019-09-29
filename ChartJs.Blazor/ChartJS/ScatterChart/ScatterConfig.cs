using ChartJs.Blazor.ChartJS.Common;
using ChartJs.Blazor.ChartJS.Common.Enums;

namespace ChartJs.Blazor.ChartJS.ScatterChart
{
    public class ScatterConfig : ConfigBase<ScatterOptions, ScatterData>
    {
        public ScatterConfig() : base(ChartType.Scatter) { }
    }
}