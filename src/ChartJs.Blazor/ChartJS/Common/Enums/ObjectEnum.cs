using Newtonsoft.Json;
using ChartJs.Blazor.ChartJS.Common.Enums.JsonConverter;

namespace ChartJs.Blazor.ChartJS.Common.Enums
{
    /// <summary>
    /// Inherit this class if you are in need of a pseudo-Enum which can hold values of different kinds (eg. string, double and bool).
    /// </summary>
    [JsonConverter(typeof(JsonObjectEnumConverter))]
    public abstract class ObjectEnum
    {
        /// <summary>
        /// Holds the actual value represented by this instance.
        /// </summary>
        internal object Value { get; }
        
        /// <summary>
        /// Creates a new instance of <see cref="ObjectEnum"/> with a value.
        /// </summary>
        /// <param name="value">The value this enum-instance is supposed to represent.</param>
        protected ObjectEnum(object value) => Value = value;

        /// <summary>
        /// Returns the string representation of the underlying object. Calls <see cref="Value"/>.ToString().
        /// </summary>
        /// <returns>The string representation of the underlying object.</returns>
        public override string ToString() => Value.ToString();

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        public static bool operator == (ObjectEnum a, ObjectEnum b) => a.Value == b.Value;
        public static bool operator != (ObjectEnum a, ObjectEnum b) => a.Value != b.Value;
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member

        /// <summary>
        /// Determines whether the specified object instance is considered equal to the current instance.
        /// </summary>
        /// <param name="obj">The object to compare with.</param>
        /// <returns>true if the objects are considered equal; otherwise, false.</returns>
        public override bool Equals(object obj)
        {
            if (typeof(ObjectEnum).IsAssignableFrom(obj.GetType()) && obj != null) return Value.Equals(((ObjectEnum)obj).Value);

            // it also counts as equal if the object to compare is equal to the object stored in the wrapper
            return Value.Equals(obj);
        }

        /// <summary>
        /// Returns the hash of the underlying object.
        /// </summary>
        /// <returns>The hash of the underlying object.</returns>
        public override int GetHashCode() => Value.GetHashCode();
    }
}
