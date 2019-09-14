using ChartJs.Blazor.Util;

namespace ChartJs.Blazor.ChartJS.BarChart.Dataset
{
    /// <summary>
    /// Dataset for a bar chart with type safe data. Source: http://www.chartjs.org/docs/latest/charts/bar.html#dataset-properties
    /// </summary>
    /// <typeparam name="TData">Defines the type of data in this dataset. Use Wrappers from <see cref="Common.Wrappers"/> for value types.</typeparam>
    public class BarDataset<TData> : BaseBarDataset<TData> where TData : class
    {
        /// <summary>
        /// The fill color of the bar.
        /// <para>See <see cref="ColorUtil"/> for working with colors.</para>
        /// </summary>
        public string BackgroundColor { get; set; } = ColorUtil.ColorString(128, 128, 128, 0.35);

        /// <summary>
        /// The color of the bar border.
        /// <para>See <see cref="ColorUtil"/> for working with colors.</para>
        /// </summary>
        public string BorderColor { get; set; } = ColorUtil.ColorString(128, 128, 128, 0.35);

        /// <summary>
        /// The stroke width of the bar in pixels.
        /// </summary>
        public int BorderWidth { get; set; } = 1;

        /// <summary>
        /// The fill color of the bars when hovered.
        /// <para>See <see cref="ColorUtil"/> for working with colors.</para>
        /// </summary>
        public string HoverBackgroundColor { get; set; } = ColorUtil.ColorString(128, 128, 128, 0.35);

        /// <summary>
        /// The stroke color of the bars when hovered.
        /// <para>See <see cref="ColorUtil"/> for working with colors.</para>
        /// </summary>
        public string HoverBorderColor { get; set; } = ColorUtil.ColorString(128, 128, 128, 0.35);

        /// <summary>
        /// The stroke width of the bars when hovered.
        /// </summary>
        public int HoverBorderWidth { get; set; } = 1;
    }
}