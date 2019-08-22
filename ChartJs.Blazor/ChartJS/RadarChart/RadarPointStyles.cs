using Newtonsoft.Json;

namespace ChartJs.Blazor.ChartJS.RadarChart
{
    public class RadarPointStyles
    {
        private readonly string _style;

        public static RadarPointStyles CIRCLE = new RadarPointStyles("circle");
        public static RadarPointStyles CROSS = new RadarPointStyles("cross");
        public static RadarPointStyles CROSSROT = new RadarPointStyles("crossRot");
        public static RadarPointStyles DASH = new RadarPointStyles("dash");
        public static RadarPointStyles LINE = new RadarPointStyles("line");
        public static RadarPointStyles RECT = new RadarPointStyles("rect");
        public static RadarPointStyles RETROUNDED = new RadarPointStyles("rectRounded");
        public static RadarPointStyles RECTROT = new RadarPointStyles("rectRot");
        public static RadarPointStyles STAR = new RadarPointStyles("star");
        public static RadarPointStyles TRIANGLE = new RadarPointStyles("triangle");

        [JsonConstructor]
        public RadarPointStyles(string style)
        {
            _style = style;
        }

        public override string ToString()
        {
            return _style;
        }
    }
}