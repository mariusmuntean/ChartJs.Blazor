using System;

namespace ChartJs.Blazor.ChartJS.Common.Time
{
    /// <summary>
    /// Represents a point which has a <see cref="DateTime"/> as X-value (serialized as 't').
    /// <para>Should be used together with a <see cref="Axes.TimeAxis"/>.</para>
    /// </summary>
    public readonly struct TimePoint : IEquatable<TimePoint>
    {
        /// <summary>
        /// The X-value of this point.
        /// </summary>
        [Newtonsoft.Json.JsonProperty("t")]
        public readonly DateTime Time;

        /// <summary>
        /// The Y-value of this point.
        /// </summary>
        public readonly double Y;

        /// <summary>
        /// Creates a new <see cref="TimePoint"/>.
        /// </summary>
        /// <param name="time">The X-value for this point.</param>
        /// <param name="y">The Y-value for this point.</param>
        public TimePoint(DateTime time, double y)
        {
            Time = time;
            Y = y;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        public override bool Equals(object obj) => obj is TimePoint point && Equals(point);
        public bool Equals(TimePoint other) => Time == other.Time && Y == other.Y;
        public override int GetHashCode() => HashCode.Combine(Time, Y);

        public static bool operator ==(TimePoint left, TimePoint right) => left.Equals(right);
        public static bool operator !=(TimePoint left, TimePoint right) => !(left == right);
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
    }
}