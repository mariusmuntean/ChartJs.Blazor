using Newtonsoft.Json;
using System;

namespace ChartJs.Blazor.ChartJS.Common.Wrappers
{
    [JsonConverter(typeof(JsonValueWrapperConverter<DoubleWrapper, Double>))]
    public sealed class DoubleWrapper : ValueWrapper<Double>
    {
        public DoubleWrapper(Double value) : base(value) { }

        public static implicit operator Double(DoubleWrapper value) => value.Value;
        public static implicit operator DoubleWrapper(Double value) => new DoubleWrapper(value);
    }
}
