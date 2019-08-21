namespace ChartJs.Blazor.ChartJS.Common.Properties
{
    /// <summary>
    /// The animation-subconfig of the options for a radial chart.
    /// </summary>
    public class ArcAnimation
    {
        /// <summary>
        /// If true, the chart will animate in with a rotation animation.
        /// </summary>
        public bool AnimateRotate { get; set; } = true;

        /// <summary>
        /// If true, will animate scaling the chart from the center outwards.
        /// </summary>
        public bool AnimateScale { get; set; } = false;
    }
}