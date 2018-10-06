using System.Collections.Generic;

namespace BlazorComponents.ChartJS
{
    public class ChartJsData
    {
        public List<string> Labels { get; set; } = new List<string>();
        //public List<ChartJsDataset> Datasets { get; set; }
        public List<ChartJsDataset> Datasets { get; set; }
    }
}
