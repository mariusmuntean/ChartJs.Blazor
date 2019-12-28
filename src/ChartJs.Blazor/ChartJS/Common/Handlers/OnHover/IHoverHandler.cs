namespace ChartJs.Blazor.ChartJS.Common.Handlers.OnHover
{
    /// <summary>
    /// The delegate for a hover handler.
    /// <para>Helps enforcing the signature of the legend item hover handler.</para>
    /// </summary>
    /// <param name="sender">The sender of the hover event</param>
    /// <param name="args">Hover event args</param>
    public delegate void LegendItemOnHover(object sender, object args);

    /// <summary>
    /// Specifies how hovering on items is handled.
    /// </summary>
    public interface IHoverHandler : IMethodHandler<LegendItemOnHover>
    {
    }
}