using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChartJs.Blazor.ChartJS.Common.Enums.JsonConverter
{
    // we need T and the constraint because the you can't use JsonConverter for the base-class
    // https://github.com/dotnet/corefx/issues/39905
    /// <summary>
    /// System.Text.Json JsonConverter for reading <see cref="StringEnum"/>s. The <see cref="StringEnum"/> is created via reflection
    /// and does not take in account what values actually exist in the "enum". This is not a big deal
    /// because the values that are deserialized using this converter should only come from chart.js and should be mapped correctly
    /// to an "enum"-value in that <see cref="StringEnum"/>.
    /// </summary>
    /// <typeparam name="T">The type of <see cref="StringEnum"/> this converter is for. This is required because System.Text.Json
    /// doesn't allow converters for base-classes yet.</typeparam>
    internal class JsonStringEnumReader<T> : JsonConverter<T>
        where T : StringEnum
    {
        private static readonly ConcurrentDictionary<Type, ConstructorInfo> s_constructorCache = new ConcurrentDictionary<Type, ConstructorInfo>();

        public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            ConstructorInfo constructor = s_constructorCache.GetOrAdd(typeToConvert,
                type => type.GetConstructor(BindingFlags.Instance | BindingFlags.NonPublic, null, new[] { typeof(string) }, null));

            return (T)constructor.Invoke(new[] { reader.GetString() });
        }

        public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }
    }
}
