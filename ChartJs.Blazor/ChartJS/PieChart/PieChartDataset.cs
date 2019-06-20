using System.Collections.Generic;
using ChartJs.Blazor.ChartJS.Common;

namespace ChartJs.Blazor.ChartJS.PieChart
{
    public class PieChartDataset
    {
        public string Type { get; } = ChartTypes.PIE.ToString();

        /// <summary>
        /// The label for the dataset which appears in the legend and tooltips.
        /// </summary>
        public string Label { get; set; } = "";

        /// <summary>
        /// The fill color of the arcs in the dataset
        /// </summary>
        public string[] BackgroundColor { get; set; }

        /// <summary>
        /// The border color of the arcs in the dataset.
        /// </summary>
        public string BorderColor { get; set; }

        /// <summary>
        /// The border width of the arcs in the dataset.
        /// </summary>
        public int BorderWidth { get; set; }

        /// <summary>
        /// The fill colour of the arcs when hovered.
        /// </summary>
        public string[] HoverBackgroundColor { get; set; }

        /// <summary>
        /// The stroke colour of the arcs when hovered.
        /// </summary>
        public string[] HoverBorderColor { get; set; }

        /// <summary>
        /// The stroke width of the arcs when hovered.
        /// </summary>
        public int[] HoverBorderWidth { get; set; }

        public List<int> Data { get; set; }
    }
}