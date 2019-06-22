using ChartJs.Blazor.ChartJS.Common.Enums.JsonConverter;

namespace ChartJs.Blazor.ChartJS.Common.Enums
{
    /// <summary>
    /// As per documentation here https://www.chartjs.org/docs/latest/general/interactions/modes.html
    /// </summary>
    /// 
    [Newtonsoft.Json.JsonConverter(typeof(JsonToStringConverter<InteractionMode>))]
    public sealed class InteractionMode : StringEnum
    {
        public static InteractionMode Point => new InteractionMode("point");
        public static InteractionMode Nearest => new InteractionMode("nearest");
        public static InteractionMode Index => new InteractionMode("index");
        public static InteractionMode Dataset => new InteractionMode("dataset");
        public static InteractionMode X => new InteractionMode("x");
        public static InteractionMode Y => new InteractionMode("y");

        private InteractionMode(string stringRep) : base(stringRep) { }
    }
}