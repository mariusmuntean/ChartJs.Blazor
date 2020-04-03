using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChartJs.Blazor.Interop
{
    /// <summary>
    /// Contains information about a Javascript function with a certain signature which will be called internally by Javascript.
    /// The type parameter <typeparamref name="T"/> defines the signature for the Javascript method but doesn't have any actual use other than that.
    /// </summary>
    /// <typeparam name="T">The signature of the method you want to invoke from Javascript. This type parameter is
    /// nothing more than a convention which tells you what parameters and return type is expected from the Javascript function.
    /// Just like you might mistype the method name, you might return the wrong value from Javascript. These cases can't be caught
    /// by the compiler so make sure to double-check those.</typeparam>
    public class JavascriptHandler<T> : IMethodHandler<T>
        where T : Delegate
    {
        /// <summary>
        /// The namespace and name of a Javascript function to be called, separated by a point.
        /// <para>E.g. "SampleFunctions.ItemHoverHandler"</para>
        /// <para>Note 1: You must create this function in a JS file in wwwroot and reference it in index.html / _Host.cshtml.</para>
        /// <para>Note 2: Make sure the function has the expected parameters and return type. See <typeparamref name="T"/> for the expected signature.</para>
        /// </summary>
        public string MethodName { get; }

        /// <summary>
        /// Creates a new instance of <see cref="JavascriptHandler{T}"/>.
        /// </summary>
        /// <param name="methodName">The namespace and name of a Javascript function (see <see cref="MethodName"/> for details).</param>
        public JavascriptHandler(string methodName)
        {
            if (string.IsNullOrWhiteSpace(methodName))
                throw new ArgumentException("The method name cannot be null or whitespace. It has to include the namespace and name of the js-function.");

            if (methodName.Length < 3 || methodName.Count(c => c == '.') > 1)
                throw new ArgumentException("The method name has to contain the namespace and name of the js-function separated by a single point.");

            MethodName = methodName;
        }

        /// <summary>
        /// Converts a string to a <see cref="JavascriptHandler{T}"/> implicitly.
        /// </summary>
        /// <param name="methodName">The namespace and name of a Javascript function to be called, separated by a point (see <see cref="MethodName"/> for details).</param>
        public static implicit operator JavascriptHandler<T>(string methodName) => new JavascriptHandler<T>(methodName);
    }
}
