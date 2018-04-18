using System.Collections.Generic;

namespace BlazorComponents.ChartJS
{
    public class ChartJsData<T> where T : ChartJsDataset
    {
        public List<string> Labels { get; set; } = new List<string>();
        public List<T> Datasets { get; set; }
    }
}
