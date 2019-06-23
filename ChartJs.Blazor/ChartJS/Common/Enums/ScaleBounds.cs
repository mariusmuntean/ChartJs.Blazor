namespace ChartJs.Blazor.ChartJS.Common.Enums
{
    /// <summary>
    /// As per documentation here https://www.chartjs.org/docs/latest/axes/cartesian/time.html#scale-bounds
    /// </summary>
    /// 
    public sealed class ScaleBounds : StringEnum
    {
        /// <summary>
        /// Makes sure data are fully visible, labels outside are removed
        /// </summary>
        public static ScaleBounds Data => new ScaleBounds("data");

        /// <summary>
        /// Makes sure ticks are fully visible, data outside are truncated
        /// </summary>
        public static ScaleBounds Ticks => new ScaleBounds("ticks");

        private ScaleBounds(string stringRep) : base(stringRep) { }
    }
}