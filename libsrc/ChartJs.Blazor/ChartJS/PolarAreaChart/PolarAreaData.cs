using System.Collections.Generic;

namespace ChartJs.Blazor.ChartJS.PolarAreaChart
{
    /// <summary>
    /// The data-subconfig of a <see cref="PolarAreaConfig"/>.
    /// </summary>
    public class PolarAreaData
    {
        /// <summary>
        /// Gets the labels the chart will use.
        /// </summary>
        public List<string> Labels { get; } = new List<string>();

        /// <summary>
        /// Gets the datasets displayed in this chart.
        /// </summary>
        public List<PolarAreaDataset> Datasets { get; } = new List<PolarAreaDataset>();
    }
}