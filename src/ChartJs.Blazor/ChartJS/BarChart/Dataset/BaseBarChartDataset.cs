using System;
using System.Collections.Generic;
using ChartJs.Blazor.ChartJS.MixedChart;

namespace ChartJs.Blazor.ChartJS.BarChart.Dataset
{
    public class BaseBarChartDataset : IMixableDataset
    {
        /// <summary>
        /// The label for the dataset which appears in the legend and tooltips.
        /// </summary>
        public string Label { get; set; } = "";

        /// <summary>
        /// The ID of the x axis to plot this dataset on. If not specified, this defaults to the ID of the first found x axis
        /// </summary>
        public string xAxisID { get; set; }

        /// <summary>
        /// The ID of the y axis to plot this dataset on. If not specified, this defaults to the ID of the first found y axis
        /// </summary>
        public string yAxisID { get; set; }

        public string Type { get; } = ChartTypes.BAR.ToString();

        /// <summary>
        /// Which edge to skip drawing the border for. Options are:
        ///
        /// 'bottom'
        /// 'left'
        /// 'top'
        /// 'right'
        /// </summary>
        public string BorderSkipped { get; set; }

        // ToDo: introduce a data type
        public List<object> Data { get; set; }

        /// <summary>
        /// The ID of the group to which this dataset belongs to (when stacked, each group will be a separate stack)
        ///
        /// <para>
        /// Specific for stacked bar charts
        /// </para>
        /// </summary>
        public string Stack { get; set; } = Guid.NewGuid().ToString();
    }
}