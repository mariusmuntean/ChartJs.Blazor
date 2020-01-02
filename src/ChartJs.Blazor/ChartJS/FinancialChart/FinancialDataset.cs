using ChartJs.Blazor.ChartJS.Common.Enums;
using System.Collections.Generic;

namespace ChartJs.Blazor.ChartJS.FinancialChart
{
    public class FinancialDataset<TData> : BarChart.BarDataset<TData> where TData : class
    {
        public FinancialDataset(ChartType chartType = null) : base(chartType?? ChartType.CandleStick)
        {
        }

        public FinancialDataset(IEnumerable<TData> data, ChartType chartType = null) : base(data, chartType?? ChartType.CandleStick)
        {
        }
    }
}