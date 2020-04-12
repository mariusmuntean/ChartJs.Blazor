using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ChartJs.Blazor.ChartJS.Common
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public readonly struct Point : IEquatable<Point>
    {
        public readonly double X, Y;

        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        public override bool Equals(object obj) => obj is Point point && Equals(point);
        public bool Equals(Point other) => X == other.X && Y == other.Y;
        public override int GetHashCode() => HashCode.Combine(X, Y);

        public static bool operator ==(Point left, Point right) => left.Equals(right);
        public static bool operator !=(Point left, Point right) => !(left == right);
    }
}