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
using ChartJs.Blazor.ChartJS.Common.Handlers;

namespace ChartJs.Blazor.ChartJS
{
    /// <summary>
    /// Interop layer from C# to Javascript.
    /// </summary>
    public static class ChartJsInterop
    {
        private const string ChartJsInteropName = "ChartJsInterop";

        /// <summary>
        /// Set up a new chart. Call only once.
        /// </summary>
        /// <param name="jsRuntime"></param>
        /// <param name="chartConfig">The config for the new chart.</param>
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
        /// This method is specifically used to convert an <see cref="ExpandoObject"/> with a Tree structure to a <c>Dictionary&lt;string, object&gt;</c>.
        /// </summary>
        /// <param name="expando">The <see cref="ExpandoObject"/> to convert.</param>
        /// <returns>The fully converted <see cref="ExpandoObject"/>.</returns>
        private static Dictionary<string, object> ConvertExpandoObjectToDictionary(ExpandoObject expando) => RecursivelyConvertIDictToDict(expando);

        /// <summary>
        /// This method takes an <c>IDictionary&lt;string, object&gt;</c> and recursively converts it to a <c>Dictionary&lt;string, object&gt;</c>.
        /// The idea is that every <c>IDictionary&lt;string, object&gt;</c> in the tree will be of type <c>Dictionary&lt;string, object&gt;</c> instead of some other implementation like <see cref="ExpandoObject"/>.
        /// </summary>
        /// <param name="value">The <c>IDictionary&lt;string, object&gt;</c> to convert</param>
        /// <returns>The fully converted <c>Dictionary&lt;string, object&gt;</c></returns>
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
        /// Update an existing chart. Make sure that the Chart with this <see cref="ConfigBase.CanvasId"/> already exists.
        /// </summary>
        /// <param name="jsRuntime"></param>
        /// <param name="chartConfig">The updated config of the chart you want to update.</param>
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
        /// Returns an object that is equivalent to the given parameter but without any null members AND it preserves IMethodHandlers intact.
        /// <para>Preserving IMethodHandler members is important because they contain <see cref="DotNetObjectReference{T}"/> to the instance whose method should be invoked on click/hover/whatever.</para>
        /// <para>This whole method is hacky af but necessary. Stripping null members is only needed because chartJs doesn't handle null values and undefined values the same and with JSRuntime null gets serialized to null.
        /// If this were not the case, no null member stripping were necessary and hence, the recovery of the <see cref="DotNetObjectReference{T}"/> members would also not be needed. Nevertheless, The Show must go on!</para>
        /// </summary>
        /// <param name="chartConfig">The config you want to strip of null members.</param>
        /// <returns></returns>
        private static ExpandoObject StripNulls(ConfigBase chartConfig)
        {
            // Serializing with the custom serializer settings remove null members
            var cleanChartConfigStr = JsonConvert.SerializeObject(chartConfig, JsonSerializerSettings);

            // Get back an ExpandoObject dynamic with the clean config - having an ExpandoObject allows us to add/replace members regardless of type
            dynamic dynamicCleanChartConfig = JsonConvert.DeserializeObject<ExpandoObject>(cleanChartConfigStr, new ExpandoObjectConverter());

            // Restore any .net refs that need to be passed intact
            // TODO Find a way to do this dynamically. Maybe with attributes or something like that?
            var dynamicChartConfig = (dynamic) chartConfig;
            if (dynamicChartConfig?.Options?.OnClick is IMethodHandler chartOnClick && chartOnClick != null)
            {
                dynamicCleanChartConfig.options = dynamicCleanChartConfig.options ?? new { };

                dynamicCleanChartConfig.options.onClick = chartOnClick;
            }

            if (dynamicChartConfig?.Options?.OnHover is IMethodHandler chartOnHover && chartOnHover != null)
            {
                dynamicCleanChartConfig.options = dynamicCleanChartConfig.options ?? new { };

                dynamicCleanChartConfig.options.onHover = chartOnHover;
            }

            if (dynamicChartConfig?.Options?.Legend?.OnClick is IMethodHandler legendOnClick && legendOnClick != null)
            {
                dynamicCleanChartConfig.options = dynamicCleanChartConfig.options ?? new { };
                dynamicCleanChartConfig.options.legend = dynamicCleanChartConfig.options.legend ?? new { };

                dynamicCleanChartConfig.options.legend.onClick = legendOnClick;
            }

            if (dynamicChartConfig?.Options?.Legend?.OnHover is IMethodHandler legendOnHover && legendOnHover != null)
            {
                dynamicCleanChartConfig.options = dynamicCleanChartConfig.options ?? new { };
                dynamicCleanChartConfig.options.legend = dynamicCleanChartConfig.options.legend ?? new { };

                dynamicCleanChartConfig.options.legend.onHover = legendOnHover;
            }

            if (dynamicChartConfig?.Options?.Legend?.Labels?.GenerateLabels is IMethodHandler generateLabels && generateLabels != null)
            {
                dynamicCleanChartConfig.options = dynamicCleanChartConfig.options ?? new { };
                dynamicCleanChartConfig.options.legend = dynamicCleanChartConfig.options.legend ?? new { };
                dynamicCleanChartConfig.options.legend.labels = dynamicCleanChartConfig.options.legend.labels ?? new { };

                dynamicCleanChartConfig.options.legend.labels.generateLabels = generateLabels;
            }

            if (dynamicChartConfig?.Options?.Legend?.Labels?.Filter is IMethodHandler filter && filter != null)
            {
                dynamicCleanChartConfig.options = dynamicCleanChartConfig.options ?? new { };
                dynamicCleanChartConfig.options.legend = dynamicCleanChartConfig.options.legend ?? new { };
                dynamicCleanChartConfig.options.legend.labels = dynamicCleanChartConfig.options.legend.labels ?? new { };

                dynamicCleanChartConfig.options.legend.labels.filter = filter;
            }

            return dynamicCleanChartConfig;
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