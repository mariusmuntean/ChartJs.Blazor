using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace ChartJs.Blazor.ChartJS
{
    public static class MomentJsInterop
    {
        public static ValueTask<string[]> GetAvailableLocales(this IJSRuntime jsRuntime)
        {
            return jsRuntime.InvokeAsync<string[]>("getAvailableMomentLocales");
        }

        public static ValueTask<bool> ChangeLocale(this IJSRuntime jsRuntime, string locale)
        {
            try
            {
                return jsRuntime.InvokeAsync<bool>("changeLocale", locale);
            }
            catch
            {
                return new ValueTask<bool>(false);
            }
        }
    }
}