using System.Collections.Generic;

namespace BlazorComponents.ChartJS
{
    public abstract class ChartJsDataset
    {
        /// <summary>
        /// The label for the dataset which appears in the legend and tooltips.
        /// </summary>
        public string Label { get; set; } = "";
        /// <summary>
        /// Actual data. This is an int array.
        /// TO-DO: Explore if it makes any sense to have this as decimal.
        /// </summary>
        public List<dynamic> Data { get; set; } = new List<dynamic>();

        /// <summary>
        /// The color of the line
        /// AS-IS: We only accept string colors.
        /// TODO: Accept some form of actual color information rather than strings.
        /// </summary>
        public string BorderColor { get; set; }

        public abstract string Type { get; }
    }
}
