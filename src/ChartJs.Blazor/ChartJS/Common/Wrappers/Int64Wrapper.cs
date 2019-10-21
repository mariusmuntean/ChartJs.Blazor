using Newtonsoft.Json;
using System;

namespace ChartJs.Blazor.ChartJS.Common.Wrappers
{
    [JsonConverter(typeof(JsonValueWrapperConverter<Int64Wrapper, Int64>))]
    public sealed class Int64Wrapper : ValueWrapper<Int64>
    {
        public Int64Wrapper(Int64 value) : base(value) { }

        public static implicit operator Int64(Int64Wrapper value) => value.Value;
        public static implicit operator Int64Wrapper(Int64 value) => new Int64Wrapper(value);
    }
}
