using Microsoft.JSInterop;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ChartJs.Blazor.ChartJS.Common.Handlers
{
    /// <summary>
    /// Wraps a C#-delegate to make it callable by Javascript.
    /// </summary>
    /// <typeparam name="T">The type of the delegate you want to invoke from Javascript.</typeparam>
    public class DelegateHandler<T> : IMethodHandler<T>, IDisposable
        where T : Delegate
    {
        private static readonly ParameterInfo[] s_delegateParameters;
        private static readonly bool s_delegateHasReturnValue;
        private static readonly JsonSerializerSettings s_deserializeOptions = new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Ignore,
            ContractResolver = new DefaultContractResolver
            {
                NamingStrategy = new CamelCaseNamingStrategy(true, false)
            }
        };

        private readonly T _function;

        /// <summary>
        /// The name of the method which should be called from Javascript. In this case it's always the name of the <see cref="Invoke(System.Text.Json.JsonElement[])"/>-method.
        /// </summary>
        public string MethodName => nameof(Invoke);

        /// <summary>
        /// Keeps a reference to this object which is used to invoke the stored delegate from Javascript.
        /// </summary>
        // This property only has to be serialized by the JSRuntime where a custom converter will be used.
        [Newtonsoft.Json.JsonIgnore]
        public DotNetObjectReference<DelegateHandler<T>> HandlerReference { get; }

        /// <summary>
        /// Gets a value indicating whether or not this delegate will return a value.
        /// </summary>
        public bool ReturnsValue => s_delegateHasReturnValue;

        static DelegateHandler()
        {
            // https://stackoverflow.com/a/429564/10883465
            MethodInfo internalDelegateMethod = typeof(T).GetMethod("Invoke");

            s_delegateParameters = internalDelegateMethod.GetParameters();
            s_delegateHasReturnValue = internalDelegateMethod.ReturnType != typeof(void);
        }

        /// <summary>
        /// Creates a new instance of <see cref="DelegateHandler{T}"/>.
        /// </summary>
        /// <param name="function">The delegate you want to invoke from Javascript.</param>
        public DelegateHandler(T function)
        {
            _function = function ?? throw new ArgumentNullException(nameof(function));
            HandlerReference = DotNetObjectReference.Create(this);
        }

        /// <summary>
        /// Invokes the delegate dynamically. This method should only be called from Javascript.
        /// </summary>
        /// <param name="jsonArgs">All the arguments for the method as array. These are not deserialized yet because the types are unknown.</param>
        [JSInvokable]
        public virtual object Invoke(params System.Text.Json.JsonElement[] jsonArgs)
        {
            if (s_delegateParameters.Length != jsonArgs.Length)
                throw new ArgumentException($"The function expects {s_delegateParameters.Length} arguments but found {jsonArgs.Length}.");

            if (s_delegateParameters.Length == 0)
                return _function.DynamicInvoke(null);

            object[] invokationArgs = new object[s_delegateParameters.Length];
            for (int i = 0; i < s_delegateParameters.Length; i++)
            {
                if (s_delegateParameters[i].ParameterType == typeof(object) ||
                    s_delegateParameters[i].ParameterType == typeof(System.Text.Json.JsonElement))
                {
                    invokationArgs[i] = jsonArgs[i];
                }
                else
                {
#if DEBUG
                    Console.WriteLine($"Deserializing: {jsonArgs[i].GetRawText()} to {s_delegateParameters[i].ParameterType.Name}");
#endif
                    invokationArgs[i] = JsonConvert.DeserializeObject(jsonArgs[i].GetRawText(), s_delegateParameters[i].ParameterType, s_deserializeOptions);
                }
            }
            
            return _function.DynamicInvoke(invokationArgs);
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            HandlerReference.Dispose();
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// The <see cref="Dispose"/> method doesn't have any unmanaged resources to free BUT once this object is finalized
        /// we need to prevent any further use of the <see cref="DotNetObjectReference"/> to this object. Since the <see cref="HandlerReference"/>
        /// will only be disposed if this <see cref="DelegateHandler{T}"/> instance is disposed or when <c>dispose</c> is called from Javascript
        /// (which shouldn't happen) we HAVE to dispose the reference when this instance is finalized.
        /// </summary>
        ~DelegateHandler()
        {
            Dispose();
        }

        /// <summary>
        /// Converts a delegate of type <typeparamref name="T"/> to a <see cref="DelegateHandler{T}"/> implicitly.
        /// </summary>
        /// <param name="function"></param>
        public static implicit operator DelegateHandler<T>(T function) => new DelegateHandler<T>(function);
    }
}