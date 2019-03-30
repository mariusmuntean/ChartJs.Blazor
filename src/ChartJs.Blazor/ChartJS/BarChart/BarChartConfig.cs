using ChartJs.Blazor.ChartJS.Common;

namespace ChartJs.Blazor.ChartJS.BarChart
{
    /// <summary>
    /// Either 'bar' or 'horizontalBar'
    /// </summary>
    public class BarChartConfig : ChartConfigBase<BarChartOptions, BarChartData>
    {
        public BarChartConfig(ChartTypes type = null) : base(type ?? ChartTypes.BAR)
        {
        }

        
    }
}