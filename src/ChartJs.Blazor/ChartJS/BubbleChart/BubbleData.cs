using System.Collections.Generic;
using ChartJs.Blazor.ChartJS.Common;
using ChartJs.Blazor.ChartJS.Common.Properties;

namespace ChartJs.Blazor.ChartJS.BubbleChart
{
    /// <summary>
    /// Represents the data-subconfig of a <see cref="BubbleConfig"/>.
    /// </summary>
    public class BubbleData
    {
        /// <summary>
        /// Gets the datasets displayed in this chart.
        /// </summary>
        public IList<IDataset> Datasets { get; } = new List<IDataset>();
    }
}
