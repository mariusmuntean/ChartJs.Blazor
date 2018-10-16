using ChartJs.Blazor.Util.Color;

namespace ChartJs.Blazor.ChartJS.BarChart.Dataset
{
    /// <summary>
    /// Dataset for Bar Chart. Source: http://www.chartjs.org/docs/latest/charts/bar.html#dataset-properties
    ///
    /// </summary>
    public class BarChartDataset : BaseBarChartDataset
    {
        /// <summary>
        /// The fill color of the bar
        /// </summary>
        public string BackgroundColor { get; set; } = ColorUtil.ColorString(128, 128, 128, 0.35);

        /// <summary>
        /// The color of the bar border.
        /// </summary>
        public string BorderColor { get; set; } = ColorUtil.ColorString(128, 128, 128, 0.35);

        /// <summary>
        /// The stroke width of the bar in pixels.
        /// </summary>
        public int BorderWidth { get; set; } = 1;

        /// <summary>
        /// The fill color of the bars when hovered.
        /// </summary>
        public string HoverBackgroundColor { get; set; } = ColorUtil.ColorString(128, 128, 128, 0.35);

        /// <summary>
        /// The stroke color of the bars when hovered.
        /// </summary>
        public string HoverBorderColor { get; set; } = ColorUtil.ColorString(128, 128, 128, 0.35);

        /// <summary>
        /// The stroke width of the bars when hovered.
        /// </summary>
        public int HoverBorderWidth { get; set; } = 1;
    }
}