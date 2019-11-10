using System;
using System.Collections.Generic;
using ChartJs.Blazor.ChartJS.Common.Enums;

namespace ChartJs.Blazor.ChartJS.MixedChart
{
    /// <summary>
    /// The base class for a dataset that implements the covariant <see cref="IMixableDataset{TData}"/>
    /// </summary>
    /// <typeparam name="TData">Defines the type of data in this dataset. Use Wrappers from <see cref="Common.Wrappers"/> for value types.</typeparam>
    public abstract class BaseMixableDataset<TData> : IMixableDataset<TData> where TData : class
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

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

        /// <summary>Removes the first occurrence of a specific object from the <see cref="T:System.Collections.Generic.List`1"></see>.</summary>
        /// <param name="item">The object to remove from the <see cref="T:System.Collections.Generic.List`1"></see>. The value can be null for reference types.</param>
        /// <returns>true if <paramref name="item">item</paramref> is successfully removed; otherwise, false.  This method also returns false if <paramref name="item">item</paramref> was not found in the <see cref="T:System.Collections.Generic.List`1"></see>.</returns>
        public bool Remove(TData element) => _data.Remove(element);
        
        /// <summary>Removes all the elements that match the conditions defined by the specified predicate.</summary>
        /// <param name="match">The <see cref="T:System.Predicate`1"></see> delegate that defines the conditions of the elements to remove.</param>
        /// <returns>The number of elements removed from the <see cref="T:System.Collections.Generic.List`1"></see> .</returns>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="match">match</paramref> is null.</exception>
        public int RemoveAll(Predicate<TData> element) => _data.RemoveAll(element);
        
        /// <summary>Removes the element at the specified index of the <see cref="T:System.Collections.Generic.List`1"></see>.</summary>
        /// <param name="index">The zero-based index of the element to remove.</param>
        /// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="index">index</paramref> is less than 0.   -or-  <paramref name="index">index</paramref> is equal to or greater than <see cref="P:System.Collections.Generic.List`1.Count"></see>.</exception>
        public void RemoveAt(int index) => _data.RemoveAt(index);
        
        /// <summary>Removes a range of elements from the <see cref="T:System.Collections.Generic.List`1"></see>.</summary>
        /// <param name="index">The zero-based starting index of the range of elements to remove.</param>
        /// <param name="count">The number of elements to remove.</param>
        /// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="index">index</paramref> is less than 0.   -or-  <paramref name="count">count</paramref> is less than 0.</exception>
        /// <exception cref="T:System.ArgumentException"><paramref name="index">index</paramref> and <paramref name="count">count</paramref> do not denote a valid range of elements in the <see cref="T:System.Collections.Generic.List`1"></see>.</exception>
        public void RemoveRange(int index, int count) => _data.RemoveRange(index, count);

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