namespace ChartJs.Blazor.ChartJS.Common.Axes.Ticks
{
    /// <summary>
    /// As per documentation here https://www.chartjs.org/docs/latest/axes/cartesian/#tick-configuration
    /// </summary>
    public abstract class CartesianTicks
    {
        /// <summary>
        /// If true, automatically calculates how many labels can be shown and hides labels accordingly. 
        /// Labels will be rotated up to maxRotation before skipping any. Turn autoSkip off to show all labels no matter what.
        /// </summary>
        public bool AutoSkip { get; set; } = true;

        /// <summary>
        /// Padding between the ticks on the horizontal axis when <see cref="AutoSkip"></see> is enabled.
        /// </summary>
        public int AutoSkipPadding { get; set; }

        /// <summary>
        /// Distance in pixels to offset the label from the centre point of the tick (in the x direction for the x axis, and the y direction for the y axis).
        /// <para>Note: this can cause labels at the edges to be cropped by the edge of the canvas.</para>
        /// </summary>
        public int LabelOffset { get; set; }

        /// <summary>
        /// Maximum rotation for tick labels when rotating to condense labels. 
        /// <para>Note: Rotation doesn't occur until necessary.</para>
        /// <para>Note: Only applicable to horizontal scales.</para>
        /// </summary>
        public int? MaxRotation { get; set; }

        /// <summary>
        /// Minimum rotation for tick labels. 
        /// <para>Note: Only applicable to horizontal scales.</para>
        /// </summary>
        public int? MinRotation { get; set; }

        /// <summary>
        /// Flips tick labels around axis, displaying the labels inside the chart instead of outside.
        /// <para>Note: Only applicable to vertical scales.</para>
        /// </summary>
        public bool? Mirror { get; set; }

        /// <summary>
        /// Padding between the tick label and the axis. When set on a vertical axis, this applies in the horizontal (X) direction. 
        /// When set on a horizontal axis, this applies in the vertical (Y) direction.
        /// </summary>
        public int Padding { get; set; }
    }
}