namespace ChartJs.Blazor.ChartJS.Common.Enums
{
    /// <summary>
    /// Represents a relative direction or position on a 2D canvas
    /// </summary>
    public sealed class Positions : StringEnum
    {
        public static Positions Left => new Positions("left");
        public static Positions Right => new Positions("right");
        public static Positions Top => new Positions("top");
        public static Positions Bottom => new Positions("bottom");

        private Positions(string stringRep) : base(stringRep) { }
    }
}