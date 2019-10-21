using Newtonsoft.Json;

namespace ChartJs.Blazor.ChartJS.Common.Wrappers
{
    class JsonValueWrapperConverter<TWrapper, TData> : JsonWriteOnlyConverter<TWrapper> 
        where TData : struct 
        where TWrapper : ValueWrapper<TData>
    {
        //public override TWrapper ReadJson(JsonReader reader, Type objectType, TWrapper existingValue, bool hasExistingValue, JsonSerializer serializer)
        //{
        //    throw new NotImplementedException();        // don't know if this is used ever and if it's implemented correctly

        //    JToken token = JToken.Load(reader);
        //    TData val = token.ToObject<TData>();
        //    return (TWrapper)val;
        //}

        public override void WriteJson(JsonWriter writer, TWrapper value, JsonSerializer serializer)
        {
            writer.WriteValue(value.Value);
        }
    }
}
