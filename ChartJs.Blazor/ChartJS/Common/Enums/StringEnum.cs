using Newtonsoft.Json;
using ChartJs.Blazor.ChartJS.Common.Enums.JsonConverter;

namespace ChartJs.Blazor.ChartJS.Common.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public abstract class StringEnum
    {
        private readonly string _value;

        protected StringEnum(string stringRep) => _value = stringRep;

        public override string ToString() => _value;

        public static explicit operator string(StringEnum stringEnum) => stringEnum.ToString();


        public static bool operator == (StringEnum a, StringEnum b) => a.ToString() == b.ToString();
        public static bool operator != (StringEnum a, StringEnum b) => a.ToString() != b.ToString();

        public override bool Equals(object obj)
        {
            if (typeof(StringEnum).IsAssignableFrom(obj.GetType())) return _value.Equals(obj.ToString());

            // it also counts as equal if the object to compare is equal to the string stored in the wrapper
            if (obj.GetType() == typeof(string)) return _value.Equals((string)obj);

            return false;
        }

        public override int GetHashCode() => _value.GetHashCode();
    }
}
