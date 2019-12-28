namespace ChartJs.Blazor.ChartJS.Common.Handlers.OnClickHandler
{
    /// <summary>
    /// The delegate for a click handler.
    /// <para>Helps enforcing the signature of the legend item click handler.</para>
    /// </summary>
    /// <param name="sender">The sender of the click event</param>
    /// <param name="args">Click event args</param>
    public delegate void LegendItemOnClick(object sender, object args);

    /// <summary>
    /// Specifies how clicking items is handled.
    /// </summary>
    public interface IClickHandler : IMethodHandler<LegendItemOnClick>
    {
    }
}