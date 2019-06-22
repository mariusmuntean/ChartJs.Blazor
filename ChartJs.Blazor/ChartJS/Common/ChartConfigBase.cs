using ChartJs.Blazor.ChartJS.Common.Enums;
using Newtonsoft.Json;

namespace ChartJs.Blazor.ChartJS.Common
{
    public abstract class ChartConfigBase
    {
        protected ChartConfigBase(ChartTypes chartType)
        {
            ChartType = chartType;
            Type = chartType.ToString();
        }

        [JsonIgnore]
        public ChartTypes ChartType { get; }
        public string Type { get; }

        public string CanvasId { get; set; }        
    }
    
    public abstract class ChartConfigBase<TOptions, TData> : ChartConfigBase 
        where TOptions : BaseChartConfigOptions 
        where TData : class
    {
        protected ChartConfigBase(ChartTypes chartType) : base(chartType) { }

        public TOptions Options { get; set; }

        public TData Data { get; set; }
    }
}