namespace ChartJs.Blazor.ChartJS.Common
{
    public class Point
    {
        public Point()
        {
        }

        public Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public double x { get; set; }
        public double y { get; set; }
    }
}