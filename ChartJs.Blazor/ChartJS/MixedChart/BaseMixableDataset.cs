using System;
using System.Collections.Generic;
using System.Text;
using ChartJs.Blazor.ChartJS.Common.Enums;

namespace ChartJs.Blazor.ChartJS.MixedChart
{
    /// <summary>
    /// The baseclass for a mixed chart.
    /// </summary>
    /// <typeparam name="TData">Defines the type of data in this dataset. Use Wrappers from <see cref="ChartJs.Blazor.ChartJS.LineChart.Wrappers"/> for value types.</typeparam>
    public abstract class BaseMixableDataset<TData> : IMixableDataset<TData> where TData : class
    {
        public abstract ChartTypes Type { get; }

        private readonly List<TData> _data = new List<TData>();

        public IReadOnlyCollection<TData> Data => _data;


        public void Add(TData data) => _data.Add(data);
        public void AddRange(IEnumerable<TData> data) => _data.AddRange(data);
    }
}
