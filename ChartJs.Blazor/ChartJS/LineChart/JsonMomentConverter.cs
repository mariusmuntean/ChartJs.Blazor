using ChartJs.Blazor.ChartJS.Common;
using Newtonsoft.Json;

namespace ChartJs.Blazor.ChartJS.LineChart
{
    internal class JsonMomentConverter : JsonWriteOnlyConverter<Moment>
    {
        public override void WriteJson(JsonWriter writer, Moment moment, JsonSerializer serializer)
        {
            writer.WriteValue(moment.ToString());
        }
    }
}
