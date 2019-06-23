using ChartJs.Blazor.ChartJS.Common.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChartJs.Blazor.ChartJS.LineChart
{
    class TimeAxis : Axis
    {
        // continue: https://www.chartjs.org/docs/latest/axes/cartesian/time.html

        public string Type => "time";
        public TimeDistribution Distribution { get; set; }


    }
}
