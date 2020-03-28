using ChartJs.Blazor.ChartJS.Common.Handlers;
using ChartJs.Blazor.ChartJS.Common.Handlers.OnClickHandler;
using ChartJs.Blazor.ChartJS.Common.Properties;
using System;
using System.Collections.Generic;

namespace ChartJs.Blazor.ChartJS.Common
{
    /// <summary>
    /// The base config for the options-subconfig of a chart
    /// </summary>
    public class BaseConfigOptions
    {
        /// <summary>
        /// Represents the title of this chart
        /// </summary>
        public OptionsTitle Title { get; set; }

        /// <summary>
        /// Resizes the chart canvas when its container does.
        /// <para>See important note: https://www.chartjs.org/docs/latest/general/responsive.html#important-note </para>
        /// </summary>
        public bool Responsive { get; set; } = true;

        /// <summary>
        /// Canvas aspect ratio (i.e. width / height, a value of 1 representing a square canvas). 
        /// <para>Note that this option is ignored if the height is explicitly defined either as attribute (of the canvas) or via the style.</para>
        /// </summary>
        public double AspectRatio { get; set; } = 2;

        /// <summary>
        /// Maintain the original canvas aspect ratio (width / height) when resizing.
        /// </summary>
        public bool MaintainAspectRatio { get; set; } = true;

        /// <summary>
        /// Duration in milliseconds it takes to animate to new size after a resize event.
        /// </summary>
        public int ResponsiveAnimationDuration { get; set; }

        /// <summary>
        /// The legend for this chart
        /// </summary>
        public Legend Legend { get; set; } = new Legend();

        /// <summary>
        /// Gets or sets the tooltip options for this chart.
        /// </summary>
        public Tooltips Tooltips { get; set; }

        /// <summary>
        /// Gets or sets the animation-configuration for this chart.
        /// </summary>
        public Animation Animation { get; set; }

        /// <summary>
        /// Gets the plugin options. The key has to be the unique
        /// identification of the plugin.
        /// <para>
        /// Reference for chart.js plugin options: 
        /// <a href="https://www.chartjs.org/docs/latest/developers/plugins.html#plugin-options"/>
        /// </para>
        /// </summary>
        public Dictionary<string, object> Plugins { get; } = new Dictionary<string, object>();

        public IClickHandler OnClick { get; set; }

        public Hover Hover { get; set; }

        /// <summary>
        /// This method tells json.net to only serialize the plugin options when
        /// there are plugin options, don't call it directly.
        /// </summary>
        [Obsolete("Only for json.net, don't call it.", true)]
        public bool ShouldSerializePlugins() => Plugins.Count > 0;
    }
}