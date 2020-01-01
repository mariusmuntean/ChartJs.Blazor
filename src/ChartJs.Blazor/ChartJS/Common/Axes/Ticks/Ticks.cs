﻿using ChartJs.Blazor.Util;
using ChartJs.Blazor.ChartJS.Common.Enums;

namespace ChartJs.Blazor.ChartJS.Common.Axes.Ticks
{
    /// <summary>
    /// The base class for all tick mark configurations. Ticks-subconfig of the common <see cref="Axis"/>.
    /// <para>As per documentation here https://www.chartjs.org/docs/latest/axes/styling.html#tick-configuration </para>
    /// </summary>
    public abstract class Ticks : SubTicks
    {
        /// <summary>
        /// Gets or sets the value indicating whether this axis displays tick marks.
        /// </summary>
        public bool Display { get; set; } = true;

        /// <summary>
        /// Gets or sets the value indicating whether the order of the tick labels is reversed.
        /// </summary>
        public bool Reverse { get; set; } = false;

        /// <summary>
        /// Gets or sets the minor ticks configuration. Omitted options are inherited.
        /// </summary>
        public MinorTicks Minor { get; set; }

        /// <summary>
        /// Gets or sets the major ticks configuration. Omitted options are inherited.
        /// </summary>
        public MajorTicks Major { get; set; }

        /// <summary>
        /// Gets or sets the offset of the tick labels from the axis. When set on a vertical axis, this applies in the horizontal (X) direction.
        /// When set on a horizontal axis, this applies in the vertical (Y) direction.
        /// </summary>
        public int Padding { get; set; } = 0;

        /// <summary>
        /// Gets or sets the Z-index of the tick layer. Useful when ticks are drawn on chart area. Values &lt;= 0 are drawn under datasets, &gt; 0 on top.
        /// </summary>
        public int Z { get; set; }
    }
}