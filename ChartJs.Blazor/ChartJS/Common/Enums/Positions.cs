namespace ChartJs.Blazor.ChartJS.Common.Enums
{
    [Newtonsoft.Json.JsonConverter(typeof(JsonToStringConverter<Positions>))]
    public sealed class Positions : StringEnum
    {
        public static Positions Left => new Positions("left");
        public static Positions Right => new Positions("right");
        public static Positions Top => new Positions("top");
        public static Positions Bottom => new Positions("bottom");

        private Positions(string stringRep) : base(stringRep) { }
    }
}