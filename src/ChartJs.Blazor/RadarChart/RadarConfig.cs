using ChartJs.Blazor.Common;
using ChartJs.Blazor.Common.Enums;

namespace ChartJs.Blazor.RadarChart
{
    /// <summary>
    /// Represents the config for a radar chart.
    /// </summary>
    public class RadarConfig : ConfigBase<RadarOptions>
    {
        /// <summary>
        /// Creates a new instance of <see cref="RadarConfig"/>.
        /// </summary>
        public RadarConfig() : base(ChartType.Radar) { }
    }
}
