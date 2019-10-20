using Newtonsoft.Json;
using System;

namespace ChartJs.Blazor.ChartJS.Common.Wrappers
{
    [JsonConverter(typeof(JsonValueWrapperConverter<Int16Wrapper, Int16>))]
    public sealed class Int16Wrapper : ValueWrapper<Int16>
    {
        public Int16Wrapper(Int16 value) : base(value) { }

        public static implicit operator Int16(Int16Wrapper value) => value.Value;
        public static implicit operator Int16Wrapper(Int16 value) => new Int16Wrapper(value);
    }
}
