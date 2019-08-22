using ChartJs.Blazor.Util.Color;

namespace ChartJs.Blazor.ChartJS.BarChart.Dataset
{
    /// <summary>
    /// Dataset for Bar Chart with typesafe Data. Source: http://www.chartjs.org/docs/latest/charts/bar.html#dataset-properties
    ///
    /// <para>
    ///  The first value applies to the first bar, the second value to the second bar, and so on.
    /// </para>
    /// </summary>
    /// <typeparam name="TData">Defines the type of data in this dataset. Use Wrappers from <see cref="Common.Wrappers"/> for value types.</typeparam>
    public class IndividualBarDataset<TData> : BaseBarDataset<TData> where TData : class
    {
        /// <summary>
        /// The fill color of the bar.
        /// <para>See <see cref="ColorUtil"/> for working with colors.</para>
        /// </summary>
        public string[] BackgroundColor { get; set; }

        /// <summary>
        /// The color of the bar border.
        /// <para>See <see cref="ColorUtil"/> for working with colors.</para>
        /// </summary>
        public string[] BorderColor { get; set; } = {ColorUtil.ColorString(128, 128, 128, 0.1)};

        /// <summary>
        /// The stroke width of the bar in pixels.
        /// </summary>
        public int[] BorderWidth { get; set; } = {1};

        /// <summary>
        /// The fill color of the bars when hovered.
        /// <para>See <see cref="ColorUtil"/> for working with colors.</para>
        /// </summary>
        public string[] HoverBackgroundColor { get; set; }

        /// <summary>
        /// The stroke color of the bars when hovered.
        /// <para>See <see cref="ColorUtil"/> for working with colors.</para>
        /// </summary>
        public string[] HoverBorderColor { get; set; }

        /// <summary>
        /// The stroke width of the bars when hovered.
        /// </summary>
        public int[] HoverBorderWidth { get; set; }
    }
}