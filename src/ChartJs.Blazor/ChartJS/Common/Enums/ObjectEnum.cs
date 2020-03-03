using System;

namespace ChartJs.Blazor.ChartJS.Common.Enums
{
    /// <summary>
    /// The base class for enums that can represent different types. We also use these
    /// "enums" like Discriminated Unions to provide a type safe way of communicating with the
    /// dynamic language javascript is.
    /// <para>
    /// De-/serialization is supported but only for the following types:
    /// <see cref="int"/>, <see cref="double"/>, <see cref="string"/> and <see cref="bool"/>.
    /// For the deserialization, the constructors with a single parameter of a supported type
    /// are considered for instantiating the object enum.
    /// </para>
    /// <para>
    /// When implementing an object enum, make sure to provide only private constructors
    /// with the types that are allowed (DO NOT expose public constructors; expose meaningful
    /// factory methods instead). The actual enum values are static properties that pass
    /// the correct value to the private constructor. You can also have static factory methods that
    /// create an instance of the object enum with the specified value as long as the parameter
    /// type is supported. Also consider sealing your enum unless you have a specific reason not to.
    /// </para>
    /// </summary>
    [Newtonsoft.Json.JsonConverter(typeof(Serialization.JsonObjectEnumConverter))]
    public abstract class ObjectEnum
    {
        // TODO Have a static property that defines the supported types (probably int, bool, double and string)
        // and use it in the converter.

        /// <summary>
        /// Holds the actual value represented by this instance.
        /// </summary>
        internal object Value { get; }

        /// <summary>
        /// Creates a new instance of <see cref="ObjectEnum"/> with a value.
        /// </summary>
        /// <param name="value">The value this enum-instance is supposed to represent.</param>
        protected ObjectEnum(object value)
        {
            Value = value ?? throw new ArgumentNullException(nameof(value));
        }

        /// <summary>
        /// Returns the string representation of the underlying object. Calls <see cref="object.ToString"/>
        /// on the underlying object.
        /// </summary>
        /// <returns>The string representation of the underlying object.</returns>
        public override string ToString() => Value.ToString();

        // TODO: Check how to properly do equality stuff for this wrapper class
        // https://softwareengineering.stackexchange.com/questions/397235/should-wrappers-compare-as-equal-using-the-operator-when-they-wrap-the-same-o

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
            if (typeof(ObjectEnum).IsAssignableFrom(obj.GetType()) && obj != null)
                return Value.Equals(((ObjectEnum)obj).Value);

            return false;
        }

        /// <summary>
        /// Returns the hash of the underlying object.
        /// </summary>
        /// <returns>The hash of the underlying object.</returns>
        public override int GetHashCode() => Value.GetHashCode();
    }
}
