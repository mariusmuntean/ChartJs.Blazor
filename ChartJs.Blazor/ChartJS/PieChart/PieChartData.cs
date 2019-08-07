using System.Collections.Generic;

namespace ChartJs.Blazor.ChartJS.PieChart
{
    /// <summary>
    /// The data-subconfig of a <see cref="PieChartConfig"/>.
    /// </summary>
    public class PieChartData
    {
        /// <summary>
        /// Gets the labels the chart will use.
        /// </summary>
        public List<string> Labels { get; } = new List<string>();

        /// <summary>
        /// Gets the datasets displayed in this chart.
        /// </summary>
        public List<PieChartDataset> Datasets { get; } = new List<PieChartDataset>();
    }
}