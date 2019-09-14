using Newtonsoft.Json;

namespace ChartJs.Blazor.ChartJS.Common.Wrappers
{
    [JsonConverter(typeof(JsonValueWrapperConverter<FloatWrapper, float>))]
    public sealed class FloatWrapper : ValueWrapper<float>
    {
        public FloatWrapper(float value) : base(value) { }

        public static implicit operator float(FloatWrapper value) => value.Value;
        public static implicit operator FloatWrapper(float value) => new FloatWrapper(value);
    }
}
