using System.Collections.Generic;
using ChartJs.Blazor.ChartJS.Common;
using ChartJs.Blazor.ChartJS.Common.Properties;

namespace ChartJs.Blazor.ChartJS.BubbleChart
{
    public class BubbleChartData
    {
        public Animation Animation { get; set; }

        public List<BubbleChartDataset> Datasets { get; set; }
    }
}