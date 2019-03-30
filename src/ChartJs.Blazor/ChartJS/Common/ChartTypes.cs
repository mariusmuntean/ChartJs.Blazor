namespace ChartJs.Blazor.ChartJS.Common
{
    public class ChartTypes
    {
        public static readonly ChartTypes BAR = new ChartTypes("bar");
        public static readonly ChartTypes HORIZONTALBAR = new ChartTypes("horizontalBar");
        public static readonly ChartTypes LINE = new ChartTypes("line");
        public static readonly ChartTypes PIE = new ChartTypes("pie");
        public static readonly ChartTypes DOUGHNUT = new ChartTypes("doughnut");
        public static readonly ChartTypes RADAR = new ChartTypes("radar");
        public static readonly ChartTypes BUBBLE = new ChartTypes("bubble");
        public static readonly ChartTypes POLARAREA = new ChartTypes("polarArea");
        public static readonly ChartTypes SCATTER = new ChartTypes("scatter");

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