using System;

namespace ChartJs.Blazor.ChartJS.Common.Utils
{
    public class PointUtil
    {
        private static Random rand = new Random();

        public static Point NewRandPoint(double minX, double maxX, double minY, double maxY)
        {
            if (minX > maxX)
            {
                throw new ArgumentOutOfRangeException(nameof(minX), $"{nameof(minX)} must be less than {nameof(maxX)}");
            }

            if (minY > maxY)
            {
                throw new ArgumentOutOfRangeException(nameof(minY), $"{nameof(minY)} must be less than {nameof(maxY)}");
            }

            var xRange = Math.Abs(maxX - minX);
            var yRange = Math.Abs(maxY - minY);

            var randX = minX + (rand.NextDouble() * xRange);
            var randY = minY + (rand.NextDouble() * yRange);

            return new Point(randX, randY);
        }
    }
}