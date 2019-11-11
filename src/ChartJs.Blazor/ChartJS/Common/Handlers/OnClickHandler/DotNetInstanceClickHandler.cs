using System;
using System.Linq;
using Microsoft.JSInterop;

namespace ChartJs.Blazor.ChartJS.Common.Handlers.OnClickHandler
{
    /// <summary>
    /// Specifies a .net instance method that should be called when clicking on a Legend item.
    /// </summary>
    public class DotNetInstanceClickHandler : IClickHandler
    {
        /// <summary>
        /// The delegate for a click handler.
        /// <para>Helps enforcing the signature of the legend item click handler</para>
        /// </summary>
        /// <param name="sender">The sender of the click event</param>
        /// <param name="args">Click event args</param>
        public delegate void InstanceClickHandler(object sender, object args);

        /// <summary>
        /// The <see cref="DotNetObjectReference"/> for the instance the delegate will be executed on.
        /// </summary>
        public DotNetObjectReference<object> InstanceRef { get; }

        /// <summary>
        /// The name of the method behind the delegate
        /// </summary>
        public string MethodName { get; }

        /// <summary>
        /// Creates a new instance of <see cref="DotNetStaticClickHandler"/>
        /// </summary>
        /// <param name="clickHandler">The delegate for a click handler.</param>
        public DotNetInstanceClickHandler(InstanceClickHandler clickHandler)
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
            // clickHandler.Method.DeclaringType.Assembly.GetName().Name;
            InstanceRef = DotNetObjectReference.Create(clickHandler.Target);
            MethodName = clickHandler.Method.Name;
        }
    }
}