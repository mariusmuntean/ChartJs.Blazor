using System;
using System.Collections.Generic;
using System.Text;

namespace ChartJs.Blazor.ChartJS.Common.Enums
{
    public abstract class StringEnum
    {
        private readonly string _value;

        protected StringEnum(string value) => _value = value;

        public override string ToString() => _value;

        public static explicit operator string(StringEnum stringEnum) => stringEnum.ToString();


        public static bool operator == (StringEnum a, StringEnum b) => a.ToString() == b.ToString();
        public static bool operator != (StringEnum a, StringEnum b) => a.ToString() != b.ToString();

        public override bool Equals(object obj)
        {
            if (typeof(StringEnum).IsAssignableFrom(obj.GetType())) return _value == obj.ToString();
            if (obj.GetType() == typeof(string)) return _value == (string)obj;

            return false;
        }

        public override int GetHashCode() => _value.GetHashCode();
    }
}
