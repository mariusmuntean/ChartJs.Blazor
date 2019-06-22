using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text;

namespace ChartJs.Blazor.ChartJS.Common.Enums
{
    public abstract class ObjectEnum
    {
        public object Value { get; }

        protected ObjectEnum(object value) => Value = value;

        public override string ToString() => Value.ToString();

        public static bool operator == (ObjectEnum a, ObjectEnum b) => a == b;
        public static bool operator != (ObjectEnum a, ObjectEnum b) => a != b;

        public override bool Equals(object obj)
        {
            return Value.Equals(obj);
        }

        public override int GetHashCode() => Value.GetHashCode();
    }
}
