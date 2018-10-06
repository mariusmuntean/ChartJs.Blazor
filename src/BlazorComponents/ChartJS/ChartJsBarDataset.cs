namespace BlazorComponents.ChartJS
{
    public class ChartJsBarDataset : ChartJsDataset
    {
        public int BorderWidth { get; set; } = 1;
        public override string Type { get; } = ChartTypes.BAR.ToString();
    }
}
