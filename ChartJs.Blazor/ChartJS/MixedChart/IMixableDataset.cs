using ChartJs.Blazor.ChartJS.Common.Enums;
using System.Collections.Generic;

namespace ChartJs.Blazor.ChartJS.MixedChart
{
    /// <summary>
    /// Interface for a covariant dataset that can be mixed with other datasets.
    /// </summary>
    /// <typeparam name="TData">Defines the type of data in this dataset. Use Wrappers from <see cref="Common.Wrappers"/> for value types.</typeparam>
    public interface IMixableDataset<out TData>
    {
        /// <summary>
        /// The type of chart this dataset is for.
        /// </summary>
        ChartTypes Type { get; }

        /// <summary>
        /// The data contained in this dataset (readonly because covariant).
        /// </summary>
        IReadOnlyCollection<TData> Data { get; }
    }
}