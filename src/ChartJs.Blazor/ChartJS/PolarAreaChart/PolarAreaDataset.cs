using System;
using ChartJs.Blazor.ChartJS.Common;
using ChartJs.Blazor.ChartJS.Common.Enums;
using ChartJs.Blazor.ChartJS.PieChart;
using ChartJs.Blazor.Charts;
using ChartJs.Blazor.Util;
using System.Collections.Generic;

namespace ChartJs.Blazor.ChartJS.PolarAreaChart
{
    /// <summary>
    /// Represents a dataset for a pie or doughnut chart.
    /// As per documentation <a href="https://www.chartjs.org/docs/latest/charts/polar.html#dataset-properties">here (Chart.js)</a>.
    /// </summary>
    // Very similar to PieDataset, so the summaries are inherited.
    public class PolarAreaDataset : Dataset<double>
    {
        /// <summary>
        /// Creates a new instance of <see cref="PolarAreaDataset"/>.
        /// </summary>
        public PolarAreaDataset() : base(ChartType.PolarArea) { }

        /// <summary>
        /// Creates a new instance of <see cref="PolarAreaDataset"/> with initial data.
        /// </summary>
        public PolarAreaDataset(IEnumerable<double> data) : this()
        {
            AddRange(data);
        }

        /// <summary>
        /// Creates a new instance of <see cref="PolarAreaDataset"/> with
        /// a custom <see cref="ChartType"/>. Use this constructor when
        /// you implement a polar-area-like chart.
        /// </summary>
        /// <param name="type">The <see cref="ChartType"/> to use instead of <see cref="ChartType.PolarArea"/>.</param>
        protected PolarAreaDataset(ChartType type) : base(type) { }

        /// <inheritdoc cref="PieDataset.BackgroundColor"/>
        public IndexableOption<string> BackgroundColor { get; set; }

        /// <inheritdoc cref="PieDataset.BorderAlign"/>
        public IndexableOption<BorderAlign> BorderAlign { get; set; }

        /// <inheritdoc cref="PieDataset.BorderColor"/>
        public IndexableOption<string> BorderColor { get; set; }

        /// <inheritdoc cref="PieDataset.BorderWidth"/>
        public IndexableOption<int> BorderWidth { get; set; }

        /// <inheritdoc cref="PieDataset.HoverBackgroundColor"/>
        public IndexableOption<string> HoverBackgroundColor { get; set; }

        /// <inheritdoc cref="PieDataset.HoverBorderColor"/>
        public IndexableOption<string> HoverBorderColor { get; set; }

        /// <inheritdoc cref="PieDataset.HoverBorderWidth"/>
        public IndexableOption<int> HoverBorderWidth { get; set; }
    }
}