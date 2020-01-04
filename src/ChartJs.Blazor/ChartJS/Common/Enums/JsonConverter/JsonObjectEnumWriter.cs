using Newtonsoft.Json;

namespace ChartJs.Blazor.ChartJS.Common.Enums.JsonConverter
{
    /// <summary>
    /// Newtonsoft JsonConverter for writing an <see cref="ObjectEnum"/> value. This JsonConverter can only write.
    /// </summary>
    internal class JsonObjectEnumWriter : JsonWriteOnlyConverter<ObjectEnum>
    {
        public override void WriteJson(JsonWriter writer, ObjectEnum wrapper, JsonSerializer serializer)
        {
            try
            {
                // if it can be written in a single JToken, 
                // json.net understands what type the wrapped object (.Value) is and serializes it accordingly -> correct value and type (eg. bool, string, double)
                writer.WriteValue(wrapper.Value);
            }
            catch (JsonWriterException)
            {
                // if there was an error, try to explicitly serialize it before writing
                // if this also fails just let it bubble up because the developer should not have values in their enum that fail here
                serializer.Serialize(writer, wrapper.Value);
            }
        }
    }
}
