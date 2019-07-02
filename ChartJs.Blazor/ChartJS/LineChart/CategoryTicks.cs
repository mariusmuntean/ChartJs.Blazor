using ChartJs.Blazor.ChartJS.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChartJs.Blazor.ChartJS.LineChart
{
    public class CategoryTicks : CartesianTicks
    {
        /// <summary>
        /// An array of labels to display.
        /// </summary>
        public List<string> Labels { get; set; }

        /// <summary>
        /// The minimum item to display. The item has to be present in <see cref="Labels"/>.
        /// <para>Read more https://www.chartjs.org/docs/latest/axes/cartesian/category.html#min-max-configuration </para>
        /// </summary>
        public string Min { get; set; }

        /// <summary>
        /// The maximum item to display. The item has to be present in <see cref="Labels"/>.
        /// <para>Read more https://www.chartjs.org/docs/latest/axes/cartesian/category.html#min-max-configuration </para>
        /// </summary>
        public string Max { get; set; }
    }
}
