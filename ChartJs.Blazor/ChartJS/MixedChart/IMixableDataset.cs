using ChartJs.Blazor.ChartJS.BarChart.Dataset;
using ChartJs.Blazor.ChartJS.Common.Enums;
using ChartJs.Blazor.ChartJS.LineChart;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace ChartJs.Blazor.ChartJS.MixedChart
{
    [JsonConverter(typeof(MixableDatasetConverter))]
    public interface IMixableDataset
    {
        ChartTypes Type { get; }
        List<object> Data { get; set; }
    }

    public class MixableDatasetConverter : JsonConverter
    {
        public override bool CanRead => true;
        public override bool CanWrite => false;

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(IMixableDataset);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException("Don't use me to write JSON");
        }

        public override object ReadJson(JsonReader reader,
            Type objectType,
            object existingValue,
            JsonSerializer serializer)
        {
            JObject jObj = JObject.Load(reader);
            ChartTypes type = jObj.Value<ChartTypes>("Type") ?? jObj.Value<ChartTypes>("type");

            var dataset = default(IMixableDataset);
            switch ((string)type)
            {
                case "bar":
                {
                    dataset = new BarChartDataset();
                    break;
                }

                case "line":
                {
                    dataset = new LineChartDataset();
                    break;
                }
            }

            serializer.Populate(jObj.CreateReader(), dataset);

            return dataset;
        }
    }
}