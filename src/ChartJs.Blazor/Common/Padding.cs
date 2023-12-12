namespace ChartJs.Blazor.Common
{
    /// <summary>
    /// The padding to add to the chart.
    /// <para>As per documentation <a href="https://www.chartjs.org/docs/latest/general/padding.html">here (Chart.js)</a>.</para>
    /// </summary>
    public class Padding
    {
        public int Left { get; set; }
        public int Right { get; set; }
        public int Top { get; set; }
        public int Bottom { get; set; }
    }
}
