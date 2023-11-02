namespace ChartJs.Blazor.Common
{
    /// <summary>
    /// The chart Layout Configuration.
    /// <para>As per documentation <a href="https://www.chartjs.org/docs/latest/configuration/layout.html">here (Chart.js)</a>.</para>
    /// </summary>
    public class Layout
    {
        /// <summary>
        /// The padding to add inside the chart
        /// </summary>
        public Padding Padding { get; set; } = new Padding();
    }
}
