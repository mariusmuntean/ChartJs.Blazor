using System;
using ChartJs.Blazor.ChartJS.Common;
using ChartJs.Blazor.ChartJS.Common.Properties;
using Newtonsoft.Json;

namespace ChartJs.Blazor.ChartJS.PieChart
{
    /// <summary>
    /// The options-subconfig of a <see cref="PieChartConfig"/>.
    /// </summary>
    public class PieChartOptions : BaseChartConfigOptions
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonIgnore]
        private bool isDougnut = false;

        /// <summary>
        /// Gets or sets a value indicating whether this chart is rendered as a doughnut or a pie. Default to a pie chart.
        /// </summary>
        [JsonIgnore]
        public bool IsDoughnut
        {
            get
            {
                return isDougnut;
            }
            set
            {
                if (value)
                {
                    CutoutPercentage = 50;
                }
                else
                {
                    CutoutPercentage = 0;
                }

                isDougnut = value;
            }
        }

        /// <summary>
        /// Gets or sets the percentage of the chart that is cut out of the middle.
        /// </summary>
        public int CutoutPercentage { get; set; } = 0;

        /// <summary>
        /// Gets or sets the animation the chart uses.
        /// </summary>
        public PieAnimation Animation { get; set; }

        /// <summary>
        /// Gets or sets the starting angle to draw arcs from.
        /// </summary>
        public double Rotation { get; set; } = -0.5 * Math.PI;

        /// <summary>
        /// Gets or sets the sweep to allow arcs to cover.
        /// </summary>
        public double Circumference { get; set; } = 2 * Math.PI;
    }
}