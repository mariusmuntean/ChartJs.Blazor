namespace ChartJs.Blazor.ChartJS.Common.Enums
{
    /// <summary>
    /// As per documentation here https://www.chartjs.org/docs/latest/general/interactions/modes.html
    /// </summary>
    /// 
    [Newtonsoft.Json.JsonConverter(typeof(JsonToStringConverter<InteractionMode>))]
    public class InteractionMode : StringEnum
    {
        public static InteractionMode Point { get; } = new InteractionMode("point");
        public static InteractionMode Nearest { get; } = new InteractionMode("nearest");
        public static InteractionMode Index { get; } = new InteractionMode("index");
        public static InteractionMode Dataset { get; } = new InteractionMode("dataset");
        public static InteractionMode X { get; } = new InteractionMode("x");
        public static InteractionMode Y { get; } = new InteractionMode("y");

        private InteractionMode(string interactionMode) : base(interactionMode) { }
    }
}