namespace ChartJs.Blazor.ChartJS.Common.Properties
{
    /// <summary>
    /// Represents the title of a chart
    /// </summary>
    public class OptionsTitle
    {
        /// <summary>
        /// Determines if the title should be displayed or not
        /// </summary>
        public bool Display { get; set; }

        /// <summary>
        /// Position of title (top, left, bottom, right)
        /// </summary>
        public string Position { get; set; }

        /// <summary>
        /// Font Size
        /// </summary>
        public int FontSize { get; set; }

        /// <summary>
        /// Font family for the title text
        /// </summary>
        public string FontFamily { get; set; }

        /// <summary>
        /// Font color
        /// </summary>
        public string FontColor { get; set; }

        /// <summary>
        /// Font style (italic, bold)
        /// </summary>
        public string FontStyle { get; set; }

        /// <summary>
        /// Number of pixels to add above and below the title text
        /// </summary>
        public int Padding { get; set; }

        /// <summary>
        /// Height of an individual line of text
        /// </summary>
        public string LineHeight { get; set; }

        /// <summary>
        /// The actual title to display
        /// </summary>
        public string Text { get; set; }
    }
}
