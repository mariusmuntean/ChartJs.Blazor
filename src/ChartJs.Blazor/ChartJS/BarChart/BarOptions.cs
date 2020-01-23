using ChartJs.Blazor.Charts;
using ChartJs.Blazor.ChartJS.Common;
using ChartJs.Blazor.ChartJS.Common.Properties;

namespace ChartJs.Blazor.ChartJS.BarChart
{
	/// <summary>
	/// The options-subconfig of a <see cref="BarConfig"/>.
	/// </summary>
	public class BarOptions : BaseConfigOptions
	{
		/// <summary>
		/// General animation time
		/// </summary>
		public Animation Animation { get; set; }

		/// <summary>
		/// Gets or sets the scales for the <see cref="ChartJsBarChart"/>.
		/// </summary>
		public BarScales Scales { get; set; }
	}
}