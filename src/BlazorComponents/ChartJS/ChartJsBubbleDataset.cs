namespace BlazorComponents.ChartJS
{
    public class ChartJsBubbleDataset : ChartJsDataset
    {
        //public List<BubbleData> Data { get; set; } = new List<BubbleData> { new BubbleData { x = 1, y = 2, r = 3 } };

        public int BorderWidth { get; set; } = 3;

        public string HoverBackgroundColor { get; set; }

        public string HoverBorderColor { get; set; }

        public int HoverBorderWidth { get; set; } = 1;
        public int HoverRadius { get; set; } = 4;
        public int HitRadius { get; set; } = 1;

        public string PointStyle
        {
            get { return BubbleChartPointStyle.circle.ToString(); }
        }

        public int Radius { get; set; } = 3;
        public override string Type { get; } = ChartTypes.BUBBLE.ToString();

        /// <summary>
        /// The fill color under the line. 
        /// AS-IS: We only accept colors as string values. Normal colors and HTML Hex colors are ok to use.
        /// TODO: Accept some form of actual color information rather than strings.
        /// </summary>
        public string BackgroundColor { get; set; }

        /// <summary>
        /// The color of the line
        /// AS-IS: We only accept string colors.
        /// TODO: Accept some form of actual color information rather than strings.
        /// </summary>
        public string BorderColor { get; set; }
    }

    public class BubbleData
    {
        public double x { get; set; }

        public double y { get; set; }

        public double r { get; set; }
    }

    public enum BubbleChartPointStyle
    {
        circle,
        cross,
        crossRot,
        dash,
        line,
        rect,
        rectRounded,
        rectRot,
        star,
        triangle
    }
}