using ChartJs.Blazor.ChartJS.Common.Enums;
using System;

namespace ChartJs.Blazor.ChartJS.Common
{
    /// <summary>
    /// Base class for chart-configs
    /// <para>Contains the most basic required information about a chart</para>
    /// </summary>
    public abstract class ConfigBase
    {
        /// <summary>
        /// Creates a new instance of <see cref="ConfigBase"/>
        /// </summary>
        /// <param name="chartType">The chartType this config is for</param>
        protected ConfigBase(ChartType chartType)
        {
            Type = chartType;
        }

        /// <summary>
        /// Defines what type of chart this config is for
        /// </summary>
        public ChartType Type { get; }

        /// <summary>
        /// The id for the html canvas element associated with this chart
        /// </summary>
        public string CanvasId { get; } = Guid.NewGuid().ToString();
    }

    /// <summary>
    /// Base class for chart-config which contains the options and the data sub-configs
    /// </summary>
    /// <typeparam name="TOptions">The type of the options-subconfig</typeparam>
    /// <typeparam name="TData">The type of the data-subconfig</typeparam>
    public abstract class ConfigBase<TOptions, TData> : ConfigBase
        where TOptions : BaseConfigOptions
        where TData : class, new()      // TODO: restrict to some interface
    {
        /// <summary>
        /// Creates a new instance of <see cref="ConfigBase"/>
        /// </summary>
        /// <param name="chartType">The chartType this config is for</param>
        protected ConfigBase(ChartType chartType) : base(chartType)
        {
            Data = new TData();
        }

        /// <summary>
        /// The options subconfig for this chart
        /// </summary>
        public TOptions Options { get; set; }

        /// <summary>
        /// The data subconfig for this chart
        /// </summary>
        public TData Data { get; }
    }
}