using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ChartJs.Blazor.ChartJS.Common
{
    /// <summary>
    /// Represents a collection of datasets. This class implements <c>IList&lt;<see cref="IDataset"/>&gt;</c> but
    /// only supports adding datasets through protected methods. This means that classes which derive from this
    /// class, can implement their own <c>Add</c>-methods with the correct signature.
    /// It's important to name those methods <c>Add</c> for
    /// <a href="https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/object-and-collection-initializers#collection-initializers">
    /// collection initializers</a> to work. Doing this along with implementing the original <see cref="ICollection{T}.Add(T)"/>
    /// explicitly, allows for compile time type safety even though you can add different types to this <see cref="DatasetCollection"/>.
    /// This collection doesn't allow <see langword="null"/> values.
    /// <para>
    /// Calling <see cref="ICollection{T}.Add(T)"/> or <see cref="IList{T}.Insert(int, T)"/> will throw a <see cref="NotSupportedException"/>.
    /// Use <see cref="AddDataset(IDataset)"/> and <see cref="InsertDataset(int, IDataset)"/> instead.
    /// The other modification members like <see cref="ICollection{T}.Remove(T)"/> can be called with objects that are impossible to add
    /// since it doesn't break the instance, the call will just fail (in the case of <see cref="ICollection{T}.Remove(T)"/>, return <see langword="false"/>).
    /// Compile time type safety isn't as valuable there.
    /// </para>
    /// </summary>
    public abstract class DatasetCollection : IReadOnlyList<IDataset>, IList<IDataset>
    {
        private const string NotSupportedMessageModificationThroughInterface =
            "This collection doesn't support adding datasets through the IList and ICollection interfaces.";
        private readonly List<IDataset> _datasets;

        /// <summary>
        /// Gets the number of elements contained in the <see cref="DatasetCollection"/>.
        /// </summary>
        [JsonIgnore]
        public int Count => _datasets.Count;
        bool ICollection<IDataset>.IsReadOnly => false;

        IDataset IList<IDataset>.this[int index]
        {
            get => this[index];
            set => ThrowNotSupported();
        }

        /// <summary>
        /// Gets the dataset at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index of the dataset to get.</param>
        /// <returns>The dataset at the specified <paramref name="index"/>.</returns>
        public IDataset this[int index] => _datasets[index];

        /// <summary>
        /// Creates a new empty <see cref="DatasetCollection"/>.
        /// </summary>
        protected DatasetCollection()
        {
            _datasets = new List<IDataset>();
        }

        /// <summary>
        /// Determines whether an element is in the <see cref="DatasetCollection"/>.
        /// </summary>
        /// <param name="dataset">The dataset to locate in the <see cref="DatasetCollection"/>. The value can't be null.</param>
        /// <returns><see langword="true"/> if <paramref name="dataset"/> is found in the <see cref="DatasetCollection"/>;
        /// otherwise, <see langword="false"/>.</returns>
        public bool Contains(IDataset dataset) => _datasets.Contains(dataset ?? throw new ArgumentNullException(nameof(dataset)));

        /// <summary>
        /// Copies the entire <see cref="DatasetCollection"/> to a compatible one-dimensional
        /// array, starting at the specified index of the target array.
        /// </summary>
        /// <param name="array">The one-dimensional <see cref="Array"/> that is the destination of the elements copied
        /// from this <see cref="DatasetCollection"/>. The <see cref="Array"/> must have zero-based indexing.</param>
        /// <param name="index">The zero-based index in <paramref name="array"/> at which copying begins.</param>
        public void CopyTo(IDataset[] array, int index) => _datasets.CopyTo(array, index);

        /// <summary>
        /// Returns an enumerator that iterates through the <see cref="DatasetCollection"/>.
        /// </summary>
        /// <returns>An enumerator for the <see cref="DatasetCollection"/>.</returns>
        public IEnumerator<IDataset> GetEnumerator() => _datasets.GetEnumerator();

        /// <summary>
        /// Searches for the specified object and returns the zero-based index of the first
        /// occurrence within the entire <see cref="DatasetCollection"/>.
        /// </summary>
        /// <param name="dataset">The dataset to locate in the <see cref="DatasetCollection"/>. The value can't be null.</param>
        /// <returns>The zero-based index of the first occurrence of <paramref name="dataset"/> within the entire,
        /// <see cref="DatasetCollection"/> if found; otherwise, -1.</returns>
        public int IndexOf(IDataset dataset) => _datasets.IndexOf(dataset ?? throw new ArgumentNullException(nameof(dataset)));

        /// <summary>
        /// Adds a dataset to the end of the <see cref="DatasetCollection"/>.
        /// Do not expose this method publicly when extending this class. Call it from public <c>Add</c> methods with a more restricted signature.
        /// </summary>
        /// <param name="dataset">The dataset to be added to the end of the <see cref="DatasetCollection"/>. The value can't be null.</param>
        protected void AddDataset(IDataset dataset) => _datasets.Add(dataset ?? throw new ArgumentNullException(nameof(dataset)));

        /// <summary>
        /// Inserts a dataset into the <see cref="DatasetCollection"/> at the specified <paramref name="index"/>.
        /// Do not expose this method publicly when extending this class. Call it from public <c>Add</c> methods with a more restricted signature.
        /// </summary>
        /// <param name="index">The zero-based index at which <paramref name="dataset"/> should be inserted.</param>
        /// <param name="dataset">The dataset to insert. The value can't be null.</param>
        protected void InsertDataset(int index, IDataset dataset) => _datasets.Insert(index, dataset ?? throw new ArgumentNullException(nameof(dataset)));

        /// <summary>
        /// Removes the first occurrence of a specific dataset from the <see cref="DatasetCollection"/>.
        /// </summary>
        /// <param name="dataset">The dataset to remove from the <see cref="DatasetCollection"/>. The value can't be null.</param>
        /// <returns><see langword="true"/> if <paramref name="dataset"/> is successfully removed; otherwise, <see langword="false"/>.This method
        /// also returns <see langword="false"/> if <paramref name="dataset"/> was not found in the <see cref="DatasetCollection"/>.</returns>
        public bool Remove(IDataset dataset) => _datasets.Remove(dataset ?? throw new ArgumentNullException(nameof(dataset)));

        /// <summary>
        /// Removes the dataset at the specified index of the <see cref="DatasetCollection"/>.
        /// </summary>
        /// <param name="index">The zero-based index of the dataset to remove.</param>
        public void RemoveAt(int index) => _datasets.RemoveAt(index);

        /// <summary>
        /// Removes all datasets from the <see cref="DatasetCollection"/>.
        /// </summary>
        public void Clear() => _datasets.Clear();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        void IList<IDataset>.Insert(int index, IDataset item) => ThrowNotSupported();
        void ICollection<IDataset>.Add(IDataset item) => ThrowNotSupported();

        private void ThrowNotSupported() => throw new NotSupportedException(NotSupportedMessageModificationThroughInterface);
    }
}