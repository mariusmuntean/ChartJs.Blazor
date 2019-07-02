using ChartJs.Blazor.ChartJS.Common;
using ChartJs.Blazor.ChartJS.Common.Enums.JsonConverter;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

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
