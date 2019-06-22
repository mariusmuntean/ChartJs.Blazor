namespace ChartJs.Blazor.ChartJS.Common
{
    [Newtonsoft.Json.JsonConverter(typeof(JsonToStringConverter<HoverModes>))]
    public class HoverModes : StringEnum
    {
        public static HoverModes Nearest => new HoverModes("nearest");

        private HoverModes(string hoverMode) : base(hoverMode) { }
    }
}