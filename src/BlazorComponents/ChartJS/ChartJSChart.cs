using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace BlazorComponents.ChartJS
{
    public class ChartJSChart
    {
        public string ChartType { get; set; }
        public ChartJsData Data { get; set; }
        public ChartJsOptions Options { get; set; }
        public string CanvasId { get; set; }
    }

    public class ChartJsData
    {
        public List<string> Labels { get; set; } = new List<string>();
        public List<ChartJsDataset> Datasets { get; set; } = new List<ChartJsDataset>();
    }

    public class ChartJsDataset
    {
        public string Label { get; set; }
        public List<int> Data { get; set; } = new List<int>();
        public List<Color> BackgroundColor { get; set; } = new List<Color>();
        public List<Color> BorderColor { get; set; } = new List<Color>();
        public int BorderWidth { get; set; }
    }

    public class ChartJsOptions
    {
        public string Text { get; set; }
        public bool Display { get; set; } = false;
        public List<Color> BackgroundColor { get; set; } = new List<Color>();
        public List<Color> BorderColor { get; set; } = new List<Color>();
        public int BorderWidth { get; set; }
    }
}
