using ChartJs.Blazor.ChartJS.Common.Legends.OnClickHandler;
using ChartJs.Blazor.ChartJS.Common.Legends.OnHover;

namespace ChartJs.Blazor.ChartJS.Common.Legends
{
    /// <summary>
    /// The chart legend displays data about the datasets that are appearing on the chart.
    /// <para>Link: http://www.chartjs.org/docs/latest/configuration/legend.html </para>
    /// </summary>
    public class Legend
    {
        /// <summary>
        /// is the legend shown
        /// </summary>
        public bool Display { get; set; } = true;

        /// <summary>
        /// Position of the legend
        /// </summary>
        public string Position { get; set; } = LegendPosition.TOP.ToString();

        /// <summary>
        /// Marks that this box should take the full width of the canvas (pushing down other boxes). This is unlikely to need to be changed in day-to-day use.
        /// </summary>
        public bool FullWidth { get; set; } = true;

        /// <summary>
        /// The name of a callback that is called when a click event is registered on a label item.
        /// <para>E.g. "MyProjectNamespace.MyOnClickFunctionName" </para>
        /// </summary>
        public ILegendClickHandler OnClick { get; set; }

        /// <summary>
        /// The name of a callback that is called when a 'mousemove' event is registered on top of a label item
        /// <para> E.g. "MyProjectNamespace.MyOnHoverFuncName" </para>
        /// </summary>
        public ILegendOnHoverHandler OnHover { get; set; }

        /// <summary>
        /// Legend will show datasets in reverse order.
        /// </summary>
        public bool Reverse { get; set; } = false;

        public Labels Labels { get; set; } = new Labels();
    }
}