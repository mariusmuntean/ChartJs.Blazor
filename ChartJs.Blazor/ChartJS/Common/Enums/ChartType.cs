namespace ChartJs.Blazor.ChartJS.Common.Enums
{
    /// <summary>
    /// Defines the chart types.
    /// </summary>
    public sealed class ChartType : StringEnum
    {
        /// <summary>
        /// The bar chart type.
        /// </summary>
        public static ChartType Bar => new ChartType("bar");

        /// <summary>
        /// The horizontal bar chart type.
        /// </summary>
        public static ChartType HorizontalBar => new ChartType("horizontalBar");

        /// <summary>
        /// The line chart type.
        /// </summary>
        public static ChartType Line => new ChartType("line");

        /// <summary>
        /// The pie chart type.
        /// </summary>
        public static ChartType Pie => new ChartType("pie");

        /// <summary>
        /// The doughnut chart type.
        /// </summary>
        public static ChartType Doughnut => new ChartType("doughnut");

        /// <summary>
        /// The radar chart type.
        /// </summary>
        public static ChartType Radar => new ChartType("radar");

        /// <summary>
        /// The bubble chart type.
        /// </summary>
        public static ChartType Bubble => new ChartType("bubble");

        /// <summary>
        /// The polar area chart type.
        /// </summary>
        public static ChartType PolarArea => new ChartType("polarArea");

        /// <summary>
        /// The scatter chart type.
        /// </summary>
        public static ChartType Scatter => new ChartType("scatter");

        /// <summary>
        /// Creates a new instance of the <see cref="ChartType"/> class.
        /// </summary>
        /// <param name="stringValue">The <see cref="string"/> value to set.</param>
        private ChartType(string stringValue) : base(stringValue) { }
    }
}
