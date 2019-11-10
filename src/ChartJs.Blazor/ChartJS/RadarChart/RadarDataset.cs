using System;
using ChartJs.Blazor.ChartJS.Common;
using ChartJs.Blazor.ChartJS.Common.Enums;
using ChartJs.Blazor.Util;
using System.Collections.Generic;

namespace ChartJs.Blazor.ChartJS.RadarChart
{
    public class RadarDataset
    {
        public string Id { get; } = Guid.NewGuid().ToString();

        public ChartType Type { get; } = ChartType.Radar;

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
        public int BorderWidth { get; set; } = 3;

        /// <summary>
        /// Offset for line dashes.
        /// </summary>
        public double BorderDashOffset { get; set; }

        /// <summary>
        /// Gets or sets the cap style of the line.
        /// </summary>
        public BorderCapStyle BorderCapStyle { get; set; }

        /// <summary>
        /// Gets or sets the line join style.
        /// </summary>
        public BorderJoinStyle BorderJoinStyle { get; set; }

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
        public double LineTension { get; set; } = 0.4;

        /// <summary>
        /// The fill color for points.
        /// <para>See <see cref="ColorUtil"/> for working with colors.</para>
        /// </summary>
        public IndexableOption<string> PointBackgroundColor { get; set; }

        /// <summary>
        /// The border color for points.
        /// <para>See <see cref="ColorUtil"/> for working with colors.</para>
        /// </summary>
        public IndexableOption<string> PointBorderColor { get; set; }

        /// <summary>
        /// The width of the point border in pixels.
        /// </summary>
        public IndexableOption<int> PointBorderWidth { get; set; }

        /// <summary>
        /// The radius of the point shape. If set to 0, the point is not rendered.
        /// </summary>
        public IndexableOption<int> PointRadius { get; set; }

        /// <summary>
        /// The rotation of the point in degrees
        /// </summary>
        public IndexableOption<int> PointRotation { get; set; }

        /// <summary>
        /// Gets or sets the point style.
        /// </summary>
        public IndexableOption<PointStyle> PointStyle { get; set; }

        /// <summary>
        /// The pixel size of the non-displayed point that reacts to mouse events.
        /// </summary>
        public IndexableOption<int> PointHitRadius { get; set; }

        /// <summary>
        /// Point background color when hovered.
        /// <para>See <see cref="ColorUtil"/> for working with colors.</para>
        /// </summary>
        public IndexableOption<string> PointHoverBackgroundColor { get; set; }

        /// <summary>
        /// Point border color when hovered.
        /// <para>See <see cref="ColorUtil"/> for working with colors.</para>
        /// </summary>
        public IndexableOption<string> PointHoverBorderColor { get; set; }

        /// <summary>
        /// Border width of point when hovered.
        /// </summary>
        public IndexableOption<int> PointHoverBorderWidth { get; set; }

        /// <summary>
        /// The radius of the point when hovered
        /// </summary>
        public IndexableOption<int> PointHoverRadius { get; set; }

        public List<double> Data { get; set; }
    }
}