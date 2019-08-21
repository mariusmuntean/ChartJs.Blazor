using ChartJs.Blazor.ChartJS.Common.Enums;
using ChartJs.Blazor.Util.Color;
using System.Collections.Generic;

namespace ChartJs.Blazor.ChartJS.RadarChart
{
    public class RadarChartDataset
    {
        public ChartTypes Type { get; } = ChartTypes.Radar;

        /// <summary>
        /// The label for the dataset which appears in the legend and tooltips.
        /// </summary>
        public string Label { get; set; } = "";

        /// <summary>
        /// The fill color under the line.
        /// <para>See <see cref="ColorUtil"/> for working with colors.</para>
        /// </summary>
        public string BackgroundColor { get; set; }

        /// <summary>
        /// The color of the line.
        /// <para>See <see cref="ColorUtil"/> for working with colors.</para>
        /// </summary>
        public string BorderColor { get; set; }

        /// <summary>
        /// The width of the line in pixels.
        /// </summary>
        public int BorderWidth { get; set; } = 1;

        /// <summary>
        /// Offset for line dashes.
        /// </summary>
        public int BorderDashOffset { get; set; }

        /// <summary>
        /// Cap style of the line
        /// </summary>
        public string BorderCapStyle { get; set; }

        /// <summary>
        /// Line joint style
        /// </summary>
        public string BorderJoinStyle { get; set; }

        /// <summary>
        /// Both line and radar charts support a fill option on the dataset object which can be used to create area between two datasets or a dataset and a boundary, i.e. the scale origin, start or end
        ///<para>Source: http://www.chartjs.org/docs/latest/charts/area.html#filling-modes</para>
        ///
        /// <para>Absolute dataset index    Number      1, 2, 3, ...</para>
        /// <para>Relative dataset index    String      '-1', '-2', '+1', ...</para>
        /// <para>Boundary                  String      'start', 'end', 'origin'</para>
        /// <para>Disabled                  Boolean     false</para>
        ///
        /// </summary>
        public object Fill { get; set; }

        /// <summary>
        /// Bezier curve tension of the line. Set to 0 to draw straight lines.
        /// </summary>
        public int LineTension { get; set; }

        /// <summary>
        /// The fill color for points.
        /// <para>See <see cref="ColorUtil"/> for working with colors.</para>
        /// </summary>
        public string[] PointBackgroundColor { get; set; } = {"#DB5571"};

        /// <summary>
        /// The border color for points.
        /// <para>See <see cref="ColorUtil"/> for working with colors.</para>
        /// </summary>
        public string[] PointBorderColor { get; set; } = {"#6D2A39"};

        /// <summary>
        /// The width of the point border in pixels.
        /// </summary>
        public int[] PointBorderWidth { get; set; } = {1};

        /// <summary>
        /// The radius of the point shape. If set to 0, the point is not rendered.
        /// </summary>
        public int[] PointRadius { get; set; } = {1};

        /// <summary>
        /// The rotation of the point in degrees
        /// </summary>
        public int[] PointRotation { get; set; }

        /// <summary>
        /// Style of the point
        /// </summary>
        public RadarChartPointStyles[] PointStyle { get; set; } = {RadarChartPointStyles.TRIANGLE};

        /// <summary>
        /// The pixel size of the non-displayed point that reacts to mouse events.
        /// </summary>
        public int[] PointHitRadius { get; set; }

        /// <summary>
        /// Point background color when hovered.
        /// <para>See <see cref="ColorUtil"/> for working with colors.</para>
        /// </summary>
        public string[] PointHoverBackgroundColor { get; set; }

        /// <summary>
        /// Point border color when hovered.
        /// <para>See <see cref="ColorUtil"/> for working with colors.</para>
        /// </summary>
        public string[] PointHoverBorderColor { get; set; }

        /// <summary>
        /// Border width of point when hovered.
        /// </summary>
        public int[] PointHoverBorderWidth { get; set; }

        /// <summary>
        /// The radius of the point when hovered
        /// </summary>
        public int[] PointHoverRadius { get; set; }

        public List<double> Data { get; set; }
    }
}