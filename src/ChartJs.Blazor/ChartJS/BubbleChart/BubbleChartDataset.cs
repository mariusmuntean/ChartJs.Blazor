using ChartJs.Blazor.Util.Color;
using System.Collections.Generic;

namespace ChartJs.Blazor.ChartJS.BubbleChart
{
    public class BubbleChartDataset
    {
        /// <summary>
        /// rgba(0,0,0,0.1)'
        /// </summary>
        public string BackgroundColor { get; set; } = ColorUtil.ColorString(0, 0, 0, 0.1);

        /// <summary>
        /// rgba(0,0,0,0.1)'
        /// </summary>
        public string BorderColor { get; set; } = ColorUtil.ColorString(0, 0, 0, 0.1);

        /// <summary>
        /// Default 3
        /// </summary>
        public int BorderWidth { get; set; } = 3;

        public List<BubbleData> Data { get; set; } = new List<BubbleData> { new BubbleData { x = 1, y = 2, r = 3 } };

        public string HoverBackgroundColor { get; set; }

        public string HoverBorderColor { get; set; }

        public int HoverBorderWidth { get; set; } = 1;

        public int HoverRadius { get; set; } = 4;

        public int HitRadius { get; set; } = 1;

        /// <summary>
        /// Defines the text associated to the dataset and which appears in the legend and tooltips.
        /// </summary>
        public string Label { get; set; }

        public string PointStyle { get; set; } = BubbleChartPointStyle.circle.ToString();

        public int Rotation { get; set; } = 0;

        public int Radius { get; set; } = 3;

        public string Type { get; } = ChartTypes.BUBBLE.ToString();
    }
}