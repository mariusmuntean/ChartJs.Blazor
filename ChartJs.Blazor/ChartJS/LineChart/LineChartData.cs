using System.Collections.Generic;

namespace ChartJs.Blazor.ChartJS.LineChart
{
    public class LineChartData
    {
        public List<string> Labels { get; set; }
        public IReadOnlyCollection<LineChartDataset<object>> Datasets { get; set; }
    }
}