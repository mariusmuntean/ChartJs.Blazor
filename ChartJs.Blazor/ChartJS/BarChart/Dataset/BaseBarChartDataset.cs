using System;
using System.Collections.Generic;
using System.Linq;
using ChartJs.Blazor.ChartJS.Common.Enums;
using ChartJs.Blazor.ChartJS.MixedChart;
using Newtonsoft.Json;

namespace ChartJs.Blazor.ChartJS.BarChart.Dataset
{
    /// <summary>
    /// A base dataset for a barchart
    /// </summary>
    /// <typeparam name="TData">Defines the type of data in this dataset. Use Wrappers from <see cref="Common.Wrappers"/> for value types.</typeparam>
    public class BaseBarChartDataset<TData> : BaseMixableDataset<TData> where TData : class
    {
        public BaseBarChartDataset(IEnumerable<TData> data) : this()
        {
            this.AddRange(data);
        }

        public BaseBarChartDataset() { }


        public override ChartTypes Type => ChartTypes.Bar;

        /// <summary>
        /// The label for the dataset which appears in the legend and tooltips.
        /// </summary>
        public string Label { get; set; } = "";

        /// <summary>
        /// The ID of the x axis to plot this dataset on. If not specified, this defaults to the ID of the first found x axis
        /// </summary>
        [JsonProperty("xAxisID")]
        public string XAxisID { get; set; }

        /// <summary>
        /// The ID of the y axis to plot this dataset on. If not specified, this defaults to the ID of the first found y axis
        /// </summary>
        [JsonProperty("yAxisID")]
        public string YAxisID { get; set; }

        /// <summary>
        /// Which edge to skip drawing the border for. 
        /// </summary>
        public Positions BorderSkipped { get; set; }

        /// <summary>
        /// The ID of the group to which this dataset belongs to (when stacked, each group will be a separate stack)
        ///
        /// <para>
        /// Specific for stacked bar charts
        /// </para>
        /// </summary>
        public string Stack { get; set; } = Guid.NewGuid().ToString();
    }
}