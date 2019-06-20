using ChartJs.Blazor.ChartJS.Common;

namespace ChartJs.Blazor.ChartJS.BubbleChart
{
    public class BubbleChartOptions : BaseChartConfigOptions
    {
        public OptionsTitle Title { get; set; }

        public Tooltips Tooltips { get; set; }
    }
}