using ChartJs.Blazor.ChartJS.Common;
using ChartJs.Blazor.ChartJS.Common.Enums;
using ChartJs.Blazor.ChartJS.MixedChart;
using ChartJs.Blazor.Util;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace ChartJs.Blazor.ChartJS.BarChart
{
    /// <summary>
    /// A dataset for a <see cref="Charts.ChartJsBarChart"/>.
    /// </summary>
    /// <para>As per documentation here: http://www.chartjs.org/docs/latest/charts/bar.html#dataset-properties. </para>
    /// <typeparam name="TData">Defines the type of data in this dataset. Use Wrappers from <see cref="Common.Wrappers"/> for value types.</typeparam>
    public class BarDataset<TData> : BaseMixableDataset<TData> where TData : class
    {
        /// <summary>
        /// Creates a new instance of the <see cref="BarDataset{TData}"/> class.
        /// </summary>
        /// <param name="data">The data to initialize the dataset with.</param>
        /// <param name="chartType">An optional <see cref="ChartType"/>, either <see cref="ChartType.Bar"/> or <see cref="ChartType.HorizontalBar"/></param>
        public BarDataset(IEnumerable<TData> data, ChartType? chartType = null) : this(chartType)
        {
            this.AddRange(data);
        }

        /// <summary>
        /// Creates a new instance of the <see cref="BarDataset{TData}"/> class.
        /// </summary>
        public BarDataset(ChartType? chartType = null)
        {
            Type = chartType ?? ChartType.Bar;
        }

        /// <summary>
        /// Gets the chart type (<see cref="ChartType.Bar"/> in this case). This is needed for mixed datasets only.
        /// </summary>
        //public override ChartType Type => ChartType.Bar;
        public override ChartType Type { get; }

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
        /// Gets or sets the ID of the x axis to plot this dataset on. If not specified, this defaults to the ID of the first found x axis.
        /// </summary>
        [JsonProperty("xAxisID")]
        public string XAxisId { get; set; }

        /// <summary>
        /// Gets or sets the ID of the y axis to plot this dataset on. If not specified, this defaults to the ID of the first found y axis.
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