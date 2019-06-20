using System.Collections.Generic;
using ChartJs.Blazor.ChartJS.Common;

namespace ChartJs.Blazor.ChartJS.BubbleChart
{
    public class BubbleChartData
    {
        public Animation Animation { get; set; }

        public List<BubbleChartDataset> Datasets { get; set; }
    }
}