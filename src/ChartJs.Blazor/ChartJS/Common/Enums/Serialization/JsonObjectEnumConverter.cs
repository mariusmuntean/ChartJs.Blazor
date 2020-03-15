using Newtonsoft.Json;
using System;
using System.Collections.Concurrent;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace ChartJs.Blazor.ChartJS.Common.Enums.Serialization
{
    internal class JsonObjectEnumConverter : JsonConverter<ObjectEnum>
    {
        public override ObjectEnum ReadJson(JsonReader reader, Type objectType, [AllowNull] ObjectEnum existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null ||
                reader.TokenType == JsonToken.Undefined)
            {
                return null;
            }

            if (reader.Value == null)
            {
                /* Covers:
                 * - All token types that result in reader.Value not being assigned (yet) except null and undefined
                 *   Examples are: StartArray, StartObject, ..
                 */
                throw new NotSupportedException($"Deserializing ObjectEnums from token type '{reader.TokenType}' isn't supported.");
            }

            Type readerValueType = reader.Value.GetType();
            /* The Type of reader.Value isn't always what it was when it was serialized.
             * An issue pointing that out: https://github.com/dotnet/orleans/issues/1269#issuecomment-171233788
             * - Any integer number will be of type System.Int64 unless its smaller
             *   than Int64.MinValue or higher than Int64.MaxValue, then it will be of type System.Numerics.BigInteger
             * - Any non-integer number will be of type System.Double
             *
             * Either we only support Int32 and cast down every Int64 since chart.js doesn't have high values anyway
             * or we try to find a matching constructor. Int32 is much more common in the enums but the json.net
             * default is Int64.. we need to find a good match which doesn't hurt performance too much.
             * We could first try to see if there is an Int64/BigInteger constructor (just search for Value.GetType())
             * and if there isn't one, cast down to Int32 (throw on overflow) and then try again. This would probably
             * not be much slower than directly casting to Int32 and passing it into the factory.
             */

            ObjectEnumFactory factory = ObjectEnumFactory.GetFactory(objectType);
            if (factory.CanConvertFrom(readerValueType))
                throw new NotSupportedException($"Deserialization {nameof(ObjectEnum)} '{objectType.FullName}' from '{readerValueType.Name}' not supported.");

            return factory.Create(reader.Value);
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
