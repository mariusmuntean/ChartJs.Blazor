using System;
using System.Collections.Generic;
using System.Text;
using ChartJs.Blazor.ChartJS.Common;
using ChartJs.Blazor.ChartJS.Common.Time;

namespace ChartJs.Blazor.ChartJS.BarChart
{
    /// <summary>
    /// Represents a <see cref="DatasetCollection"/> that can contain
    /// number datasets, time-point datasets and floating bar datasets.
    /// </summary>
    public class BarDatasetCollection : NumberDatasetCollection
    {
        /// <summary>
        /// Adds a dataset to the end of the <see cref="BarDatasetCollection"/>.
        /// </summary>
        /// <param name="dataset">
        /// The dataset to be added to the end of the <see cref="BarDatasetCollection"/>.
        /// The value can't be null.
        /// </param>
        public void Add(IDataset<TimePoint> dataset) => AddDataset(dataset);

        /// <inheritdoc cref="Add(IDataset{TimePoint})"/>
        public void Add(IDataset<FloatingBarPoint> dataset) => AddDataset(dataset);
    }
}
