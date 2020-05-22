using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace ChartJs.Blazor.Interop
{
    /// <summary>
    /// Interop layer with the included/referenced moment.js
    /// </summary>
    public static class MomentJsInterop
    {
        private const string MomentJsInteropName = "MomentJsInterop";

        /// <summary>
        /// Gets the available locales
        /// </summary>
        /// <param name="jsRuntime"></param>
        /// <returns></returns>
        public static ValueTask<string[]> GetAvailableLocales(this IJSRuntime jsRuntime)
        {
            return jsRuntime.InvokeAsync<string[]>($"{MomentJsInteropName}.getAvailableMomentLocales");
        }

        /// <summary>
        /// Changes the current locale to the provided one
        /// </summary>
        /// <param name="jsRuntime"></param>
        /// <param name="locale"></param>
        /// <returns></returns>
        public static ValueTask<bool> ChangeLocale(this IJSRuntime jsRuntime, string locale)
        {
            try
            {
                return jsRuntime.InvokeAsync<bool>($"{MomentJsInteropName}.changeLocale", locale);
            }
            catch
            {
                return new ValueTask<bool>(false);
            }
        }
    }
}