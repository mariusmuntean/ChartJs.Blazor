using System.Collections.Generic;

namespace ChartJs.Blazor.ChartJS
{
    public class ChartJsData
    {
        public List<string> Labels { get; set; } = new List<string>();
        //public List<ChartJsDataset> Datasets { get; set; }
        public List<ChartJsDataset> Datasets { get; set; }
    }
}
