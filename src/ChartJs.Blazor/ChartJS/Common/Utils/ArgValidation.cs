using System;
using System.Linq;
using System.Reflection;

namespace ChartJs.Blazor.ChartJS.Common.Utils
{
    /// <summary>
    /// Validates arguments
    /// </summary>
    public static class ArgValidation
    {
        /// <summary>
        /// Checks if the argument is null, or in case of strings, if it is empty or white space only.
        /// </summary>
        /// <param name="argName">The name or the argument to check</param>
        /// <param name="arg">The actual argument to check</param>
        /// <exception cref="ArgumentException">Thrown if the argument is an empty or whitespace-only string</exception>
        /// <exception cref="ArgumentNullException">Thrown if the argument is null</exception>
        public static void AssertNotNullOrEmpty(string argName, object arg)
        {
            if (arg == null)
            {
                throw new ArgumentNullException($"'{argName}' is null", argName);
            }

            if (arg is string strArg && string.IsNullOrWhiteSpace(strArg))
            {
                throw new ArgumentException($"'{argName}' is empty or just whitespace");
            }
        }

        public static void AssertHasCustomAttribute(MethodInfo methodInfo, Type attributeType)
        {
            var isJsInvokable = methodInfo
                .CustomAttributes.Any(data => data.AttributeType == attributeType);
            if (!isJsInvokable)
            {
                throw new ArgumentException($"The passed in method must have the '{attributeType.FullName}' attribute", nameof(methodInfo.Name));
            }
        }

        public static void AssertIsPublic(MethodInfo methodInfo)
        {
            if (!methodInfo.IsPublic)
            {
                throw new ArgumentException("The passed in method must be public", nameof(methodInfo.Name));
            }
        }

        public static void AssertIsStatic(MethodInfo methodInfo)
        {
            if (!methodInfo.IsStatic)
            {
                throw new ArgumentException("The passed in method must be static", nameof(methodInfo.Name));
            }
        }
    }
}