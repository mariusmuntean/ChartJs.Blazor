using System;
using ChartJs.Blazor.ChartJS.Common;

namespace ChartJs.Blazor.ChartJS.PolarAreaChart
{
    public class PolarAreaOptions : BaseChartConfigOptions
    {
        /// <summary>
        /// Starting angle to draw arcs for the first item in a dataset.
        /// </summary>
        public double StartAngle { get; set; } = -0.5 * Math.PI;

        public DoughnutAnimation Animation { get; set; }

        public PolarAreaLegend Legend { get; set; }

        public OptionsTitle Title { get; set; }

        public PolarAreaScale Scale { get; set; }
    }
}