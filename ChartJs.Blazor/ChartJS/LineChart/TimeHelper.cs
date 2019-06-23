using System;
using System.Collections.Generic;
using System.Text;

namespace ChartJs.Blazor.ChartJS.LineChart
{
    public static class TimeHelper
    {
        public static string GetMomentString(DateTime dateTime) => $"moment({dateTime.ToString("o")})";
    }
}
