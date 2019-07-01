using Newtonsoft.Json;

namespace ChartJs.Blazor.ChartJS.LineChart.Wrappers
{
    public abstract class ValueWrapper<TData> where TData : struct
    {
        internal TData Value { get; }

        internal ValueWrapper(TData value) => Value = value;
    }
}
