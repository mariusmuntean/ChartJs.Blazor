using System.Collections.Generic;
using ChartJs.Blazor.ChartJS.Common.Enums;

namespace ChartJs.Blazor.ChartJS.PieChart
{
    /// <summary>
    /// A dataset for a <see cref="Charts.ChartJsPieChart"/>
    /// </summary>
    public class PieChartDataset
    {
        // Todo: Is this really needed? It's already configured in the pie chart config?
        /// <summary>
        /// Gets or sets the chart type. <see cref="ChartTypes.Pie"/> in this case.
        /// </summary>
        public ChartTypes Type { get; } = ChartTypes.Pie;

        /// <summary>
        /// Gets the fill color of the arcs in the dataset.
        /// </summary>
        public List<string> BackgroundColor { get; } = new List<string>();

        // Todo: Make this an enum later?!
        /// <summary>
        /// Gets or sets the border align. When 'center' is set, the borders of arcs next to each other will overlap.
        /// When 'inner' is set, it is guaranteed that all the borders are not overlap.
        /// </summary>
        public string BorderAlign { get; set; } = "center";

        /// <summary>
        /// Gets the border color of the arcs in the dataset.
        /// </summary>
        public List<string> BorderColor { get; } = new List<string>();

        /// <summary>
        /// Gets the border width of the arcs in the dataset.
        /// </summary>
        public List<int> BorderWidth { get; } = new List<int>();

        /// <summary>
        /// Gets the fill colour of the arcs when hovered.
        /// </summary>
        public List<string> HoverBackgroundColor { get; } = new List<string>();

        /// <summary>
        /// Gets the stroke colour of the arcs when hovered.
        /// </summary>
        public List<string> HoverBorderColor { get; } = new List<string>();

        /// <summary>
        /// Gets the stroke width of the arcs when hovered.
        /// </summary>
        public List<int> HoverBorderWidth { get; } = new List<int>();

        /// <summary>
        /// Gets or sets the relative thickness of the dataset.
        /// Providing a value for weight will cause the pie dataset to be drawn with a thickness relative to the sum of all the dataset weight values.
        /// </summary>
        public int Weight { get; set; } = 1;

        /// <summary>
        /// Gets the data in the dataset.
        /// </summary>
        public List<double> Data { get; } = new List<double>();
    }
}