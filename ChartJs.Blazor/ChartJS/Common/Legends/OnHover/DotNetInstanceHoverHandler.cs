using ChartJs.Blazor.ChartJS.Common.Utils;
using Microsoft.JSInterop;

namespace ChartJs.Blazor.ChartJS.Common.Legends.OnHover
{
    /// <summary>
    /// Specifies a .net instance method that should be called when hovering on a Legend item.
    /// </summary>
    public class DotNetInstanceHoverHandler : ILegendHoverHandler
    {
        /// <summary>
        /// The <see cref="DotNetObjectRef"/> for the instance the delegate will be executed on.
        /// </summary>
        public DotNetObjectRef<object> InstanceRef { get; }

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
        /// Creates a new instance of <see cref="DotNetInstanceHoverHandler"/>
        /// </summary>
        /// <param name="legendItemOnHoverHandler">The delegate for a hover handler</param>
        public DotNetInstanceHoverHandler(LegendItemOnHover legendItemOnHoverHandler)
        {
            // Check for null
            ArgValidation.AssertNotNullOrEmpty(nameof(legendItemOnHoverHandler), legendItemOnHoverHandler);

            // Check for the method to be public and static
            ArgValidation.AssertIsPublic(legendItemOnHoverHandler.Method);

            // Check for the JsInvokable attribute
            ArgValidation.AssertHasCustomAttribute(legendItemOnHoverHandler.Method, typeof(JSInvokableAttribute));

            // The parameters and return type is taken care of by the delegate's definition

            InstanceRef = DotNetObjectRef.Create(legendItemOnHoverHandler.Target);
            MethodName = legendItemOnHoverHandler.Method.Name;
        }
    }
}