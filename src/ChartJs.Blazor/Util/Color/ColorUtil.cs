using System;

namespace ChartJs.Blazor.Util.Color
{
    public static class ColorUtil
    {
        /// <summary>
        /// Produces a string of the form 'rgba(r, g, b, 1)' with the provided rgb values where the alpha is fixed at 1
        /// </summary>
        /// <param name="r"></param>
        /// <param name="g"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static string ColorString(byte r, byte g, byte b)
        {
            return $"rgba({r}, {g}, {b}, 1)";
        }

        /// <summary>
        /// Produces a string of the form 'rgba(r, g, b, 1)' with the provided rgb and alpha values
        /// </summary>
        /// <param name="r"></param>
        /// <param name="g"></param>
        /// <param name="b"></param>
        /// <param name="alpha"></param>
        /// <returns></returns>
        public static string ColorString(byte r, byte g, byte b, double alpha)
        {
            return $"rgba({r}, {g}, {b}, {alpha})";
        }

        /// <summary>
        /// Produces a string of the form 'rgba(r, g, b, 1)' with random values for rgb and alpha
        /// </summary>
        /// <returns></returns>
        public static string RandomColorString()
        {
            var rand = new Random();
            return $"rgba({1 + rand.Next(255)}, {1 + rand.Next(255)}, {1 + rand.Next(255)}, {rand.NextDouble()})";
        }
    }
}