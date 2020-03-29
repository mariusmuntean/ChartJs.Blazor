using ChartJs.Blazor.ChartJS.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ChartJs.Blazor.Util
{
    /// <summary>
    /// Utility class for working with <see cref="Point"/>s
    /// </summary>
    public static class PointUtil
    {
        private static readonly Random s_rand = new Random();

        /// <summary>
        /// Creates a new <see cref="Point"/> whose x and y coordinates lay between the specified boundaries
        /// </summary>
        /// <param name="minX">Minimum value for the <see cref="Point"/>'s x coordinate</param>
        /// <param name="maxX">Maximum value for the <see cref="Point"/>'s x coordinate</param>
        /// <param name="minY">Minimum value for the <see cref="Point"/>'s y coordinate</param>
        /// <param name="maxY">Maximum value for the <see cref="Point"/>'s y coordinate</param>
        /// <returns></returns>
        public static Point GetRandomPoint(double minX = -10.0, double maxX = 10.0, double minY = -10.0, double maxY = 10.0)
        {
            if (minX > maxX)
            {
                throw new ArgumentOutOfRangeException(nameof(minX), $"{nameof(minX)} must be less than {nameof(maxX)}");
            }

            if (minY > maxY)
            {
                throw new ArgumentOutOfRangeException(nameof(minY), $"{nameof(minY)} must be less than {nameof(maxY)}");
            }

            double x;
            double y;

            lock (s_rand)
            {
                x = minX + (s_rand.NextDouble() * (maxX - minX));
                y = minY + (s_rand.NextDouble() * (maxY - minY));
            }
            
            return new Point(x, y);
        }

        /// <summary>
        /// Creates a new <see cref="List{Point}"/> whose x and y coordinates lay between the specified boundaries
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="minX">Minimum value for the <see cref="Point"/>'s x coordinate</param>
        /// <param name="maxX">Maximum value for the <see cref="Point"/>'s x coordinate</param>
        /// <param name="minY">Minimum value for the <see cref="Point"/>'s y coordinate</param>
        /// <param name="maxY">Maximum value for the <see cref="Point"/>'s y coordinate</param>
        /// <returns></returns>
        public static List<Point> GetRandomPoints(int amount = 10,
            double minX = -10.0,
            double maxX = 10.0,
            double minY = -10.0,
            double maxY = 10.0) =>
            Enumerable.Range(0, amount)
                .Select(i => GetRandomPoint(minX, maxX, minY, maxY))
                .ToList();
    }
}