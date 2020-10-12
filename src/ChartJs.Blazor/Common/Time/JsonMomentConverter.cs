using ChartJs.Blazor.Common;
using Newtonsoft.Json;

namespace ChartJs.Blazor.Common.Time
{
    internal class JsonMomentConverter : JsonWriteOnlyConverter<Moment>
    {
        public override void WriteJson(JsonWriter writer, Moment moment, JsonSerializer serializer)
        {
            writer.WriteValue(moment.ToString());
        }
    }
}
