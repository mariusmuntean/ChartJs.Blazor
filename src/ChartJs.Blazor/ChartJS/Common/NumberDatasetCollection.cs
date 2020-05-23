using System;
using System.Collections.Generic;
using System.Text;

namespace ChartJs.Blazor.ChartJS.Common
{
    /// <summary>
    /// Represents a <see cref="DatasetCollection"/> that can contain number datasets.
    /// </summary>
    public class NumberDatasetCollection : DatasetCollection
    {
        /// <summary>
        /// Adds a dataset to the end of the <see cref="NumberDatasetCollection"/>.
        /// </summary>
        /// <param name="dataset">
        /// The dataset to be added to the end of the <see cref="NumberDatasetCollection"/>.
        /// The value can't be null.
        /// </param>
        public void Add(IDataset<int> dataset) => AddDataset(dataset);

        /// <inheritdoc cref="Add(IDataset{int})"/>
        public void Add(IDataset<long> dataset) => AddDataset(dataset);

        /// <inheritdoc cref="Add(IDataset{int})"/>
        public void Add(IDataset<double> dataset) => AddDataset(dataset);
    }
}