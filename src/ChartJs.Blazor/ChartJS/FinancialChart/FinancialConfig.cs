using ChartJs.Blazor.ChartJS.Common.Enums;

namespace ChartJs.Blazor.ChartJS.FinancialChart
{
    /// <summary>
    /// Configration for Financial Chart
    /// </summary>
    public class FinancialConfig : BarChart.BarConfig
    {
        /// <summary>
        /// FinancialConfig Default constructor
        /// </summary>
        /// <param name="type"></param>
        public FinancialConfig(ChartType type = null) : base(type?? ChartType.CandleStick) { }
    }
}