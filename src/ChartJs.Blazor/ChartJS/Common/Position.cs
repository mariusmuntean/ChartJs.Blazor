namespace ChartJs.Blazor.ChartJS.Common
{
    public class Position
    {
        private readonly string _position;

        public static Position TOP = new Position("top");
        public static Position RIGHT = new Position("right");

        private Position(string position)
        {
            _position = position;
        }

        public override string ToString()
        {
            return _position;
        }
    }
}