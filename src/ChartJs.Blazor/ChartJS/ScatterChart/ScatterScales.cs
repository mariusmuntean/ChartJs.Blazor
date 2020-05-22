using Newtonsoft.Json;
using System.Collections.Generic;

namespace ChartJs.Blazor.ChartJS.ScatterChart
{
    /// <summary>
    /// Defines the scales for scatter charts by holding the x and y axes.
    /// </summary>
    public class ScatterScales
    {
        /// <summary>
        /// Gets or sets the configurations for the x-axes.
        /// </summary>
        [JsonProperty("xAxes")]
        public List<ScatterAxis> XAxes { get; set; }

        /// <summary>
        /// Gets or sets the configurations for the y-axes.
        /// </summary>
        [JsonProperty("yAxes")]
        public List<ScatterAxis> YAxes { get; set; }
    }
}