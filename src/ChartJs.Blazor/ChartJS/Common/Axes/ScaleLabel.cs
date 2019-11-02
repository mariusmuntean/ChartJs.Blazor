using ChartJs.Blazor.Util;

namespace ChartJs.Blazor.ChartJS.Common.Axes
{
    /// <summary>
    /// Defines options for how to display an axis title.
    /// </summary>
    public class ScaleLabel
    {
        /// <summary>
        /// Creates a new instance of <see cref="ScaleLabel"/>
        /// </summary>
        /// <param name="labelString">The initial value for <see cref="LabelString"/></param>
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
        /// The font color of the label
        /// <para>See <see cref="ColorUtil"/> for working with colors.</para>
        /// </summary>
        public string FontColor { get; set; }

        /// <summary>
        /// Font size for scale title.
        /// </summary>
        public int? FontSize { get; set; }
    }
}