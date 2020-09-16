using System;
using System.Collections.Generic;
using System.Text;

namespace ChartJs.Blazor.Samples.Shared
{
    public class SampleCategory
    {
        public string Title { get; set; }
        public IList<Sample> Samples { get; } = new List<Sample>();
    }
}
