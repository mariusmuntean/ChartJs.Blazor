using System.Collections.Generic;

namespace ChartJs.Blazor.ChartJS.PieChart
{
    public class PieChartDataset
    {
        /// <summary>
        /// The label for the dataset which appears in the legend and tooltips.
        /// </summary>
        public string Label { get; set; } = "";

        public string Type { get; } = ChartTypes.PIE.ToString();

        public int BorderWidth { get; set; }
        public string[] HoverBackgroundColor { get; set; }
        public string[] HoverBorderColor { get; set; }
        public int[] HoverBorderWidth { get; set; }

        /// <summary>
        /// The fill color under the line.
        /// AS-IS: We only accept colors as string values. Normal colors and HTML Hex colors are ok to use.
        /// TODO: Accept some form of actual color information rather than strings.
        /// </summary>
        public string[] BackgroundColor { get; set; }

        /// <summary>
        /// The color of the line
        /// AS-IS: We only accept string colors.
        /// TODO: Accept some form of actual color information rather than strings.
        /// </summary>
        public string BorderColor { get; set; }

        public List<int> Data { get; set; }
    }
}