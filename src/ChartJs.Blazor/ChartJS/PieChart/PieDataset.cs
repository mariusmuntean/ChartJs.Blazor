using System;
using System.Collections.Generic;
using ChartJs.Blazor.ChartJS.Common;
using ChartJs.Blazor.ChartJS.Common.Enums;
using ChartJs.Blazor.Util;

namespace ChartJs.Blazor.ChartJS.PieChart
{
    /// <summary>
    /// A dataset for a <see cref="Charts.ChartJsPieChart"/>
    /// </summary>
    public class PieDataset : IDataset
    {
        public string Id { get; } = Guid.NewGuid().ToString();

        /// <summary>
        /// Gets or sets the chart type. <see cref="ChartType.Pie"/> in this case. This is needed for mixed datasets only.
        /// </summary>
        public ChartType Type { get; } = ChartType.Pie;

        /// <summary>
        /// Gets or sets the fill color of the arcs in the dataset.
        /// This property should be indexed, otherwise you can't distinguish the different arcs.
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