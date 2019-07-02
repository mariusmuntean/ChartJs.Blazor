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
    public static class ChartJsInterop
    {
        public static Task<bool> SetupChart(this IJSRuntime jsRuntime, ChartConfigBase chartConfig)
        {
            try
            {
                dynamic dynParam = StripNulls(chartConfig);
                Dictionary<string, object> param = ConvertDynamicToDictonary(dynParam);
                return jsRuntime.InvokeAsync<bool>("ChartJSInterop.SetupChart", param);
            }
            catch (Exception exp)
            {
                Console.WriteLine($"Error while setting up chart: {exp.Message}");
            }

            return Task.FromResult<bool>(false);
        }

        private static Dictionary<string, object> ConvertDynamicToDictonary(IDictionary<string, object> value)
        {
            return value.ToDictionary(
                p => p.Key,
                p =>
                {
                    // if it's another IDict (might be a ExpandoObject or could also be an actual Dict containing ExpandoObjects) just go through it recursively
                    if (p.Value is IDictionary<string, object> dict)
                    {
                        return ConvertDynamicToDictonary(dict);
                    }

                    // if it's an IEnumerable, it might have ExpandoObjects inside, so check for that
                    if (p.Value is IEnumerable<object> list)
                    {
                        // take all ExpandoObjects and go through them recursively
                        return list
                            .Where(o => o is ExpandoObject)
                            .Select(o => ConvertDynamicToDictonary((ExpandoObject)o));
                    }

                    // neither an IDict nor an IEnumerable -> it's probably fine to just return the value it has
                    return p.Value;
                } 
            );
        }

        public static Task<bool> UpdateChart(this IJSRuntime jsRuntime, ChartConfigBase chartConfig)
        {
            try
            {
                dynamic dynParam = StripNulls(chartConfig);
                Dictionary<string, object> param = ConvertDynamicToDictonary(dynParam);
                return jsRuntime.InvokeAsync<bool>("ChartJSInterop.UpdateChart", param);
            }
            catch (Exception exp)
            {
                Console.WriteLine($"Error while updating chart: {exp.Message}");
            }

            return Task.FromResult<bool>(false);
        }

        /// <summary>
        /// Returns an object that is equivalent to the given parameter but without any null member AND it preserves DotNetInstanceClickHandler/DotNetInstanceHoverHandler members intact
        ///
        /// <para>Preserving DotNetInstanceClick/HoverHandler members is important because they contain DotNetObjectRefs to the instance whose method should be invoked on click/hover</para>
        ///
        /// <para>This whole method is hacky af but necessary. Stripping null members is only needed because the default config for the Line charts on the Blazor side is somehow messed up. If this were not the case no null member stripping were necessary and hence, the recovery of the DotNetObjectRef members would also not be needed. Nevertheless, The Show must go on!</para>
        /// </summary>
        /// <param name="chartConfig"></param>
        /// <returns></returns>
        private static ExpandoObject StripNulls(ChartConfigBase chartConfig)
        {
            // Serializing with the custom serializer settings remove null members
            var cleanChartConfigStr = JsonConvert.SerializeObject(chartConfig, JsonSerializerSettings);

            // Get back an ExpandoObject dynamic with the clean config - having an ExpandoObject allows us to add/replace members regardless of type
            dynamic clearConfigExpando = JsonConvert.DeserializeObject<ExpandoObject>(cleanChartConfigStr, new ExpandoObjectConverter());

            // Restore any .net refs that need to be passed intact
            var dynamicChartConfig = (dynamic) chartConfig;
            if (dynamicChartConfig?.Options?.Legend?.OnClick != null
                && dynamicChartConfig?.Options?.Legend?.OnClick is DotNetInstanceClickHandler)
            {
                clearConfigExpando.options = clearConfigExpando.options ?? new { };
                clearConfigExpando.options.legend = clearConfigExpando.options.legend ?? new { };
                clearConfigExpando.options.legend.onClick = dynamicChartConfig.Options.Legend.OnClick;
            }

            if (dynamicChartConfig?.Options?.Legend?.OnHover != null
                && dynamicChartConfig?.Options?.Legend?.OnHover is DotNetInstanceHoverHandler)
            {
                clearConfigExpando.options = clearConfigExpando.options ?? new { };
                clearConfigExpando.options.legend = clearConfigExpando.options.legend ?? new { };
                clearConfigExpando.options.legend.onHover = dynamicChartConfig.Options.Legend.OnHover;
            }

            return clearConfigExpando;
        }

        private static readonly JsonSerializerSettings JsonSerializerSettings = new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Ignore,
            ContractResolver = new DefaultContractResolver
            {
                NamingStrategy = new CamelCaseNamingStrategy(true, false)
            }
        };
    }
}