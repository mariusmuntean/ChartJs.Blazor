using Newtonsoft.Json;
using System;
using System.Collections.Concurrent;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace ChartJs.Blazor.ChartJS.Common.Enums.Serialization
{
    /* Currently supported token/types:
     * Integer -> int
     * Float -> double
     * String -> string
     * Boolean -> bool
     * Null -> null
     * Undefined -> null
     */
    internal class JsonObjectEnumConverter : JsonConverter<ObjectEnum>
    {
        private const string NotSupportedTokenMessage = "Deserializing ObjectEnums from token type '{0}' isn't supported. " +
                                                        "Supported tokens: {1}";

        private static readonly JsonToken[] s_supportedTokens = new[]
        {
            JsonToken.Null, JsonToken.Undefined, JsonToken.Boolean, JsonToken.Float, JsonToken.Integer, JsonToken.String
        };

        public override ObjectEnum ReadJson(JsonReader reader, Type objectType, [AllowNull] ObjectEnum existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            if (s_supportedTokens.Contains(reader.TokenType))
            {
                // the supported tokens are all primitive so we can just do it like this. See similar use case:
                // https://github.com/JamesNK/Newtonsoft.Json/blob/a31156e90a14038872f54eb60ff0e9676ca4a0d8/Src/Newtonsoft.Json/Converters/ExpandoObjectConverter.cs#L81
                ObjectEnumFactory factory = ObjectEnumFactory.GetFactory(objectType);
                // TODO Check what c# types those token types produce and act accordingly here and in the 
                // summary of ObjectEnum. Maybe it's not double but float.
                // Another way of checking this stuff would be to first check if the token type is primitive (https://github.com/JamesNK/Newtonsoft.Json/blob/master/Src/Newtonsoft.Json/Utilities/JsonTokenUtils.cs#L56)
                // and then ensure that reader.Value.GetType() returns one of the supported types for object enums.
                // if the type is supported in general but not for this specific enum type, factory.Create will throw.
                return factory.Create(reader.Value);
            }

            throw new NotSupportedException(string.Format(NotSupportedTokenMessage, reader.TokenType, string.Join(", ", s_supportedTokens)));
        }

        public override void WriteJson(JsonWriter writer, ObjectEnum wrapper, JsonSerializer serializer)
        {
            try
            {
                // TODO check if it's one of the supported types. Otherwise it might get serialized but can't be deserialized.
                // just make sure it's consistently the same with deserializing!
                writer.WriteValue(wrapper.Value);
            }
            catch (JsonWriterException)
            {
                // if the contained value can't be written in a single Token, deserialization isn't supported
                // so we won't support serializing it either.
                throw new NotSupportedException($"The type '{wrapper.Value.GetType().FullName}' isn't supported " +
                    $"in object enums because it cannot be written as a single token.");
            }
        }
    }
}
