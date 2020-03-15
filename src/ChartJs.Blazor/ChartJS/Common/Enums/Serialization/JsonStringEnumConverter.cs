﻿using Newtonsoft.Json;
using System;
using System.Collections.Concurrent;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace ChartJs.Blazor.ChartJS.Common.Enums.Serialization
{
    internal class JsonStringEnumConverter : JsonConverter<StringEnum>
    {
        private static readonly Type[] s_stringParameterArray = new[] { typeof(string) };
        private static readonly ConcurrentDictionary<Type, ConstructorInfo> s_constructorCache = new ConcurrentDictionary<Type, ConstructorInfo>();

        public override StringEnum ReadJson(JsonReader reader, Type objectType, [AllowNull] StringEnum existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            switch (reader.TokenType)
            {
                case JsonToken.Null:
                case JsonToken.Undefined:
                    return null;
                case JsonToken.String:
                    ConstructorInfo constructor = s_constructorCache.GetOrAdd(objectType, GetStringConstructor);

                    return (StringEnum)constructor.Invoke(new[] { reader.Value });
                default:
                    throw new JsonSerializationException($"Unexpected token while deserializing {nameof(StringEnum)} ({objectType.Name}): {reader.TokenType}");
            }
        }

        public override void WriteJson(JsonWriter writer, StringEnum value, JsonSerializer serializer)
        {
            // ToString was overwritten by StringEnum -> safe to just print the string representation
            writer.WriteValue(value.ToString());
        }

        private ConstructorInfo GetStringConstructor(Type type) =>
            type.GetConstructor(BindingFlags.Instance | BindingFlags.NonPublic, null, s_stringParameterArray, null);
    }
}
