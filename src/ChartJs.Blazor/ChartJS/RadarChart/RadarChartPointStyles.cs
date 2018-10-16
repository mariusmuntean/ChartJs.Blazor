namespace ChartJs.Blazor.ChartJS.RadarChart
{
    public class RadarChartPointStyles
    {
        private readonly string _style;

        //circle,
        //cross,
        //crossRot,
        //dash,
        //line,
        //rect,
        //rectRounded,
        //rectRot,
        //star,
        //triangle,

        public static RadarChartPointStyles CIRCLE = new RadarChartPointStyles("circle");
        public static RadarChartPointStyles CROSS = new RadarChartPointStyles("cross");
        public static RadarChartPointStyles CROSSROT = new RadarChartPointStyles("crossRot");
        public static RadarChartPointStyles DASH = new RadarChartPointStyles("dash");
        public static RadarChartPointStyles LINE = new RadarChartPointStyles("line");
        public static RadarChartPointStyles RECT = new RadarChartPointStyles("rect");
        public static RadarChartPointStyles RETROUNDED = new RadarChartPointStyles("rectRounded");
        public static RadarChartPointStyles RECTROT = new RadarChartPointStyles("rectRot");
        public static RadarChartPointStyles STAR = new RadarChartPointStyles("star");
        public static RadarChartPointStyles TRIANGLE = new RadarChartPointStyles("triangle");

        private RadarChartPointStyles(string style)
        {
            _style = style;
        }

        public override string ToString()
        {
            return _style;
        }
    }
}