using System;
using System.Collections.Generic;
using System.Linq;
using ChartJs.Blazor.ChartJS.Common.Enums;
using ChartJs.Blazor.ChartJS.MixedChart;
using Newtonsoft.Json;

namespace ChartJs.Blazor.ChartJS.BarChart.Dataset
{
    public class BaseBarChartDataset<TData> : IMixableDataset<TData>
    {
        public BaseBarChartDataset(IEnumerable<TData> data) : this()
        {
            Data.AddRange(data);
        }

        public BaseBarChartDataset() => Data = new List<TData>();


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

        public ChartTypes Type { get; } = ChartTypes.Bar;

        /// <summary>
        /// Which edge to skip drawing the border for. 
        /// </summary>
        public Positions BorderSkipped { get; set; }

        // ToDo: introduce a data type
        public List<TData> Data { get; }

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