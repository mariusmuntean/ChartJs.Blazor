using Microsoft.JSInterop;
using System.Threading.Tasks;
using ChartJs.Blazor.ChartJS.Common;
using System;

namespace ChartJs.Blazor.ChartJS
{
    public static class ChartJsInterop
    {
        public static Task<bool> SetupChart(this IJSRuntime jsRuntime, ChartConfigBase chartConfig)
        {
            try
            {
                return jsRuntime.InvokeAsync<bool>("ChartJSInterop.SetupChart", chartConfig);
            }
            catch (Exception exp)
            {

            }
            return Task.FromResult<bool>(false);
        }

        public static Task<bool> UpdateChart(this IJSRuntime jsRuntime, ChartConfigBase chartConfig)
        {
            try
            {
                return jsRuntime.InvokeAsync<bool>("ChartJSInterop.UpdateChart", chartConfig);
            }
            catch (Exception exp)
            {

            }
            return Task.FromResult<bool>(false);
        }
    }
}