namespace ChartJs.Blazor.ChartJS.Common
{
    public class HoverModes
    {
        public static readonly HoverModes NEAREST = new HoverModes("nearest");

        private readonly string _hoverMode;

        private HoverModes(string hoverMode)
        {
            _hoverMode = hoverMode;
        }

        public override string ToString()
        {
            return _hoverMode;
        }
    }
}