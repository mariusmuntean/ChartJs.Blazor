using System.Collections.Generic;

namespace ChartJs.Blazor.ChartJS.Common.Axes.Ticks
{
    /// <summary>
    /// The ticks-subconfig of <see cref="CategoryAxis"/>.
    /// </summary>
    public class CategoryTicks : CartesianTicks
    {
        /// <summary>
        /// Gets or sets an array of labels to display.
        /// </summary>
        public List<string> Labels { get; set; }

        /// <summary>
        /// Gets or sets the minimum item to display. The item has to be present in <see cref="Labels"/>.
        /// <para>Read more https://www.chartjs.org/docs/latest/axes/cartesian/category.html#min-max-configuration </para>
        /// </summary>
        public string Min { get; set; }

        /// <summary>
        /// Gets or sets the maximum item to display. The item has to be present in <see cref="Labels"/>.
        /// <para>Read more https://www.chartjs.org/docs/latest/axes/cartesian/category.html#min-max-configuration </para>
        /// </summary>
        public string Max { get; set; }
    }
}
