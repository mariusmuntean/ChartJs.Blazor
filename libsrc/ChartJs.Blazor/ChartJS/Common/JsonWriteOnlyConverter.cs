using Newtonsoft.Json;
using System;

namespace ChartJs.Blazor.ChartJS.Common
{
    internal abstract class JsonWriteOnlyConverter<T> : JsonConverter<T>
    {
        public override sealed bool CanRead => false;
        public override sealed bool CanWrite => true;

        public override sealed T ReadJson(JsonReader reader, Type objectType, T existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException("Don't use me to read JSON");
        }

        public abstract override void WriteJson(JsonWriter writer, T value, JsonSerializer serializer);
    }
}
