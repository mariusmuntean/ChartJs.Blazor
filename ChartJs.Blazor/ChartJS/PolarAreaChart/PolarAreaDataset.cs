using ChartJs.Blazor.ChartJS.Common.Enums;
using ChartJs.Blazor.Charts;
using ChartJs.Blazor.Util.Color;
using System.Collections.Generic;

namespace ChartJs.Blazor.ChartJS.PolarAreaChart
{
    /// <summary>
    /// A dataset for a <see cref="ChartJsPolarAreaChart"/>
    /// </summary>
    public class PolarAreaDataset
    {
        /// <summary>
        /// Gets the chart type. <see cref="ChartTypes.PolarArea"/> in this case. This is needed for mixed datasets only.
        /// </summary>
        public ChartTypes Type { get; } = ChartTypes.PolarArea;

        /// <summary>
        /// Gets the fill color of the arcs in the dataset.
        /// <para>See <see cref="ColorUtil"/> for working with colors.</para>
        /// </summary>
        public List<string> BackgroundColor { get; } = new List<string>();

        // Todo: Make this an enum later?!
        /// <summary>
        /// Gets or sets the border align. When 'center' is set, the borders of arcs next to each other will overlap.
        /// When 'inner' is set, it is guaranteed that all the borders are not overlap.
        /// </summary>
        public string BorderAlign { get; set; }

        /// <summary>
        /// Gets the border color of the arcs in the dataset.
        /// <para>See <see cref="ColorUtil"/> for working with colors.</para>
        /// </summary>
        public List<string> BorderColor { get; } = new List<string>();

        /// <summary>
        /// Gets the border width of the arcs in the dataset.
        /// </summary>
        public List<int> BorderWidth { get; } = new List<int>();

        /// <summary>
        /// Gets the fill colour of the arcs when hovered.
        /// <para>See <see cref="ColorUtil"/> for working with colors.</para>
        /// </summary>
        public List<string> HoverBackgroundColor { get; } = new List<string>();

        /// <summary>
        /// Gets the stroke colour of the arcs when hovered.
        /// <para>See <see cref="ColorUtil"/> for working with colors.</para>
        /// </summary>
        public List<string> HoverBorderColor { get; } = new List<string>();

        /// <summary>
        /// Gets the stroke width of the arcs when hovered.
        /// </summary>
        public List<int> HoverBorderWidth { get; } = new List<int>();

        /// <summary>
        /// Gets the data in the dataset.
        /// </summary>
        public List<double> Data { get; } = new List<double>();
    }
}