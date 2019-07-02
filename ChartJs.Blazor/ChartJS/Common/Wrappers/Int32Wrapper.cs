using Newtonsoft.Json;
using System;

namespace ChartJs.Blazor.ChartJS.Common.Wrappers
{
    [JsonConverter(typeof(JsonValueWrapperConverter<Int32Wrapper, Int32>))]
    public sealed class Int32Wrapper : ValueWrapper<Int32>
    {
        public Int32Wrapper(Int32 value) : base(value) { }

        public static implicit operator Int32(Int32Wrapper value) => value.Value;
        public static implicit operator Int32Wrapper(Int32 value) => new Int32Wrapper(value);
    }
}
