namespace ChartJs.Blazor.ChartJS.Common.Enums
{
    /// <summary>
    /// Defines the type of a chart
    /// </summary>
    public sealed class ChartTypes : StringEnum
    {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        public static ChartTypes Bar => new ChartTypes("bar");
        public static ChartTypes HorizontalBar => new ChartTypes("horizontalBar");
        public static ChartTypes Line => new ChartTypes("line");
        public static ChartTypes Pie => new ChartTypes("pie");
        public static ChartTypes Doughnut => new ChartTypes("doughnut");
        public static ChartTypes Radar => new ChartTypes("radar");
        public static ChartTypes Bubble => new ChartTypes("bubble");
        public static ChartTypes PolarArea => new ChartTypes("polarArea");
        public static ChartTypes Scatter => new ChartTypes("scatter");
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member

        private ChartTypes(string stringRep) : base(stringRep) { }
    }
}