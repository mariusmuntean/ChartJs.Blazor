namespace ChartJs.Blazor.ChartJS.Common
{
    public class InteractionMode
    {
        /// <summary>
        /// As per documentation here https://www.chartjs.org/docs/latest/general/interactions/modes.html
        /// </summary>
        public static InteractionMode Point { get; } = new InteractionMode("point");
        public static InteractionMode Nearest { get; } = new InteractionMode("nearest");
        public static InteractionMode Index { get; } = new InteractionMode("index");
        public static InteractionMode Dataset { get; } = new InteractionMode("dataset");
        public static InteractionMode X { get; } = new InteractionMode("x");
        public static InteractionMode Y { get; } = new InteractionMode("y");


        private readonly string _interactionmode;

        private InteractionMode(string interactionMode)
        {
            _interactionmode = interactionMode;
        }

        public override string ToString()
        {
            return _interactionmode;
        }
    }
}