using ChartJs.Blazor.ChartJS.Common.Enums;
using System.Collections.Generic;

namespace ChartJs.Blazor.ChartJS.DoughnutChart
{
    /// <summary>
    /// A dataset for a <see cref="Charts.ChartJsDoughnutChart"/>
    /// </summary>
    public class DoughnutDataset
    {
        /// <summary>
        /// Gets or sets the chart type. Doughnut in this case.
        /// </summary>
        public ChartTypes Type { get; } = ChartTypes.Doughnut;

        /// <summary>
        /// Gets or sets the label of the dataset.
        /// </summary>
        public string Label { get; set; } = "";

        /// <summary>
        /// Gets or sets the fill color of the arcs in the dataset.
        /// </summary>
        public string[] BackgroundColor { get; set; }

        /// <summary>
        /// Gets or sets the border color of the arcs in the dataset.
        /// </summary>
        public string[] BorderColor { get; set; }

        /// <summary>
        /// Gets or sets the border width of the arcs in the dataset.
        /// </summary>
        public int BorderWidth { get; set; }

        /// <summary>
        /// Gets or sets the fill colour of the arcs when hovered.
        /// </summary>
        public string[] HoverBackgroundColor { get; set; }

        /// <summary>
        /// Gets or sets the stroke colour of the arcs when hovered.
        /// </summary>
        public string[] HoverBorderColor { get; set; }

        /// <summary>
        /// Gets or sets the stroke width of the arcs when hovered.
        /// </summary>
        public int[] HoverBorderWidth { get; set; }

        /// <summary>
        /// Gets or sets the data in the dataset.
        /// </summary>
        public List<double> Data { get; set; }
    }
}