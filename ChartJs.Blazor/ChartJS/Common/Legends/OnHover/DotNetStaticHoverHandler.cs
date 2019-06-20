using ChartJs.Blazor.ChartJS.Common.Utils;
using Microsoft.JSInterop;

namespace ChartJs.Blazor.ChartJS.Common.Legends.OnHover
{
    public class DotNetStaticHoverHandler : ILegendOnHoverHandler
    {
        public string AssemblyName { get; }
        public string MethodName { get; }

        public delegate void LegendItemOnHover(object sender, object mouseMove);

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