using System;

namespace ChartJs.Blazor.ChartJS.PieChart
{
    public class PieChartOptions
    {
        public int CutoutPercentage { get; set; } = 0;
        public bool Responsive { get; set; }
        public double Rotation { get; set; } = -0.5 * Math.PI;

        public double Circumference { get; set; } = 2 * Math.PI;

        public PieChartAnimation Animation { get; set; }
        public string Text { get; set; }
        public bool Display { get; set; }
    }
}