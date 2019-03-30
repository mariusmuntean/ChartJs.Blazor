using Microsoft.JSInterop;
using System.Threading.Tasks;
using ChartJs.Blazor.ChartJS.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;

namespace ChartJs.Blazor.ChartJS
{
    public static class ChartJsInterop
    {
        public static Task<bool> SetupChart(this IJSRuntime jsRuntime, ChartConfigBase chartConfig)
        {
            try
            {
                return jsRuntime.InvokeAsync<bool>("ChartJSInterop.SetupChart", SerializeConfig(chartConfig));
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
                return jsRuntime.InvokeAsync<bool>("ChartJSInterop.UpdateChart", SerializeConfig(chartConfig));
            }
            catch (Exception exp)
            {

            }
            return Task.FromResult<bool>(false);
        }

        private static readonly JsonSerializerSettings JsonSettings = new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Ignore,
            //DefaultValueHandling = DefaultValueHandling.Ignore,
            ContractResolver = new DefaultContractResolver
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            }
        };

        private static string SerializeConfig(ChartConfigBase config)
        {
            var json = JsonConvert.SerializeObject(config, JsonSettings);
            return json;
        }
    }
}