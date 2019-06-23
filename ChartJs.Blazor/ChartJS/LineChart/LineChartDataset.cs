using System.Collections.Generic;
using ChartJs.Blazor.ChartJS.Common.Enums;
using ChartJs.Blazor.ChartJS.MixedChart;

namespace ChartJs.Blazor.ChartJS.LineChart
{
    /// <summary>
    /// A dataset for a linechart
    /// </summary>
    /// <typeparam name="TData">Defines the type of data in this dataset</typeparam>
    public class LineChartDataset<TData> : IMixableDataset<TData>
    {
        public ChartTypes Type { get; } = ChartTypes.Line;
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
        /// Cap style of the line.
        /// <para>See <see cref="https://developer.mozilla.org/en-US/docs/Web/API/CanvasRenderingContext2D/lineCap"></see> for options.</para>
        /// <para>TODO: Implement options</para>
        /// </summary>
        public string BorderCapStyle { get; set; }

        /// <summary>
        /// Line joint style.
        /// <para>See <see cref="https://developer.mozilla.org/en-US/docs/Web/API/CanvasRenderingContext2D/lineJoin"></see> for options.</para>
        /// <para>TODO: Implement options</para>
        /// </summary>
        public string BorderJoinStyle { get; set; }

        /// <summary>
        /// Algorithm used to interpolate a smooth curve from the discrete data points.
        /// <para>See <see cref="https://www.chartjs.org/docs/latest/charts/line.html#cubicinterpolationmode"></see> for options.</para>
        /// </summary>
        public string CubicInterpolationMode { get; set; }

        /// <summary>
        /// Length and spacing of dashes. It's an int array. Whatever JS!
        /// </summary>
        public int[] BorderDash { get; set; } = new int[] {0, 0};

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
        /// Bezier curve tension of the line. Set to 0 to draw straightlines. This option is ignored if monotone cubic interpolation is used.
        /// </summary>
        public double LineTension { get; set; } = 0.4;

        /// <summary>
        /// If false, the line is not drawn for this dataset.
        /// Default is true. If you are filling and dont want to show the line, then change to false.
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
        /// <para>See <see cref="Util.Color.ColorUtil"/> for working with colors.</para>
        /// </summary>
        public string BackgroundColor { get; set; }

        public string PointBackgroundColor { get; set; }

        /// <summary>
        /// The color of the line. 
        /// <para>See <see cref="Util.Color.ColorUtil"/> for working with colors.</para>
        /// </summary>
        public string BorderColor { get; set; }

        public IReadOnlyCollection<TData> Data { get; set; }
    }
}