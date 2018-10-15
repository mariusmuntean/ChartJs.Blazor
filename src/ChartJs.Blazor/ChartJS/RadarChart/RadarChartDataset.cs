using System.Collections.Generic;

namespace ChartJs.Blazor.ChartJS.RadarChart
{
    public class RadarChartDataset
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

        public string Type { get; } = ChartTypes.RADAR.ToString();

        /// <summary>
        /// The label for the dataset which appears in the legend and tooltips.
        /// </summary>
        public string Label { get; set; } = "";

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

        public List<int> Data { get; set; }
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
}