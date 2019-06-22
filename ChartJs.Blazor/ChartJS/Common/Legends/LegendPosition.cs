using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ChartJs.Blazor.ChartJS.Common.Legends
{
    [JsonConverter(typeof(JsonToStringConverter<LegendPosition>))]
    public class LegendPosition
    {
        public static LegendPosition Top => new LegendPosition("top");
        public static LegendPosition Right => new LegendPosition("right");
        public static LegendPosition Left => new LegendPosition("left");
        public static LegendPosition Bottom => new LegendPosition("bottom");

        
        private readonly string _position;
        private LegendPosition(string position)
        {
            _position = position;
        }

        public override string ToString()
        {
            return _position;
        }
    }
}