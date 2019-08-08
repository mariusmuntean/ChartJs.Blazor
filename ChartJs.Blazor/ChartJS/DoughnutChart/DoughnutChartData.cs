using System.Collections.Generic;

namespace ChartJs.Blazor.ChartJS.DoughnutChart
{
    /// <summary>
    /// The data-subconfig of a <see cref="DoughnutChartConfig"/>.
    /// </summary>
    public class DoughnutChartData
    {
        /// <summary>
        /// Gets the labels the chart will use.
        /// </summary>
        public List<string> Labels { get; } = new List<string>();

        /// <summary>
        /// Gets the datasets displayed in this chart.
        /// </summary>
        public List<DoughnutChartDataset> Datasets { get; } = new List<DoughnutChartDataset>();
    }
}