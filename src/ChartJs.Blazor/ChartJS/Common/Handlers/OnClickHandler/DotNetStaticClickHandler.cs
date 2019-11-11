using ChartJs.Blazor.ChartJS.Common.Utils;
using Microsoft.JSInterop;

namespace ChartJs.Blazor.ChartJS.Common.Handlers.OnClickHandler
{
    /// <summary>
    /// Specifies a static .net method that should be called when clicking
    /// </summary>
    public class DotNetStaticClickHandler : IClickHandler
    {
        /// <summary>
        /// The delegate for a click handler.
        /// <para>Helps enforcing the signature of the legend item click handler</para>
        /// </summary>
        /// <param name="sender">The sender of the click event</param>
        /// <param name="args">Click event args</param>
        public delegate void StaticClickHandler(object sender, object args);

        /// <summary>
        /// The name of the assembly the method is located in
        /// </summary>
        public string AssemblyName { get; }

        /// <summary>
        /// The name of the method behind the delegate
        /// </summary>
        public string MethodName { get; }

        /// <summary>
        /// Creates a new instance of <see cref="DotNetStaticClickHandler"/>
        /// </summary>
        /// <param name="clickHandler">The delegate for a click handler</param>
        public DotNetStaticClickHandler(StaticClickHandler clickHandler)
        {
            ArgValidation.AssertNotNullOrEmpty(nameof(clickHandler), clickHandler);

            // the method needs to be public and static
            ArgValidation.AssertIsPublic(clickHandler.Method);
            ArgValidation.AssertIsStatic(clickHandler.Method);

            // the method needs to have the attribute JSInvokable
            ArgValidation.AssertHasCustomAttribute(clickHandler.Method, typeof(JSInvokableAttribute));

            //AssemblyName = assembly.GetName().Name;
            AssemblyName = clickHandler.Method.DeclaringType.Assembly.GetName().Name;
            MethodName = clickHandler.Method.Name;
        }
    }
}