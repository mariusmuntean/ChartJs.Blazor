namespace ChartJs.Blazor.ChartJS.Common.Enums
{
    /// <summary>
    /// As per documentation here https://www.chartjs.org/docs/latest/charts/line.html#stepped-line
    /// <para>We can use <see cref="StringEnum"></see> here, even though the values <see cref="False"></see> and <see cref="True"></see> are expected to be of type boolean,
    /// because Javascript interprets <c>"true"</c> the same way it interprets <c>true</c></para>
    /// </summary>
    [Newtonsoft.Json.JsonConverter(typeof(JsonToStringConverter<SteppedLine>))]
    public class SteppedLine : StringEnum
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

        private SteppedLine(string stringRep) : base(stringRep) { }
        private SteppedLine(bool boolOption) : base(boolOption.ToString().ToLower()) { }
    }
}
