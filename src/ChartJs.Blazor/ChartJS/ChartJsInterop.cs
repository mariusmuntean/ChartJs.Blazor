using Microsoft.JSInterop;
using System.Threading.Tasks;
using ChartJs.Blazor.ChartJS.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace ChartJs.Blazor.ChartJS
{
    public static class ChartJsInterop
    {
        public static Task<bool> InitializeChart(this IJSRuntime jsRuntime, ChartConfigBase chartConfig)
        {
            return jsRuntime.InvokeAsync<bool>("ChartJSInterop.InitializeChart", SerializeConfig(chartConfig));
        }

        public static Task<bool> UpdateChart(this IJSRuntime jsRuntime, ChartConfigBase chartConfig)
        {
            return jsRuntime.InvokeAsync<bool>("ChartJSInterop.UpdateChart", SerializeConfig(chartConfig));
        }

        public static Task<bool> ReloadChart(this IJSRuntime jsRuntime, ChartConfigBase chartConfig)
        {
            return jsRuntime.InvokeAsync<bool>("ChartJSInterop.ReloadChart", SerializeConfig(chartConfig));
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