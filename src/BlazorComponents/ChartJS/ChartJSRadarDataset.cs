namespace BlazorComponents.ChartJS
{
    public class ChartJSRadarDataset : ChartJsDataset
    {
        public int BorderWidth { get; set; } = 1;
        public string PointBackgroundColor { get; set; } = "#DB5571";
        public string PointBorderColor { get; set; } = "#6D2A39";
        public int PointBorderWidth { get; set; } = 1;
        public int PointRadius { get; set; } = 1;
        public RadarChartPointStyles RadarChartPointStyle { get; set; } = RadarChartPointStyles.circle;

        public string PointStyle
        {
            get { return RadarChartPointStyle.ToString(); }
        }

        public override string Type { get; } = ChartTypes.RADAR.ToString();

        /// <summary>
        /// The fill color under the line. 
        /// AS-IS: We only accept colors as string values. Normal colors and HTML Hex colors are ok to use.
        /// TODO: Accept some form of actual color information rather than strings.
        /// </summary>
        public string BackgroundColor { get; set; }

        /// <summary>
        /// The color of the line
        /// AS-IS: We only accept string colors.
        /// TODO: Accept some form of actual color information rather than strings.
        /// </summary>
        public string BorderColor { get; set; }
    }

    public enum RadarChartPointStyles
    {
        circle,
        cross,
        crossRot,
        dash,
        line,
        rect,
        rectRounded,
        rectRot,
        star,
        triangle,
    }

    //public class RadarChartPointStyles
    //{
    //    const string CIRCLE = "circle";
    //    const string CROSS = "cross";
    //    const string CROSS_ROT = "crossRot";
    //    const string DASH = "dash";
    //    const string LINE = "line";
    //    const string RECT = "rect";
    //    const string RECT_ROUNDED = "rectRounded";
    //    const string RECT_ROT = "rectRot";
    //    const string STAR = "star";
    //    const string TRIANGLE = "triangle";

    //}
}