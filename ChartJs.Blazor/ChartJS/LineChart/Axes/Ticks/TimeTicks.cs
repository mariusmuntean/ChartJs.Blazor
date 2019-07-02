using ChartJs.Blazor.ChartJS.Common;
using ChartJs.Blazor.ChartJS.Common.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChartJs.Blazor.ChartJS.LineChart.Axes.Ticks
{
    public class TimeTicks : CartesianTicks
    {
        /// <summary>
        /// How ticks are generated. 
        /// </summary>
        public TickSource Source { get; set; }
    }
}
