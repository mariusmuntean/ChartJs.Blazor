namespace ChartJs.Blazor.ChartJS.LineChart
{
    public class ScaleLabel
    {
        public ScaleLabel(string labelString = null)
        {
            LabelString = labelString;
        }

        public bool Display { get; set; } = true;
        public string LabelString { get; set; }
    }
}