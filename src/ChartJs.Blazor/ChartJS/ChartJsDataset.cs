using System.Collections.Generic;

namespace ChartJs.Blazor.ChartJS
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

        public abstract string Type { get; }
    }
}
