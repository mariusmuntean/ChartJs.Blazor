using System.Collections.Generic;
using ChartJs.Blazor.ChartJS.Common;

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
        public IList<IDataset> Datasets { get; } = new List<IDataset>();
    }
}
