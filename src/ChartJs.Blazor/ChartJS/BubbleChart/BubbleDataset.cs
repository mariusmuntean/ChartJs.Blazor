using System;
using System.Collections.Generic;
using ChartJs.Blazor.ChartJS.Common;
using ChartJs.Blazor.ChartJS.Common.Enums;
using ChartJs.Blazor.Util;

namespace ChartJs.Blazor.ChartJS.BubbleChart
{
    public class BubbleDataset : IDataset
    {
        public string Id { get; } = Guid.NewGuid().ToString();
        
        /// <summary>
        /// rgba(0,0,0,0.1)'.
        /// <para>See <see cref="ColorUtil"/> for working with colors.</para>
        /// </summary>
        public string BackgroundColor { get; set; } = ColorUtil.ColorString(0, 0, 0, 0.1);

        /// <summary>
        /// rgba(0,0,0,0.1)'.
        /// <para>See <see cref="ColorUtil"/> for working with colors.</para>
        /// </summary>
        public string BorderColor { get; set; } = ColorUtil.ColorString(0, 0, 0, 0.1);

        /// <summary>
        /// Default 3
        /// </summary>
        public int BorderWidth { get; set; } = 3;

        public List<BubbleDataPoint> Data { get; set; } = new List<BubbleDataPoint> {new BubbleDataPoint {X = 1, Y = 2, r = 3}};

        /// <summary>
        /// <para>See <see cref="ColorUtil"/> for working with colors.</para>
        /// </summary>
        public string HoverBackgroundColor { get; set; }

        /// <summary>
        /// <para>See <see cref="ColorUtil"/> for working with colors.</para>
        /// </summary>
        public string HoverBorderColor { get; set; }

        public int HoverBorderWidth { get; set; } = 1;

        public int HoverRadius { get; set; } = 4;

        public int HitRadius { get; set; } = 1;

        /// <summary>
        /// Defines the text associated to the dataset and which appears in the legend and tooltips.
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// Gets or sets the point style.
        /// </summary>
        public IndexableOption<PointStyle> PointStyle { get; set; }

        public int Rotation { get; set; } = 0;

        public int Radius { get; set; } = 3;

        public ChartType Type { get; } = ChartType.Bubble;
    }
}