using ChartJs.Blazor.ChartJS.Common;
using ChartJs.Blazor.ChartJS.Common.Enums;

namespace ChartJs.Blazor.ChartJS.RadarChart
{
    /// <summary>
    /// Represents the config for a radar chart.
    /// </summary>
    public class RadarConfig : ConfigBase<RadarOptions, RadarData>
    {
        /// <summary>
        /// Creates a new instance of <see cref="RadarConfig"/>.
        /// </summary>
        public RadarConfig() : base(ChartType.Radar) { }
    }
}
