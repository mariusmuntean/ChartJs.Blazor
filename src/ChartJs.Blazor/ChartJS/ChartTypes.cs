namespace ChartJs.Blazor.ChartJS
{
    public class ChartTypes
    {
        public static ChartTypes BAR = new ChartTypes("bar");
        public static ChartTypes HORIZONTALBAR = new ChartTypes("horizontalBar");
        public static ChartTypes LINE = new ChartTypes("line");
        public static ChartTypes PIE = new ChartTypes("pie");
        public static ChartTypes DOUGHNUT = new ChartTypes("doughnut");
        public static ChartTypes RADAR = new ChartTypes("radar");
        public static ChartTypes BUBBLE = new ChartTypes("bubble");

        private readonly string _chartType;

        private ChartTypes(string chartType)
        {
            _chartType = chartType;
        }

        public override string ToString()
        {
            return _chartType;
        }
    }
}