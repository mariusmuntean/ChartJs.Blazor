using Newtonsoft.Json;
using System;

namespace ChartJs.Blazor.ChartJS.Common.Enums.JsonConverter
{
    internal class JsonSteppedLineConverter : JsonWriteOnlyConverter<SteppedLine>
    {
        public override void WriteJson(JsonWriter writer, SteppedLine wrapper, JsonSerializer serializer)
        {
            switch (wrapper.Value)
            {
                case bool b:
                    writer.WriteValue(b);
                    break;
                case string s:
                    writer.WriteValue(s);
                    break;
                default:
                    throw new NotImplementedException($"The Type {wrapper.Value.GetType().Name} is not supported as a value of {wrapper.GetType().Name}");
            } 
        }
    }
}
