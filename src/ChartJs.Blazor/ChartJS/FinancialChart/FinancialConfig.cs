using ChartJs.Blazor.ChartJS.Common.Enums;

namespace ChartJs.Blazor.ChartJS.FinancialChart
{
    public class FinancialConfig : BarChart.BarConfig
    {
        public FinancialConfig(ChartType type = null) : base(type?? ChartType.CandleStick) { }
    }
}