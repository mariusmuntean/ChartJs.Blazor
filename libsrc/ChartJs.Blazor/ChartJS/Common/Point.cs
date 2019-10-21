using Newtonsoft.Json;

namespace ChartJs.Blazor.ChartJS.Common
{
    public class Point
    {
        public Point() { }

        public Point(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }

        [JsonProperty("x")]
        public double X { get; set; }

        [JsonProperty("y")]
        public double Y { get; set; }
    }
}