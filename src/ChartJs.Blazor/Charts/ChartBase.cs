using ChartJs.Blazor.ChartJS;
using ChartJs.Blazor.ChartJS.Common;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace ChartJs.Blazor.Charts
{
    public abstract class ChartBase<TConfig> : ComponentBase where TConfig : ChartConfigBase
    {
        [Inject] protected IJSRuntime JsRuntime { get; set; }
        
        [Parameter] public TConfig Config { get; set; }
        
        [Parameter] public int Width { get; set; } = 400;

        [Parameter] public int Height { get; set; } = 400;
        
        protected override void OnAfterRender()
        {
            try
            {
                base.OnAfterRender();
                JsRuntime.InitializeChart(Config);
            }
            catch { } // https://github.com/aspnet/AspNetCore/issues/8327
        }

        public void Reload()
        {
            JsRuntime.ReloadChart(Config);
        }


        public void Update()
        {
            JsRuntime.UpdateChart(Config);
        }
    }
}