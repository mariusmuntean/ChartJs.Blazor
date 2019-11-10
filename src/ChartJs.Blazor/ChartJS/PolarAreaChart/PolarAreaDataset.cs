using System;
using ChartJs.Blazor.ChartJS.Common;
using ChartJs.Blazor.ChartJS.Common.Enums;
using ChartJs.Blazor.Charts;
using ChartJs.Blazor.Util;
using System.Collections.Generic;

namespace ChartJs.Blazor.ChartJS.PolarAreaChart
{
    /// <summary>
    /// A dataset for a <see cref="ChartJsPolarAreaChart"/>
    /// </summary>
    public class PolarAreaDataset : IDataset
    {
        public string Id { get; } = Guid.NewGuid().ToString();

        /// <summary>
        /// Gets the chart type. <see cref="ChartType.PolarArea"/> in this case. This is needed for mixed datasets only.
        /// </summary>
        public ChartType Type { get; } = ChartType.PolarArea;

        /// <summary>
        /// Gets or sets the fill color of the arcs in the dataset.
        /// <para>See <see cref="ColorUtil"/> for working with colors.</para>
        /// </summary>
        public IndexableOption<string> BackgroundColor { get; set; }

        /// <summary>
        /// Gets or sets the border align. When <see cref="BorderAlign.Center" /> is set, the borders of arcs next to each other will overlap.
        /// When <see cref="BorderAlign.Inner" /> is set, it is guaranteed that all the borders are not overlap.
        /// </summary>
        public IndexableOption<BorderAlign> BorderAlign { get; set; }

        /// <summary>
        /// Gets or sets the border color of the arcs in the dataset.
        /// <para>See <see cref="ColorUtil"/> for working with colors.</para>
        /// </summary>
        public IndexableOption<string> BorderColor { get; set; }

        /// <summary>
        /// Gets or sets the border width of the arcs in the dataset.
        /// </summary>
        public IndexableOption<int> BorderWidth { get; set; }

        /// <summary>
        /// Gets or sets the fill colour of the arcs when hovered.
        /// <para>See <see cref="ColorUtil"/> for working with colors.</para>
        /// </summary>
        public IndexableOption<string> HoverBackgroundColor { get; set; }

        /// <summary>
        /// Gets or sets the stroke colour of the arcs when hovered.
        /// <para>See <see cref="ColorUtil"/> for working with colors.</para>
        /// </summary>
        public IndexableOption<string> HoverBorderColor { get; set; }

        /// <summary>
        /// Gets or sets the stroke width of the arcs when hovered.
        /// </summary>
        public IndexableOption<int> HoverBorderWidth { get; set; }

        /// <summary>
        /// Gets the data in the dataset.
        /// </summary>
        public List<double> Data { get; } = new List<double>();
    }
}