using System;
using System.Collections.Generic;
using System.Text;

namespace ChartJs.Blazor.ChartJS.Common.Enums
{
    class TimeDistribution : StringEnum
    {
        public static TimeDistribution Linear => new TimeDistribution("linear");
        public static TimeDistribution Series => new TimeDistribution("series");

        private TimeDistribution(string stringRep) : base(stringRep) { }
    }
}
