using System;
using System.Linq;
using Microsoft.JSInterop;

namespace ChartJs.Blazor.ChartJS.Common.Legends
{
    /// <summary>
    /// Specifies how clicking on Legend items is handled
    /// </summary>
    public interface ILegendClickHandler
    {
    }

    /// <summary>
    /// Specified the namespace and name of a Javascript function that should be invoked when clicking Legend items
    /// </summary>
    public class JsClickHandler : ILegendClickHandler
    {
        /// <summary>
        /// The namespace and name of a Javascript function to be called when clicking on a Legend item.
        /// <para>E.g. "SampleFunctions.HideOtherDatasetsFunc"</para>
        /// <para>Note 1: You must create this function in your JS file in wwwroot and reference it in index.html</para>
        /// <para>Note ": Make sure the function can handle the click sender ad the click event args</para>
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

    /// <summary>
    /// Specifies the assembly name and the name of a static .Net method that should be called when clicking on a Legend item.
    /// </summary>
    public class DotNetStaticClickHandler : ILegendClickHandler
    {
        /// <summary>
        /// A delegate for a click handler.
        /// <para>Helps enforcing the signature of the legend item click handler</para>
        /// </summary>
        /// <param name="sender">The sender of the click event</param>
        /// <param name="args">Click event args</param>
        public delegate void StaticClickHandler(object sender, object args);

        public string AssemblyName { get; }

        public string MethodName { get; }

        public DotNetStaticClickHandler(StaticClickHandler clickHandler)
        {
            if (clickHandler == null)
            {
                throw new ArgumentNullException(nameof(clickHandler));
            }

            // the method needs to be public
            if (!clickHandler.Method.IsPublic)
            {
                throw new ArgumentException("The click handler needs to be public", nameof(clickHandler));
            }

            // the method needs to be static
            if (!clickHandler.Method.IsStatic)
            {
                throw new ArgumentException("The click handler needs to be static", nameof(clickHandler));
            }

            // the method needs to have the attribute JSInvokable
            var isJsInvokable = clickHandler
                .Method
                .CustomAttributes.Any(data => data.AttributeType == typeof(JSInvokableAttribute));
            if (!isJsInvokable)
            {
                throw new ArgumentException("The passed in method must have the 'JSInvokable' attribute",
                    nameof(clickHandler));
            }

            //AssemblyName = assembly.GetName().Name;
            AssemblyName = clickHandler.Method.DeclaringType.Assembly.GetName().Name;
            MethodName = clickHandler.Method.Name;
        }
    }
}