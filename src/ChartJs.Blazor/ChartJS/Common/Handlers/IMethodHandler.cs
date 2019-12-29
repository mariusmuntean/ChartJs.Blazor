using System;
using System.Collections.Generic;
using System.Text;

namespace ChartJs.Blazor.ChartJS.Common.Handlers
{
    /// <summary>
    /// Defines that a type is able to handle method calls coming from Javascript.
    /// </summary>
    /// <typeparam name="T">The signature of the method this instance represents. It may be an actual object or just a convention for the programmer.</typeparam>
    public interface IMethodHandler<T> : IMethodHandler
        where T : Delegate
    {
    }

    /// <summary>
    /// Defines that a type is able to handle method calls coming from Javascript. In order to maintain the strongly typed nature of C#, please prefer using <see cref="IMethodHandler{T}"/>
    /// </summary>
    public interface IMethodHandler
    {
        /// <summary>
        /// The name of the method which should be called from Javascript. The method name can be a reference to C# or Javascript.
        /// </summary>
        public string MethodName { get; }
    }
}