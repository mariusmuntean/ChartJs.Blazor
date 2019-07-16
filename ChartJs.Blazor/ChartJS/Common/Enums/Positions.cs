namespace ChartJs.Blazor.ChartJS.Common.Enums
{
    /// <summary>
    /// Represents a relative direction or position on a 2D canvas
    /// </summary>
    public sealed class Positions : StringEnum
    {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        public static Positions Left => new Positions("left");
        public static Positions Right => new Positions("right");
        public static Positions Top => new Positions("top");
        public static Positions Bottom => new Positions("bottom");
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member

        private Positions(string stringRep) : base(stringRep) { }
    }
}