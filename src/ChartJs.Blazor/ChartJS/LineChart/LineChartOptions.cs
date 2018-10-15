using ChartJs.Blazor.ChartJS.Common;

namespace ChartJs.Blazor.ChartJS.LineChart
{
    public class LineChartOptions
    {
        public bool Responsive { get; set; }
        public OptionsTitle Title { get; set; }
        public LineChartOptionsTooltips Tooltips { get; set; }
        public LineChartOptionsHover Hover { get; set; }
        public Scales Scales { get; set; }
        public string Text { get; set; }
        public bool Display { get; set; }
    }
}