using ChartJs.Blazor.ChartJS.Common.Axes;
using System.Collections.Generic;

namespace ChartJs.Blazor.ChartJS.LineChart
{
    /// <summary>
    /// Defines the scales for cartesian charts by holding the x and y axes.
    /// </summary>
    public class Scales
    {
#pragma warning disable CS1591, IDE1006 // Missing XML comment for publicly visible type or member
        public List<CartesianAxis> xAxes { get; set; }
        public List<CartesianAxis> yAxes { get; set; }
#pragma warning restore CS1591, IDE1006 // Missing XML comment for publicly visible type or member
    }
}