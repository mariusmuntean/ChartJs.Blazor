using System.Collections.Generic;

namespace ChartJs.Blazor.ChartJS.LineChart
{
    public class LineChartData<TData>
    {
        public List<string> Labels { get; set; }
        public List<LineChartDataset<TData>> Datasets { get; set; }
    }
}