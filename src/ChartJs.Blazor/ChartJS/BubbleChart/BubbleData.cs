using System.Collections.Generic;
using ChartJs.Blazor.ChartJS.Common.Properties;

namespace ChartJs.Blazor.ChartJS.BubbleChart
{
    public class BubbleData
    {
        public Animation Animation { get; set; }

        public List<BubbleDataset> Datasets { get; set; }
    }
}