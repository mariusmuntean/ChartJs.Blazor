using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChartJs.Blazor.ChartJS.LineChart
{
    /// <summary>
    /// Wrapper class for <see cref="DateTime"></see> for serialization purposes.
    /// </summary>
    [JsonConverter(typeof(JsonMomentConverter))]
    public class Moment
    {
        private DateTime Value { get; }

        public Moment(DateTime value) => Value = value;

        public static implicit operator Moment(DateTime dateTime) => new Moment(dateTime);

        public static implicit operator DateTime(Moment moment) => moment.Value;

        public override bool Equals(object obj)
        {
            if(obj.GetType() == typeof(Moment)) return Value.Equals(((Moment)obj).Value);

            return Value.Equals(obj);
        }

        public override int GetHashCode() => Value.GetHashCode();

        public override string ToString() => Value.ToString("o");
    }
}
