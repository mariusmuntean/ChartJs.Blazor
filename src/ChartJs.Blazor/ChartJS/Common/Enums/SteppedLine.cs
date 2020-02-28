namespace ChartJs.Blazor.ChartJS.Common.Enums
{
    /// <summary>
    /// As per documentation here https://www.chartjs.org/docs/latest/charts/line.html#stepped-line
    /// </summary>
    public sealed class SteppedLine : ObjectEnum
    {
        /// <summary>
        /// No Step Interpolation (default)
        /// </summary>
        public static SteppedLine False => new SteppedLine(false);

        /// <summary>
        /// Step-before Interpolation (same as <see cref="Before"></see>)
        /// </summary>
        public static SteppedLine True => new SteppedLine(true);

        /// <summary>
        /// Step-before Interpolation
        /// </summary>
        public static SteppedLine Before => new SteppedLine("before");

        /// <summary>
        /// Step-after Interpolation
        /// </summary>
        public static SteppedLine After => new SteppedLine("after");

        /// <summary>
        /// Step-middle Interpolation
        /// </summary>
        public static SteppedLine Middle => new SteppedLine("middle");

        private SteppedLine(string stringValue) : base(stringValue) { }
        private SteppedLine(bool boolValue) : base(boolValue) { }
    }
}
