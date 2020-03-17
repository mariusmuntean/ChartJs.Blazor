using ChartJs.Blazor.ChartJS.Common.Enums;
using System.Collections.Generic;

namespace ChartJs.Blazor.ChartJS.FinancialChart
{
    /// <summary>
    /// FinancialChart Default Dataset
    /// financial chart (chartjs extension) is extend BarDataset
    /// if you want understand this, then watching this document
    /// https://www.chartjs.org/docs/latest/developers/charts.html
    /// </summary>
    /// <typeparam name="TData"></typeparam>
    public class FinancialDataset<TData> : BarChart.BarDataset<TData> where TData : class
    {
        /// <summary>
        /// FinancialDataset default constructor
        /// </summary>
        /// <param name="chartType"></param>
        public FinancialDataset(ChartType chartType = null) : base(chartType?? ChartType.CandleStick)
        {
        }

        /// <summary>
        /// construct FinancialDataset with data initialize
        /// </summary>
        /// <param name="data"></param>
        /// <param name="chartType"></param>
        public FinancialDataset(IEnumerable<TData> data, ChartType chartType = null) : base(data, chartType?? ChartType.CandleStick)
        {
        }
    }
}