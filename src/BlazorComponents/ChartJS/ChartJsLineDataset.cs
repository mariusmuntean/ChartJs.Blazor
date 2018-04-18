namespace BlazorComponents.ChartJS
{
    public class ChartJsLineDataset : ChartJsDataset
    {
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
        /// </summary>
        public string BorderCapStyle { get; set; }
        /// <summary>
        /// Line joint style.
        /// </summary>
        public string BorderJoinStyle { get; set; }
        /// <summary>
        /// Algorithm used to interpolate a smooth curve from the discrete data points.
        /// </summary>
        public string CubicInterpolationMode { get; set; }
        /// <summary>
        /// Length and spacing of dashes. It's an int array. Whatever JS!
        /// </summary>
        public int[] BorderDash { get; set; } = new int[] { 0, 0 };
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
        /// If false, the line is not drawn for this dataset.
        /// Default is true. If you are filling and dont want to show the line, then change to false.
        /// </summary>
        public bool ShowLine { get; set; } = true;
        /// <summary>
        /// If true, lines will be drawn between points with no or null data. If false, points with NaN data will create a break in the line
        /// </summary>
        public bool SpanGaps { get; set; }
        /// <summary>
        /// If the line is shown as a stepped line.
        /// </summary>
        public bool SteppedLine { get; set; }
    }
}
