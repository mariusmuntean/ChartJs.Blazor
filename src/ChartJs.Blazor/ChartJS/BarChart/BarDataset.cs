using ChartJs.Blazor.ChartJS.Common;
using ChartJs.Blazor.ChartJS.Common.Enums;
using ChartJs.Blazor.ChartJS.MixedChart;
using ChartJs.Blazor.Util;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace ChartJs.Blazor.ChartJS.BarChart
{
    /// <summary>
    /// Represents a dataset for a bar chart.
    /// As per documentation <a href="https://www.chartjs.org/docs/latest/charts/bar.html#dataset-properties">here (Chart.js)</a>.
    /// </summary>
    /// <typeparam name="T">The type of data this <see cref="BarDataset{T}"/> contains.</typeparam>
    public class BarDataset<T> : Dataset<T>
    {
        /// <summary>
        /// Creates a new instance of <see cref="BarDataset{T}"/>.
        /// </summary>
        public BarDataset() : base(ChartType.Bar) { }

        /// <summary>
        /// Creates a new instance of <see cref="BarDataset{T}"/> with initial data.
        /// </summary>
        public BarDataset(IEnumerable<T> data) : this()
        {
            AddRange(data);
        }

        /// <summary>
        /// Creates a new instance of <see cref="BarDataset{T}"/> with
        /// a custom <see cref="ChartType"/>. Use this constructor when
        /// you implement a bar-like chart.
        /// </summary>
        /// <param name="type">The <see cref="ChartType"/> to use instead of <see cref="ChartType.Bar"/>.</param>
        protected BarDataset(ChartType type) : base(type) { }

        /// <summary>
        /// Gets or sets a value to avoid drawing the bar stroke at the base of the fill.
        /// In general, this does not need to be changed except when creating chart types that derive from a bar chart.
        /// </summary>
        public IndexableOption<BorderSkipped> BorderSkipped { get; set; }

        /// <summary>
        /// Gets or sets the label for the dataset which appears in the legend and tooltips.
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// Gets or sets the ID of the x axis to plot this dataset on. If not specified,
        /// this defaults to the ID of the first found x axis.
        /// </summary>
        [JsonProperty("xAxisID")]
        public string XAxisId { get; set; }

        /// <summary>
        /// Gets or sets the ID of the y axis to plot this dataset on. If not specified,
        /// this defaults to the ID of the first found y axis.
        /// </summary>
        [JsonProperty("yAxisID")]
        public string YAxisId { get; set; }

        /// <summary>
        /// Gets or sets the id of the group to which this dataset belongs to (when stacked, each group will be a separate stack).
        /// <para>
        /// Specific for stacked bar charts.
        /// </para>
        /// </summary>
        public string Stack { get; set; }

        /// <summary>
        /// Gets or sets the fill color of the bars in the dataset.
        /// <para>See <see cref="ColorUtil"/> for working with colors.</para>
        /// </summary>
        public IndexableOption<string> BackgroundColor { get; set; }

        /// <summary>
        /// Gets or sets the border color of the bars in the dataset.
        /// <para>See <see cref="ColorUtil"/> for working with colors.</para>
        /// </summary>
        public IndexableOption<string> BorderColor { get; set; }

        /// <summary>
        /// Gets or sets the border width of the bars in the dataset.
        /// </summary>
        public IndexableOption<int> BorderWidth { get; set; }

        /// <summary>
        /// Gets or sets the fill color of the bars when hovered.
        /// <para>See <see cref="ColorUtil"/> for working with colors.</para>
        /// </summary>
        public IndexableOption<string> HoverBackgroundColor { get; set; }

        /// <summary>
        /// Gets or sets the stroke color of the bars when hovered.
        /// <para>See <see cref="ColorUtil"/> for working with colors.</para>
        /// </summary>
        public IndexableOption<string> HoverBorderColor { get; set; }

        /// <summary>
        /// Gets or sets the stroke width of the bars when hovered.
        /// </summary>
        public IndexableOption<int> HoverBorderWidth { get; set; }
    }
}
