namespace BlazorComponents.ChartJS
{
    public class ChartJsPieDataset : ChartJsDataset
    {
        public override string Type { get; } = ChartTypes.PIE.ToString();

        public int BorderWidth { get; set; }
        public string[] HoverBackgroundColor { get; set; }
        public string[] HoverBorderColor { get; set; }
        public int[] HoverBorderWidth { get; set; }

        /// <summary>
        /// The fill color under the line. 
        /// AS-IS: We only accept colors as string values. Normal colors and HTML Hex colors are ok to use.
        /// TODO: Accept some form of actual color information rather than strings.
        /// </summary>
        public string[] BackgroundColor { get; set; }
    }
}