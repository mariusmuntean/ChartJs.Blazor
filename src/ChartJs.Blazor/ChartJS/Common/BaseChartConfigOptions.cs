using ChartJs.Blazor.ChartJS.Common.Legends;

namespace ChartJs.Blazor.ChartJS.Common
{
    public class BaseChartConfigOptions
    {
        public string Text { get; set; }
        public bool Display { get; set; }
        public bool Responsive { get; set; }

        public Legend Legend { get; set; } = new Legend();
    }
}