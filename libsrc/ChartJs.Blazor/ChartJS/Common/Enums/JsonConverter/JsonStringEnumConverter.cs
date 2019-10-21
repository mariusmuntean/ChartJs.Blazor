using Newtonsoft.Json;

namespace ChartJs.Blazor.ChartJS.Common.Enums.JsonConverter
{
    /// <summary>
    /// JsonConverter for converting and writing a StringEnum value. This JsonConverter can only write.
    /// </summary>
    internal class JsonStringEnumConverter : JsonWriteOnlyConverter<StringEnum>
    {
        public override void WriteJson(JsonWriter writer, StringEnum value, JsonSerializer serializer)
        {
            // ToString was overwritten by StringEnum -> safe to just print the string representation
            writer.WriteValue(value.ToString());
        }
    }
}
