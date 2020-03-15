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

            object value = reader.Value;
            Type readerValueType = value.GetType();
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

            // special case for long since json.net's default for number deserialization is long but our enums
            // use int (plus we only support int at the moment). BigInteger isn't supported at all.
            if (readerValueType == typeof(long))
            {
                long asLong = (long)value;
                if (asLong < int.MinValue ||
                    asLong > int.MaxValue)
                {
                    throw new OverflowException($"The deserialized number ({value}) is out of the range of int ({int.MinValue} - {int.MaxValue}).");
                }
                else
                {
                    value = (int)asLong;
                    readerValueType = typeof(int);
                }
            }

            if (factory.CanConvertFrom(readerValueType))
                throw new NotSupportedException($"Deserialization {nameof(ObjectEnum)} '{objectType.FullName}' from '{readerValueType.Name}' isn't supported.");

            return factory.Create(value);
        }

        public override void WriteJson(JsonWriter writer, ObjectEnum wrapper, JsonSerializer serializer)
        {
            Type wrappedType = wrapper.Value.GetType();
            if (!ObjectEnum.IsSupportedSerializationType(wrappedType))
            {
                throw new NotSupportedException($"The type '{wrappedType.FullName}' isn't supported for serialization " +
                                                $"within an instance of any {nameof(ObjectEnum)}-type.");
            }

            // The types we support can always be written in a single Token.
            // If that was not the case, we'd need to handle JsonWriterException here.
            writer.WriteValue(wrapper.Value);
        }
    }
}
