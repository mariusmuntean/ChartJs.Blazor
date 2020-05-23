using System;
using System.Collections.Generic;

namespace ChartJs.Blazor.ChartJS.BarChart
{
    /// <summary>
    /// Represents the data-subconfig of a <see cref="BarConfig"/>.
    /// </summary>
    public class BarData
    {
        /// <summary>
        /// Creates a new instance of <see cref="BarData"/>.
        /// </summary>
        public BarData()
        {
            Labels = new List<string>();
            Datasets = new BarDatasetCollection();
        }

        /// <summary>
        /// Gets the labels the chart will use.
        /// <para>
        /// If defined (1 or more labels) the corresponding axis has to be of type
        /// <see cref="Common.Enums.AxisType.Category"/> for the chart to work correctly.
        /// </para>
        /// </summary>
        public List<string> Labels { get; }

        /// <summary>
        /// Gets the datasets displayed in this chart.
        /// </summary>
        public BarDatasetCollection Datasets { get; }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        [Obsolete("json.net", true)]
        public bool ShouldSerializeLabels() => Labels.Count > 0;
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
    }
}
