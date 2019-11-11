namespace ChartJs.Blazor.ChartJS.Common.Handlers.OnHover
{
    /// <summary>
    /// Specified the namespace and name of a Javascript function that should be invoked when hovering
    /// </summary>
    public class JsHoverHandler : IHoverHandler
    {
        /// <summary>
        /// The namespace and name of a Javascript function to be called when hovering the mouse cursor over a Legend item.
        /// <para>E.g. "SampleFunctions.ItemHoverHandler"</para>
        /// <para>Note 1: You must create this function in your JS file in wwwroot and reference it in index.html</para>
        /// <para>Note 2: Make sure the function can handle the 'mousemove' event</para>
        /// </summary>
        public string FullFunctionName { get; }

        /// <summary>
        /// Creates a new instance of <see cref="JsHoverHandler"/>
        /// </summary>
        /// <param name="fullFunctionName">The namespace and name of a Javascript function to be called when hovering on a Legend item.</param>
        public JsHoverHandler(string fullFunctionName)
        {
            FullFunctionName = fullFunctionName;
        }
    }
}