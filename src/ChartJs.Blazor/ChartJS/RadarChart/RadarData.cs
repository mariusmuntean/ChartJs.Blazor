using System.Collections.Generic;

namespace ChartJs.Blazor.ChartJS.RadarChart
{
    /// <summary>
    /// Represents the data-subconfig of a <see cref="RadarConfig"/>.
    /// </summary>
    public class RadarData
    {
        /// <summary>
        /// Gets the labels the chart will use.
        /// </summary>
        public List<string> Labels { get; } = new List<string>();

        /// <summary>
        /// Gets the datasets displayed in this chart.
        /// </summary>
        public List<RadarDataset> Datasets { get; } = new List<RadarDataset>();
    }
}
