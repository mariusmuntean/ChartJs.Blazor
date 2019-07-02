using Microsoft.JSInterop;
using System.Threading.Tasks;
using ChartJs.Blazor.ChartJS.Common;
using System;
using System.Dynamic;
using ChartJs.Blazor.ChartJS.Common.Legends.OnClickHandler;
using ChartJs.Blazor.ChartJS.Common.Legends.OnHover;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace ChartJs.Blazor.ChartJS
{
    public static class MomentJsInterop
    {
        public static Task<string[]> GetAvailableLocales(this IJSRuntime jsRuntime)
        {
            return jsRuntime.InvokeAsync<string[]>("getAvailableMomentLocales");
        }

        public static Task<bool> ChangeLocale(this IJSRuntime jsRuntime, string locale)
        {
            try
            {
                return jsRuntime.InvokeAsync<bool>("changeLocale", locale);
            }
            catch
            {
                return Task.FromResult(false);
            }
        }
    }
}