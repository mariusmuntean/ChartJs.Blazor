namespace ChartJs.Blazor.ChartJS.LineChart
{
    public class ScaleLabel
    {
        public ScaleLabel(string labelString = null)
        {
            LabelString = labelString;
        }

        /// <summary>
        /// If true, display the axis title.
        /// </summary>
        public bool Display { get; set; } = true;

        /// <summary>
        /// Text for the title (i.e. "# of clicks")
        /// </summary>
        public string LabelString { get; set; }

        /// <summary>
        /// The fontcolor of the label
        /// <para>See <see cref="Util.Color.ColorUtil"/> for working with colors.</para>
        /// </summary>
        public string FontColor { get; set; }

        /// <summary>
        /// Font size for scale title.
        /// </summary>
        public int? FontSize { get; set; }
    }
}