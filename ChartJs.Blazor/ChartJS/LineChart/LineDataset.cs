using System.Collections.Generic;
using ChartJs.Blazor.ChartJS.Common.Enums;
using ChartJs.Blazor.ChartJS.MixedChart;
using ChartJs.Blazor.Util;

namespace ChartJs.Blazor.ChartJS.LineChart
{
    /// <summary>
    /// A dataset for a <see cref="Charts.ChartJsLineChart"/>
    /// </summary>
    /// <typeparam name="TData">Defines the type of data in this dataset. Use Wrappers from <see cref="Common.Wrappers"/> for value types.</typeparam>
    public class LineDataset<TData> : BaseMixableDataset<TData> where TData : class
    {
        /// <summary>
        /// Creates a new instance of <see cref="LineDataset{TData}"/> with some data
        /// </summary>
        public LineDataset(IEnumerable<TData> data) : this()
        {
            this.AddRange(data);
        }

        /// <summary>
        /// Creates a new instance of <see cref="LineDataset{TData}"/>
        /// </summary>
        public LineDataset() { }

        /// <summary>
        /// The type of chart this dataset is for.
        /// </summary>
        public override ChartType Type => ChartType.Line;

        /// <summary>
        /// The label for the dataset which appears in the legend and tooltips.
        /// </summary>
        public string Label { get; set; } = "";

        /// <summary>
        /// The ID of the x axis to plot this dataset on. If not specified, this defaults to the ID of the first found x axis
        /// </summary>
        public string XAxisID { get; set; }

        /// <summary>
        /// The ID of the y axis to plot this dataset on. If not specified, this defaults to the ID of the first found y axis.
        /// </summary>
        public string YAxisID { get; set; }

        /// <summary>
        /// The width of the line in pixels.
        /// </summary>
        public int BorderWidth { get; set; } = 1;

        /// <summary>
        /// Gets or sets the cap style of the line.
        /// </summary>
        public BorderCapStyle BorderCapStyle { get; set; }

        /// <summary>
        /// Gets or sets the line join style.
        /// </summary>
        public BorderJoinStyle BorderJoinStyle { get; set; }

        /// <summary>
        /// Gets or sets the algorithm used to interpolate a smooth curve from the discrete data points.
        /// </summary>
        public CubicInterpolationMode CubicInterpolationMode { get; set; }

        /// <summary>
        /// Length and spacing of dashes. It's an int array. Whatever JS!
        /// </summary>
        public int[] BorderDash { get; set; } = { 0, 0 };

        /// <summary>
        /// Offset for line dashes.
        /// </summary>
        public int BorderDashOffset { get; set; }

        /// <summary>
        /// The width of the point border in pixels.
        /// </summary>
        public int PointBorderWidth { get; set; }

        /// <summary>
        /// The radius of the point shape. If set to 0, the point is not rendered.
        /// </summary>
        public int PointRadius { get; set; }

        /// <summary>
        /// The pixel size of the non-displayed point that reacts to mouse events.
        /// </summary>
        public int PointHitRadius { get; set; }

        /// <summary>
        /// Border width of point when hovered.
        /// </summary>
        public int PointHoverBorderWidth { get; set; }

        /// <summary>
        /// The radius of the point when hovered.
        /// </summary>
        public int PointHoverRadius { get; set; }

        /// <summary>
        /// How to fill the area under the line.
        /// </summary>
        public bool Fill { get; set; }

        /// <summary>
        /// Bezier curve tension of the line. Set to 0 to draw straight lines. This option is ignored if monotone cubic interpolation is used.
        /// </summary>
        public double LineTension { get; set; } = 0.4;

        /// <summary>
        /// If false, the line is not drawn for this dataset.
        /// Default is true. If you are filling and don't want to show the line, then change to false.
        /// </summary>
        public bool ShowLine { get; set; } = true;

        /// <summary>
        /// If true, lines will be drawn between points with no or null data. If false, points with NaN data will create a break in the line
        /// </summary>
        public bool SpanGaps { get; set; }

        /// <summary>
        /// If the line is shown as a stepped line. Use <see cref="Common.Enums.SteppedLine"></see> for available options.
        /// <para>If the steppedLine value is set to anything other than <see cref="SteppedLine.False"></see>, <see cref="LineTension"></see> will be ignored.</para>
        /// </summary>
        public SteppedLine SteppedLine { get; set; } = SteppedLine.False;

        /// <summary>
        /// The fill color under the line.
        /// <para>See <see cref="ColorUtil"/> for working with colors.</para>
        /// </summary>
        public string BackgroundColor { get; set; }

        /// <summary>
        /// The fill color of a point.
        /// <para>See <see cref="ColorUtil"/> for working with colors.</para>
        /// </summary>
        public string PointBackgroundColor { get; set; }

        /// <summary>
        /// The color of the line. 
        /// <para>See <see cref="ColorUtil"/> for working with colors.</para>
        /// </summary>
        public string BorderColor { get; set; }
    }
}