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
using ChartJs.Blazor.Util;

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
        /// Returns an object that is equivalent to the given parameter but without any null members AND it preserves <see cref="IMethodHandler"/>s intact.
        /// <para>Preserving <see cref="IMethodHandler"/> members is important because they might be <see cref="DelegateHandler{T}"/> instances which contain
        /// delegates that can't be (de)serialized.</para>
        /// <para>Stripping null members is only needed because chartJs doesn't handle null values and undefined values the same and with JSRuntime null gets
        /// serialized to null instead of undefined (not at all) and WE CAN'T CHANGE THAT (see https://github.com/aspnet/AspNetCore/issues/12685).
        /// If this were not the case, no null member stripping were necessary -> no json.net serialize-deserialize magic -> no loss of <see cref="DelegateHandler{T}"/>
        /// instances -> no recovery of those. Everything would be better with AspNetCore#12685 finally being implemented but to fully migrate to System.Text.Json
        /// we might also need corefx#38650 and corefx#39905.
        /// Nevertheless, The Show must go on!</para>
        /// </summary>
        /// <param name="chartConfig">The config you want to strip of null members.</param>
        /// <returns></returns>
        private static ExpandoObject StripNulls(ConfigBase chartConfig)
        {
            // Serializing with the custom serializer settings remove null members
            string cleanChartConfigStr = JsonConvert.SerializeObject(chartConfig, JsonSerializerSettings);

            // Get back an ExpandoObject dynamic with the clean config - having an ExpandoObject allows us to add/replace members regardless of type
            ExpandoObject cleanChartConfig = JsonConvert.DeserializeObject<ExpandoObject>(cleanChartConfigStr, new ExpandoObjectConverter());

            // Restore any .net refs that need to be passed intact
            // TODO Find a way to do this dynamically. Maybe with attributes or something like that?
            dynamic dynamicChartConfig = (dynamic)chartConfig;
            if (dynamicChartConfig?.Options?.OnClick is IMethodHandler chartOnClick && chartOnClick != null)
            {
                const string path = "options.onClick";
                cleanChartConfig.SetValue(path, chartOnClick);
            }

            if (dynamicChartConfig?.Options?.OnHover is IMethodHandler chartOnHover && chartOnHover != null)
            {
                const string path = "options.onHover";
                cleanChartConfig.SetValue(path, chartOnHover);
            }

            if (dynamicChartConfig?.Options?.Legend?.OnClick is IMethodHandler legendOnClick && legendOnClick != null)
            {
                const string path = "options.legend.onClick";
                cleanChartConfig.SetValue(path, legendOnClick);
            }

            if (dynamicChartConfig?.Options?.Legend?.OnHover is IMethodHandler legendOnHover && legendOnHover != null)
            {
                const string path = "options.legend.onHover";
                cleanChartConfig.SetValue(path, legendOnHover);
            }

            if (dynamicChartConfig?.Options?.Legend?.Labels?.GenerateLabels is IMethodHandler generateLabels && generateLabels != null)
            {
                const string path = "options.legend.labels.generateLabels";
                cleanChartConfig.SetValue(path, generateLabels);
            }

            if (dynamicChartConfig?.Options?.Legend?.Labels?.Filter is IMethodHandler filter && filter != null)
            {
                const string path = "options.legend.labels.filter";
                cleanChartConfig.SetValue(path, filter);
            }

            return cleanChartConfig;
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