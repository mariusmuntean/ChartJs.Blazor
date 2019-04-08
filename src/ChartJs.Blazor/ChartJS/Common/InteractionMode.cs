namespace ChartJs.Blazor.ChartJS.Common
{
    public class InteractionMode
    {
        /// <summary>
        /// As per documentation here https://www.chartjs.org/docs/latest/general/interactions/modes.html
        /// </summary>
        public static readonly InteractionMode Point = new InteractionMode("point");
        public static readonly InteractionMode Nearest = new InteractionMode("nearest");
        public static readonly InteractionMode Index = new InteractionMode("index");
        public static readonly InteractionMode Dataset = new InteractionMode("dataset");
        public static readonly InteractionMode X = new InteractionMode("x");
        public static readonly InteractionMode Y = new InteractionMode("y");


        private readonly string _interactionmode;

        public InteractionMode(string interactionMode)
        {
            _interactionmode = interactionMode;
        }

        public override string ToString()
        {
            return _interactionmode;
        }
    }
}