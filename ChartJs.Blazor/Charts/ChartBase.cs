using ChartJs.Blazor.ChartJS;
using ChartJs.Blazor.ChartJS.Common;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;

namespace ChartJs.Blazor.Charts
{
    public abstract class ChartBase<TConfig> : ComponentBase where TConfig : ChartConfigBase
    {
        [Inject] protected IJSRuntime JsRuntime { get; set; }

        [Parameter] protected TConfig Config { get; set; }

        [Parameter] protected int Width { get; set; } = 400;

        [Parameter] protected int Height { get; set; } = 400;

        protected override void OnAfterRender()
        {
            try
            {
                base.OnAfterRender();
                JsRuntime.SetupChart(Config);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Some error in OnAfterRender: {e.Message}");
            } // https://github.com/aspnet/AspNetCore/issues/8327
        }

        public void Update()
        {
            JsRuntime.UpdateChart(Config);
        }
    }
}