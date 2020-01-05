using System;

namespace ChartJs.Blazor.ChartJS.FinancialChart
{
    /// <summary>
    /// financial chart data structure
    /// reference by https://www.chartjs.org/chartjs-chart-financial/index.js
    /// </summary>
    public class FinancialData
    {
        /// <summary>
        /// Time is timestamp
        /// </summary>
        [Newtonsoft.Json.JsonProperty("t")]
        public DateTime Time { get; set; }

        /// <summary>
        /// Open price
        /// </summary>
        [Newtonsoft.Json.JsonProperty("o")]
        public double Open { get; set; }

        /// <summary>
        /// High price
        /// </summary>
        [Newtonsoft.Json.JsonProperty("h")]
        public double High { get; set; }

        /// <summary>
        /// Low price
        /// </summary>
        [Newtonsoft.Json.JsonProperty("l")]
        public double Low { get; set; }

        /// <summary>
        /// Close price
        /// </summary>
        [Newtonsoft.Json.JsonProperty("c")]
        public double Close { get; set; }
    }
}