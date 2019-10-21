namespace ChartJs.Blazor.ChartJS.ScatterChart
{
    public class ScatterAxis
    {
        public bool Display { get; set; }
        public string Text { get; set; }
        public string Position { get; set; }

        public string Type { get; set; } = "linear";

        public string Id { get; set; }

        public GridLineSettings GridLines { get; set; }
    }
}