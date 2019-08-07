using System.Collections.Generic;

namespace ChartJs.Blazor.ChartJS.PolarAreaChart
{
    public class PolarAreaDataset
    {
        public string Label { get; set; }

        /// <summary>
        /// The fill color of the arcs in the dataset. 
        /// </summary>
        public List<string> BackgroundColor { get; set; }

        /// <summary>
        /// The border color of the arcs in the dataset
        /// </summary>
        public List<string> BorderColor { get; set; }

        /// <summary>
        /// The border width of the arcs in the dataset.
        /// </summary>
        public List<int> BorderWidth { get; set; }

        /// <summary>
        /// The fill colour of the arcs when hovered.
        /// </summary>
        public List<string> HoverBackgroundColor { get; set; }

        /// <summary>
        /// The stroke colour of the arcs when hovered.
        /// </summary>
        public List<string> HoverBorderColor { get; set; }

        /// <summary>
        /// The stroke width of the arcs when hovered.
        /// </summary>
        public List<int> HoverBorderWidth { get; set; }

        public List<double> Data { get; set; }
    }
}