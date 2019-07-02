using Newtonsoft.Json;
using System;

namespace ChartJs.Blazor.ChartJS.Common.Wrappers
{
    [JsonConverter(typeof(JsonValueWrapperConverter<ByteWrapper, Byte>))]
    public sealed class ByteWrapper : ValueWrapper<Byte>
    {
        public ByteWrapper(Byte value) : base(value) { }

        public static implicit operator Byte(ByteWrapper value) => value.Value;
        public static implicit operator ByteWrapper(Byte value) => new ByteWrapper(value);
    }
}
