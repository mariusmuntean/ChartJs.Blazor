namespace ChartJs.Blazor.ChartJS.Common.Legends.OnClickHandler
{
    /// <summary>
    /// Specified the namespace and name of a Javascript function that should be invoked when clicking Legend items
    /// </summary>
    public class JsClickHandler : ILegendClickHandler
    {
        /// <summary>
        /// The namespace and name of a Javascript function to be called when clicking on a Legend item.
        /// <para>E.g. "SampleFunctions.HideOtherDatasetsFunc"</para>
        /// <para>Note 1: You must create this function in your JS file in wwwroot and reference it in index.html</para>
        /// <para>Note 2: Make sure the function can handle the click sender and the click event args</para>
        /// </summary>
        public string FullFunctionName { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <param name="fullFunctionName">The namespace and name of a Javascript function to be called when clicking on a Legend item.</param>
        public JsClickHandler(string fullFunctionName)
        {
            FullFunctionName = fullFunctionName;
        }
    }
}