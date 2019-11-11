using ChartJs.Blazor.ChartJS.Common.Utils;
using Microsoft.JSInterop;

namespace ChartJs.Blazor.ChartJS.Common.Handlers.OnHover
{
    /// <summary>
    /// Specifies a static .net method that should be called when hovering on an item.
    /// </summary>
    public class DotNetStaticHoverHandler : IHoverHandler
    {
        /// <summary>
        /// The name of the assembly the method is located in
        /// </summary>
        public string AssemblyName { get; }

        /// <summary>
        /// The name of the method behind the delegate
        /// </summary>
        public string MethodName { get; }

        /// <summary>
        /// The delegate for a hover handler.
        /// <para>Helps enforcing the signature of the legend item hover handler</para>
        /// </summary>
        /// <param name="sender">The sender of the hover event</param>
        /// <param name="mouseMove"></param>
        public delegate void LegendItemOnHover(object sender, object mouseMove);

        /// <summary>
        /// Creates a new instance of <see cref="DotNetStaticHoverHandler"/>
        /// </summary>
        /// <param name="legendItemOnHoverHandler">The delegate for a hover handler.</param>
        public DotNetStaticHoverHandler(LegendItemOnHover legendItemOnHoverHandler)
        {
            // Check for null
            ArgValidation.AssertNotNullOrEmpty(nameof(legendItemOnHoverHandler), legendItemOnHoverHandler);

            // Check for the method to be public and static
            ArgValidation.AssertIsPublic(legendItemOnHoverHandler.Method);
            ArgValidation.AssertIsStatic(legendItemOnHoverHandler.Method);

            // Check for the JsInvokable attribute
            ArgValidation.AssertHasCustomAttribute(legendItemOnHoverHandler.Method, typeof(JSInvokableAttribute));

            AssemblyName = legendItemOnHoverHandler.Method.DeclaringType.Assembly.GetName().Name;
            MethodName = legendItemOnHoverHandler.Method.Name;
        }
    }
}