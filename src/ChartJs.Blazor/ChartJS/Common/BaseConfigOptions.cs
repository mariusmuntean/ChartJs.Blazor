using ChartJs.Blazor.ChartJS.Common.Enums;
using ChartJs.Blazor.ChartJS.Common.Handlers;
using ChartJs.Blazor.ChartJS.Common.Properties;
using ChartJs.Blazor.Interop;

namespace ChartJs.Blazor.ChartJS.Common
{
    /// <summary>
    /// The base config for the options-subconfig of a chart.
    /// </summary>
    public class BaseConfigOptions
    {
        /// <summary>
        /// Gets or sets the title of this chart.
        /// </summary>
        public OptionsTitle Title { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the chart canvas should be resized when its container is.
        /// <para>See important note: https://www.chartjs.org/docs/latest/general/responsive.html#important-note </para>
        /// </summary>
        public bool Responsive { get; set; } = true;

        /// <summary>
        /// Gets or sets the canvas aspect ratio (i.e. width / height, a value of 1 representing a square canvas). 
        /// <para>Note that this option is ignored if the height is explicitly defined either as attribute (of the canvas) or via the style.</para>
        /// </summary>
        public double AspectRatio { get; set; } = 2;

        /// <summary>
        /// Gets or sets a value indicating whether to maintain the original canvas aspect ratio (width / height) when resizing.
        /// </summary>
        public bool MaintainAspectRatio { get; set; } = true;

        /// <summary>
        /// Gets or sets the duration in milliseconds it takes to animate to new size after a resize event.
        /// </summary>
        public int ResponsiveAnimationDuration { get; set; }

        /// <summary>
        /// Gets or sets the legend for this chart.
        /// </summary>
        public Legend Legend { get; set; } = new Legend();

        /// <summary>
        /// Gets or sets the tooltip options for this chart.
        /// </summary>
        public Tooltips Tooltips { get; set; }

        /// <summary>
        /// Gets or sets the browser events that the chart should listen to for tooltips and hovering.
        /// <para>
        /// If <see langword="null"/>, this includes <see cref="BrowserEvent.MouseMove"/>, <see cref="BrowserEvent.MouseOut"/>,
        /// <see cref="BrowserEvent.Click"/>, <see cref="BrowserEvent.TouchStart"/> and <see cref="BrowserEvent.TouchMove"/>.
        /// </para>
        /// </summary>
        public BrowserEvent[] Events { get; set; }

        /// <summary>
        /// Called if the event is of type <see cref="BrowserEvent.MouseUp"/> or <see cref="BrowserEvent.Click"/>.
        /// Called in the context of the chart and passed the event and an array of active elements.
        /// </summary>
        public IMethodHandler<ChartMouseEvent> OnClick { get; set; }

        /// <summary>
        /// Called when any of the <see cref="Events"/> fire. Called in the context of the chart and passed the
        /// event and an array of active elements (bars, points, etc).
        /// </summary>
        public IMethodHandler<ChartMouseEvent> OnHover { get; set; }

        /// <summary>
        /// Gets or sets the hover configuration for this chart.
        /// </summary>
        public Hover Hover { get; set; }
    }
}