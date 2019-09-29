using System.Collections.Generic;
using ChartJs.Blazor.ChartJS.Common.Enums;

namespace ChartJs.Blazor.ChartJS.MixedChart
{
    /// <summary>
    /// The base class for a dataset that implements the covariant <see cref="IMixableDataset{TData}"/>
    /// </summary>
    /// <typeparam name="TData">Defines the type of data in this dataset. Use Wrappers from <see cref="Common.Wrappers"/> for value types.</typeparam>
    public abstract class BaseMixableDataset<TData> : IMixableDataset<TData> 
        where TData : class
    {
        /// <summary>
        /// The type of chart this dataset is for.
        /// </summary>
        public abstract ChartType Type { get; }

        private readonly List<TData> _data = new List<TData>();

        /// <summary>
        /// Adds an element to the end of the <see cref="Data"/>.
        /// </summary>
        /// <param name="data">Element to add</param>
        public void Add(TData data) => _data.Add(data);

        /// <summary>
        /// Adds the elements of the specified collection to the end of the <see cref="Data"/>.
        /// </summary>
        /// <param name="data">A collection of elements to add</param>
        public void AddRange(IEnumerable<TData> data) => _data.AddRange(data);

        /// <summary>
        /// The data contained in this dataset. Covariant through <see cref="IMixableDataset{TData}"/>.
        /// </summary>
        public IReadOnlyCollection<TData> Data => _data;


        /// <summary>
        /// If true, this instance represents a hidden dataset. Label will be rendered with a strike-through effect at the start.
        /// </summary>
        public bool Hidden { get; set; }
    }
}
