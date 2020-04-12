using System;
using ChartJs.Blazor.ChartJS.Common;

namespace ChartJs.Blazor.ChartJS.BubbleChart
{
    public readonly struct BubblePoint : IEquatable<BubblePoint>
    {
        public readonly double X, Y, R;

        public BubblePoint(double x, double y, double r)
        {
            X = x;
            Y = y;
            R = r;
        }

        public override bool Equals(object obj) => obj is BubblePoint point && Equals(point);
        public bool Equals(BubblePoint other) => X == other.X && Y == other.Y && R == other.R;
        public override int GetHashCode() => HashCode.Combine(X, Y, R);

        public static bool operator ==(BubblePoint left, BubblePoint right) => left.Equals(right);
        public static bool operator !=(BubblePoint left, BubblePoint right) => !(left == right);
    }
}