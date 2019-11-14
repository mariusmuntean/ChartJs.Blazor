using Newtonsoft.Json;
using System;

namespace ChartJs.Blazor.ChartJS.Common.Time
{
    /// <summary>
    /// Wrapper class for <see cref="DateTime"></see> for serialization purposes.
    /// </summary>
    // This wrapper can be removed if https://github.com/aspnet/AspNetCore/issues/12685 passes 
    // because then we can just write a custom converter for DateTime and add that to 
    // the options so it's used for every DateTime it sees. This should not have side effects.
    [JsonConverter(typeof(JsonMomentConverter))]
    public class Moment
    {
        private DateTime Value { get; }

        /// <summary>
        /// Creates a new <see cref="Moment"/> which wraps the provided <see cref="DateTime"/>
        /// </summary>
        /// <param name="value">The <see cref="DateTime"/> value to wrap</param>
        public Moment(DateTime value) => Value = value;

        /// <summary>
        /// Creates a new wrapper for the provided <see cref="DateTime"/>
        /// </summary>
        /// <param name="dateTime"></param>
        public static explicit operator Moment(DateTime dateTime) => new Moment(dateTime);

        /// <summary>
        /// Extracts the <see cref="DateTime"/> value wrapped in the provided instance
        /// </summary>
        /// <param name="moment"></param>
        public static explicit operator DateTime(Moment moment) => moment.Value;

        /// <summary>
        /// Returns the value indicating whether this instance is equal to a specified object.
        /// </summary>
        /// <param name="obj">The object to compare to this instance.</param>
        /// <returns>true if the other object is a wrapper for the same <see cref="DateTime"/> value 
        /// or if it's the same <see cref="DateTime"/> value as wrapped in this instance.</returns>
        public override bool Equals(object obj)
        {
            if(obj.GetType() == typeof(Moment)) return Value.Equals(((Moment)obj).Value);

            return Value.Equals(obj);
        }

        /// <summary>
        /// Returns the HashCode for this instance.
        /// </summary>
        /// <returns>The HashCode for this instance</returns>
        public override int GetHashCode() => Value.GetHashCode();

        /// <summary>
        /// Converts the wrapped <see cref="DateTime"/> to a format which is readable for moment.js.
        /// </summary>
        /// <returns>The string representation of this instance</returns>
        public override string ToString() => Value.ToString("o"); // https://docs.microsoft.com/en-us/dotnet/api/system.datetime.tostring?view=netframework-4.8
    }
}
