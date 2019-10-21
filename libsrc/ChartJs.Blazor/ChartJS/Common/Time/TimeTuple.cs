using Newtonsoft.Json;

namespace ChartJs.Blazor.ChartJS.Common.Time
{
    /// <summary>
    /// Represents a point on a graph where the X-Value (<see cref="Time"></see>) is represented by a <see cref="Moment"></see>
    /// <para>Should be used together with a <see cref="Axes.TimeAxis"></see></para>
    /// <para>Reference Type so it can be used in the covariant <see cref="MixedChart.IMixableDataset{TData}"/></para>
    /// </summary>
    /// <typeparam name="TData"></typeparam>
    public class TimeTuple<TData>
    {
        /// <summary>
        /// Creates a new instance of <see cref="TimeTuple{TData}"/>
        /// </summary>
        /// <param name="time">The <see cref="Moment"/> instance to represent the x-value.</param>
        /// <param name="yValue">The value of type <typeparamref name="TData"/> which represents the y-value.</param>
        public TimeTuple(Moment time, TData yValue)
        {
            Time = time;
            YValue = yValue;
        }

        /// <summary>
        /// The time-/x-value for this <see cref="TimeTuple{TData}"/>.
        /// </summary>
        [JsonProperty("t")]
        public Moment Time { get; set; }

        /// <summary>
        /// The y-value for this <see cref="TimeTuple{TData}"/>.
        /// </summary>
        [JsonProperty("y")]
        public TData YValue { get; set; }
    }
}
