using ChartJs.Blazor.Common;
using ChartJs.Blazor.Interop;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;

namespace ChartJs.Blazor
{
    /// <summary>
    /// Represents a Chart.js chart.
    /// </summary>
    /// <typeparam name="TConfig">The type of config to pass to Chart.js.</typeparam>
    public partial class Chart<TConfig> where TConfig : ConfigBase
    {
        /// <summary>
        /// Gets the injected <see cref="IJSRuntime"/> for the current Blazor application.
        /// </summary>
        [Inject]
        protected IJSRuntime JsRuntime { get; set; }

        /// <summary>
        /// Gets or sets the configuration of the chart.
        /// </summary>
        [Parameter]
        public TConfig Config { get; set; }

        /// <summary>
        /// Gets or sets the width of the canvas HTML element.
        /// </summary>
        [Parameter]
        public int? Width { get; set; }

        /// <summary>
        /// Gets or sets the height of the canvas HTML element. Use <see langword="null"/> when using <see cref="BaseConfigOptions.AspectRatio"/>.
        /// </summary>
        [Parameter]
        public int? Height { get; set; }

        /// <inheritdoc />
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await JsRuntime.SetupChart(Config);
            }
            else
            {
                await JsRuntime.UpdateChart(Config);
            }
        }

        /// <summary>
        /// Updates the chart.
        /// <para>
        /// Call this method after you've updated the <see cref="Config"/>.
        /// </para>
        /// </summary>
        public Task Update()
        {
            return JsRuntime.UpdateChart(Config).AsTask();
        }
    }
}
