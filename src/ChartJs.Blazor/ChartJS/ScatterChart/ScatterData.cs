using System.Collections.Generic;

namespace ChartJs.Blazor.ChartJS.ScatterChart
{
    /// <summary>
    /// Represents the data-subconfig of a <see cref="ScatterConfig"/>.
    /// </summary>
    public class ScatterData
    {
        /// <summary>
        /// Gets the datasets displayed in this chart.
        /// </summary>
        public List<ScatterDataset> Datasets { get; } = new List<ScatterDataset>();
    }
}
