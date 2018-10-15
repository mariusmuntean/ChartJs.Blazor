using ChartJs.Blazor.ChartJS.MixedChart;
using System.Collections.Generic;

namespace ChartJs.Blazor.ChartJS.BarChart
{
    public class BarChartDataset : IMixableDataset
    {
        public int BorderWidth { get; set; } = 1;
        public string Type { get; } = ChartTypes.BAR.ToString();

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

        public List<object> Data { get; set; }

        /// <summary>
        /// The label for the dataset which appears in the legend and tooltips.
        /// </summary>
        public string Label { get; set; } = "";
    }
}