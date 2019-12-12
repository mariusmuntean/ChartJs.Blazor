using ChartJs.Blazor.ChartJS;
using ChartJs.Blazor.ChartJS.Common;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;

namespace ChartJs.Blazor.Charts
{
    /// <summary>
    /// Base type for all charts
    /// </summary>
    /// <typeparam name="TConfig"></typeparam>
    public abstract class ChartBase<TConfig> : ComponentBase where TConfig : ConfigBase
    {
        [Inject] protected IJSRuntime JsRuntime { get; set; }

        /// <summary>
        /// The configuration of the chart to be drawn.
        /// </summary>
        [Parameter]
        public TConfig Config { get; set; }

        /// <summary>
        /// The width of the canvas HTML element used to draw the chart.
        /// </summary>
        [Parameter]
        public int Width { get; set; } = 400;

        /// <summary>
        /// The height of the canvas HTML element used to draw the chart.
        /// </summary>
        [Parameter]
        public int Height { get; set; } = 400;

        /// <inheritdoc />
        protected override Task OnAfterRenderAsync(bool firstRender)
        {
            try
            {
                return firstRender ? JsRuntime.SetupChart(Config).AsTask() : JsRuntime.UpdateChart(Config).AsTask();
            }
            catch (Exception e)
            {
                Console.Error.WriteLine($"Error while {(firstRender ? "setting up" : "updating")} the chart. Message: {e.StackTrace}");
                return Task.CompletedTask;
            } // https://github.com/aspnet/AspNetCore/issues/8327
        }

        /// <summary>
        /// Updates the chart.
        ///
        /// <para>Call this method after you've changed something in the chart#s configuration</para>
        /// </summary>
        /// <returns></returns>
        public Task Update()
        {
            return JsRuntime.UpdateChart(Config).AsTask();
        }
    }
}