namespace ChartJs.Blazor.ChartJS.Common.Properties
{
    public class DoughnutAnimation
    {
        /// <summary>
        /// If true, the chart will animate in with a rotation animation. This property is in the options.animation object.
        /// </summary>
        public bool AnimateRotate { get; set; } = true;

        /// <summary>
        /// If true, will animate scaling the chart from the center outwards.
        /// </summary>
        public bool AnimateScale { get; set; } = false;
    }
}