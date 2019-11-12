using ChartJs.Blazor.ChartJS.Common;
using Microsoft.JSInterop;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using ChartJs.Blazor.ChartJS.Common.Handlers.OnClickHandler;
using ChartJs.Blazor.ChartJS.Common.Handlers.OnHover;

namespace ChartJs.Blazor.ChartJS
{
    /// <summary>
    /// Interop layer with the included/referenced ChartJs
    /// </summary>
    public static class ChartJsInterop
    {
        private const string ChartJsInteropName = "ChartJsInterop";

        /// <summary>
        /// Set up a new chart. Call only once.
        /// </summary>
        /// <param name="jsRuntime"></param>
        /// <param name="chartConfig"></param>
        /// <returns></returns>
        public static ValueTask<bool> SetupChart(this IJSRuntime jsRuntime, ConfigBase chartConfig)
        {
            try
            {
                dynamic dynParam = StripNulls(chartConfig);
                Dictionary<string, object> param = ConvertExpandoObjectToDictionary(dynParam);
                return jsRuntime.InvokeAsync<bool>($"{ChartJsInteropName}.SetupChart", param);
            }
            catch (Exception exp)
            {
                Console.WriteLine($"Error while setting up chart: {exp.Message}");
            }

            return new ValueTask<bool>(false);
        }

        /// <summary>
        /// This method is specifically used to convert an <see cref="ExpandoObject"/> with a Tree structure to a <see cref="Dictionary{string, object}"/>.
        /// </summary>
        /// <param name="expando">The <see cref="ExpandoObject"/> to convert</param>
        /// <returns>The fully converted <see cref="ExpandoObject"/></returns>
        private static Dictionary<string, object> ConvertExpandoObjectToDictionary(ExpandoObject expando) => RecursivelyConvertIDictToDict(expando);

        /// <summary>
        /// This method takes an <see cref="IDictionary{string, object}"/> and recursively converts it to a <see cref="Dictionary{string, object}"/>.
        /// The idea is that every <see cref="IDictionary{string, object}"/> in the tree will be of type <see cref="Dictionary{string, object}"/> instead of some other implementation like <see cref="ExpandoObject"/>.
        /// </summary>
        /// <param name="value">The <see cref="IDictionary{string, object}"/> to convert</param>
        /// <returns>The fully converted <see cref="Dictionary{string, object}"/></returns>
        private static Dictionary<string, object> RecursivelyConvertIDictToDict(IDictionary<string, object> value) =>
            value.ToDictionary(
                keySelector => keySelector.Key,
                elementSelector =>
                {
                    // if it's another IDict just go through it recursively
                    if (elementSelector.Value is IDictionary<string, object> dict)
                    {
                        return RecursivelyConvertIDictToDict(dict);
                    }

                    // if it's an IEnumerable check each element
                    if (elementSelector.Value is IEnumerable<object> list)
                    {
                        // go through all objects in the list
                        // if the object is an IDict -> convert it
                        // if not keep it as is
                        return list
                            .Select(o => o is IDictionary<string, object>
                                ? RecursivelyConvertIDictToDict((IDictionary<string, object>) o)
                                : o
                            );
                    }

                    // neither an IDict nor an IEnumerable -> it's fine to just return the value it has
                    return elementSelector.Value;
                }
            );

        /// <summary>
        /// Update an existing chart. Make sure that the <see cref="ConfigBase.CanvasId"/> matches that on an existing chart.
        /// </summary>
        /// <param name="jsRuntime"></param>
        /// <param name="chartConfig"></param>
        /// <returns></returns>
        public static ValueTask<bool> UpdateChart(this IJSRuntime jsRuntime, ConfigBase chartConfig)
        {
            try
            {
                dynamic dynParam = StripNulls(chartConfig);
                Dictionary<string, object> param = ConvertExpandoObjectToDictionary(dynParam);
                return jsRuntime.InvokeAsync<bool>($"{ChartJsInteropName}.UpdateChart", param);
            }
            catch (Exception exp)
            {
                Console.WriteLine($"Error while updating chart: {exp.Message}");
            }

            return new ValueTask<bool>(false);
        }

        /// <summary>
        /// Returns an object that is equivalent to the given parameter but without any null member AND it preserves DotNetInstanceClickHandler/DotNetInstanceHoverHandler members intact
        /// <para>Preserving DotNetInstanceClick/HoverHandler members is important because they contain DotNetObjectRefs to the instance whose method should be invoked on click/hover</para>
        /// <para>This whole method is hacky af but necessary. Stripping null members is only needed because the default config for the Line charts on the Blazor side is somehow messed up. If this were not the case no null member stripping were necessary and hence, the recovery of the DotNetObjectRef members would also not be needed. Nevertheless, The Show must go on!</para>
        /// </summary>
        /// <param name="chartConfig"></param>
        /// <returns></returns>
        private static ExpandoObject StripNulls(ConfigBase chartConfig)
        {
            // Serializing with the custom serializer settings remove null members
            var cleanChartConfigStr = JsonConvert.SerializeObject(chartConfig, JsonSerializerSettings);

            // Get back an ExpandoObject dynamic with the clean config - having an ExpandoObject allows us to add/replace members regardless of type
            dynamic clearConfigExpando = JsonConvert.DeserializeObject<ExpandoObject>(cleanChartConfigStr, new ExpandoObjectConverter());

            // Restore any .net refs that need to be passed intact
            var dynamicChartConfig = (dynamic) chartConfig;
            if (dynamicChartConfig?.Options?.Legend?.OnClick != null
                && dynamicChartConfig?.Options?.Legend?.OnClick is IClickHandler)
            {
                clearConfigExpando.options = clearConfigExpando.options ?? new { };
                clearConfigExpando.options.legend = clearConfigExpando.options.legend ?? new { };
                clearConfigExpando.options.legend.onClick = dynamicChartConfig.Options.Legend.OnClick;
            }

            if (dynamicChartConfig?.Options?.Legend?.OnHover != null
                && dynamicChartConfig?.Options?.Legend?.OnHover is IHoverHandler)
            {
                clearConfigExpando.options = clearConfigExpando.options ?? new { };
                clearConfigExpando.options.legend = clearConfigExpando.options.legend ?? new { };
                clearConfigExpando.options.legend.onHover = dynamicChartConfig.Options.Legend.OnHover;
            }

            if (dynamicChartConfig?.Options?.OnClick != null
                && dynamicChartConfig?.Options?.OnClick is IClickHandler)
            {
                clearConfigExpando.options = clearConfigExpando.options ?? new { };
                clearConfigExpando.options.onClick = dynamicChartConfig.Options.OnClick;
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