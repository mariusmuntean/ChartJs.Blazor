namespace ChartJs.Blazor.ChartJS.Common.Enums
{
    [Newtonsoft.Json.JsonConverter(typeof(JsonToStringConverter<ChartTypes>))]
    public class ChartTypes : StringEnum
    {
        public static ChartTypes Bar => new ChartTypes("bar");
        public static ChartTypes HorizontalBar => new ChartTypes("horizontalBar");
        public static ChartTypes Line => new ChartTypes("line");
        public static ChartTypes Pie => new ChartTypes("pie");
        public static ChartTypes Doughnut => new ChartTypes("doughnut");
        public static ChartTypes Radar => new ChartTypes("radar");
        public static ChartTypes Bubble => new ChartTypes("bubble");
        public static ChartTypes PolarArea => new ChartTypes("polarArea");
        public static ChartTypes Scatter => new ChartTypes("scatter");

        private ChartTypes(string chartType) : base(chartType) { }
    }
}