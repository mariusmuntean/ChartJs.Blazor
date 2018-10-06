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
    }

    public class BubbleData
    {
        public int x { get; set; }

        public int y { get; set; }

        public int r { get; set; }
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