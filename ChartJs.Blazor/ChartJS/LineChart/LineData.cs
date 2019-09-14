using ChartJs.Blazor.ChartJS.MixedChart;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace ChartJs.Blazor.ChartJS.LineChart
{
    /// <summary>
    /// The data-subconfig of a <see cref="LineConfig"/>
    /// </summary>
    public class LineData
    {
        /// <summary>
        /// Creates a new instance of <see cref="LineData"/>
        /// </summary>
        public LineData()
        {
            Datasets = new HashSet<IMixableDataset<object>>();
        }

        /// <summary>
        /// The labels the chart will use. 
        /// <para>If defined (not null) the x-Axis has to be of type <see cref="Common.Enums.AxisType.Category"/> for the chart to work correctly.</para>
        /// </summary>
        public List<string> Labels { get; set; }

        /// <summary>
        /// The labels the horizontal Axes will use. 
        /// <para>If defined (not null) the x-Axis has to be of type <see cref="Common.Enums.AxisType.Category"/> for the chart to work correctly.</para>
        /// </summary>
        [JsonProperty("xLabels")]
        public List<string> XLabels { get; set; }

        /// <summary>
        /// The labels the vertical Axes will use. 
        /// <para>If defined (not null) the y-Axis has to be of type <see cref="Common.Enums.AxisType.Category"/> for the chart to work correctly.</para>
        /// </summary>
        [JsonProperty("yLabels")]
        public List<string> YLabels { get; set; }

        /// <summary>
        /// The Datasets displayed in this chart.
        /// </summary>
        public HashSet<IMixableDataset<object>> Datasets { get; }
    }
}