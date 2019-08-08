using System;
using ChartJs.Blazor.ChartJS.Common;
using ChartJs.Blazor.ChartJS.Common.Properties;

namespace ChartJs.Blazor.ChartJS.PolarAreaChart
{
    public class PolarAreaOptions : BaseChartConfigOptions
    {
        /// <summary>
        /// Starting angle to draw arcs for the first item in a dataset.
        /// </summary>
        public double StartAngle { get; set; } = -0.5 * Math.PI;

        public PieDoughnutAnimation Animation { get; set; }

        public PolarAreaScale Scale { get; set; }
    }
}