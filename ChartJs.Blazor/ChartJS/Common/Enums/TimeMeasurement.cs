namespace ChartJs.Blazor.ChartJS.Common.Enums
{
    /// <summary>
    /// As per documentation here https://www.chartjs.org/docs/latest/axes/cartesian/time.html#time-units
    /// </summary>
    /// 
    public sealed class TimeMeasurement : StringEnum
    {
        public static TimeMeasurement Millisecond => new TimeMeasurement("millisecond");
        public static TimeMeasurement Second => new TimeMeasurement("second");
        public static TimeMeasurement Minute => new TimeMeasurement("minute");
        public static TimeMeasurement Hour => new TimeMeasurement("hour");
        public static TimeMeasurement Day => new TimeMeasurement("day");
        public static TimeMeasurement Week => new TimeMeasurement("week");
        public static TimeMeasurement Month => new TimeMeasurement("month");
        public static TimeMeasurement Quarter => new TimeMeasurement("quarter");
        public static TimeMeasurement Year => new TimeMeasurement("year");

        private TimeMeasurement(string stringRep) : base(stringRep) { }
    }
}