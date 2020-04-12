using ChartJs.Blazor.ChartJS.Common.Time;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChartJs.Blazor.ChartJS.Common
{
    /// <summary>
    /// Represents a <see cref="DatasetCollection"/> that can contain number datasets and point datasets.
    /// </summary>
    public class NumberPointDatasetCollection : NumberDatasetCollection
    {
        /// <summary>
        /// Adds a dataset to the end of the <see cref="NumberPointDatasetCollection"/>.
        /// </summary>
        /// <param name="dataset">
        /// The dataset to be added to the end of the <see cref="NumberPointDatasetCollection"/>.
        /// The value can't be null.
        /// </param>
        public void Add(IDataset<Point> dataset) => AddDataset(dataset);

        /// <inheritdoc cref="Add(IDataset{Point})"/>
        public void Add(IDataset<TimePoint> dataset) => AddDataset(dataset);
    }
}