using Newtonsoft.Json;
using System;
using System.Collections.Concurrent;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace ChartJs.Blazor.ChartJS.Common.Enums.JsonConverter
{
    internal class JsonStringEnumConverter : JsonConverter<StringEnum>
    {
        private static readonly ConcurrentDictionary<Type, ConstructorInfo> s_constructorCache = new ConcurrentDictionary<Type, ConstructorInfo>();

        public override sealed bool CanRead => true;
        public override sealed bool CanWrite => true;

        public override StringEnum ReadJson(JsonReader reader, Type objectType, [AllowNull] StringEnum existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            switch (reader.TokenType)
            {
                case JsonToken.Null:
                case JsonToken.Undefined:
                    return null;
                case JsonToken.String:
                    ConstructorInfo constructor = s_constructorCache.GetOrAdd(objectType,
                        type => type.GetConstructor(BindingFlags.Instance | BindingFlags.NonPublic, null, new[] { typeof(string) }, null));

                    return (StringEnum)constructor.Invoke(new[] { reader.Value });
                default:
                    throw new JsonSerializationException($"Unexpected Token while deserializing {nameof(StringEnum)} ({objectType.Name}): {reader.TokenType}");
            }
        }

        public override void WriteJson(JsonWriter writer, StringEnum value, JsonSerializer serializer)
        {
            // ToString was overwritten by StringEnum -> safe to just print the string representation
            writer.WriteValue(value.ToString());
        }
    }
}
