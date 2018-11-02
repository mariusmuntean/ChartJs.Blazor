namespace ChartJs.Blazor.ChartJS.Common
{
    public class LegendPosition
    {
        private readonly string _position;

        public static LegendPosition TOP = new LegendPosition("top");
        public static LegendPosition RIGHT = new LegendPosition("right");
        public static LegendPosition LEFT = new LegendPosition("left");
        public static LegendPosition BOTTOM = new LegendPosition("bottom");

        private LegendPosition(string position)
        {
            _position = position;
        }

        public override string ToString()
        {
            return _position;
        }
    }
}