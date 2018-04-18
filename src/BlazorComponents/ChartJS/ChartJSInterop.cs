using Microsoft.AspNetCore.Blazor.Browser.Interop;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorComponents.ChartJS
{
    public class ChartJSInterop
    {
        public static bool InitializeLineChart(ChartJSChart<ChartJsLineDataset> lineChart)
        {
            return RegisteredFunction.Invoke<bool>("BlazorComponents.ChartJSInterop.InitializeLineChart", new[] { lineChart });
        }

        public static bool InitializeBarChart(ChartJSChart<ChartJsBarDataset> barChart)
        {
            return RegisteredFunction.Invoke<bool>("BlazorComponents.ChartJSInterop.InitializeBarChart", new[] { barChart });
        }

        public static bool UpdateLineChart(ChartJSChart<ChartJsLineDataset> lineChart)
        {
            return RegisteredFunction.Invoke<bool>("BlazorComponents.ChartJSInterop.UpdateLineChart", new[] { lineChart });
        }
    }
}
