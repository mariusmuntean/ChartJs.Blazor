# ChartJs interop with Blazor
This is a Blazor Component that wraps [ChartJS](https://github.com/chartjs/Chart.js).
You can use the library in both client- and server-side projects.

## Introduction

This library is a modification of [this awesome library](https://github.com/mariusmuntean/ChartJs.Blazor). 
I intend to extend the functionality (mainly of the LineChart), fix issues and add more options from Chart.js (completeness).  

I fully intend giving all of this back to the community so that the original repository also gets all of these changes. Sadly because it's not a simple fork I don't know how to do that directly (let me know if you can help me with that :).

## Changelog

### Latest changes
**0.10.2:**
    
* Update ReadMe
* Clean and update .csproj file
* Create nuget package
* Update XML-docs handling

The full changelog can be found [here](https://github.com/Joelius300/ChartJSBlazor/blob/master/CHANGELOG.md).

## Please keep in mind that this is still a preview. Expect breaking changes during the next releases. I'm using this opportunity to learn Blazor.

## Prerequisites

Don't know what Blazor is? Read [here](https://dotnet.microsoft.com/apps/aspnet/web-apps/client).

The prerequisites are:

1. Visual Studio 2019 preview 2
2. .Net core 3 preview7


## Installation

There's a NuGet package: https://www.nuget.org/packages/ChartJs.Blazor.Fork/

Install from the command line:

```bash
dotnet add package ChartJs.Blazor.Fork
```

## Usage

For detailed instruction go to the [Wiki page](https://github.com/Joelius300/ChartJSBlazor/wiki). 

1. In you .razor file, add the following code:

```csharp
@using ChartJs.Blazor.Charts
@using ChartJs.Blazor.ChartJS.PieChart
@using ChartJs.Blazor.ChartJS.Common.Properties

<h1>Pie Chart</h1>

<ChartJsPieChart @ref="_pieChartJs" Config="@_config" Width="600" Height="300" />

@code {
private PieChartConfig _config;
private ChartJsPieChart _pieChartJs;

protected override void OnInit()
{
    _config = new PieChartConfig
    {
        CanvasId = "myFirstPieChart",
        Options = new PieChartOptions
        {
            Title = new OptionsTitle
            {
                Display = true,
                Text = "Sample chart from Blazor"
            },
            Responsive = true,
            Animation = new DoughnutAnimation
            {
                AnimateRotate = true,
                AnimateScale = true
            }
        }
    };

    _config.Data.Labels = new List<string> { "A", "B", "C", "D" };

    var pieSet = new PieChartDataset
    {
        BackgroundColor = new[] { "#ff6384", "#55ee84", "#4463ff", "#efefef" },
        Data = new List<int> { 4, 5, 6, 7 },                // this will be removed and shouldn't be possible
        Label = "Light Red",
        BorderWidth = 0,
        HoverBackgroundColor = new[] { "#f06384" },
        HoverBorderColor = new[] { "#f06384" },
        HoverBorderWidth = new[] { 1 },
        BorderColor = "#ffffff",
    };

    _config.Data.Datasets = new List<PieChartDataset>();    // this will be removed and shouldn't be possible
    _config.Data.Datasets.Add(pieSet);
}
}
```

2. In your `_Host.cshtml` file add this code to have `moment.js` with the locales:

```html
<script src="https://cdnjs.cloudflare.com/ajax/libs/moment.js/2.24.0/moment-with-locales.min.js"
        integrity="sha256-AdQN98MVZs44Eq2yTwtoKufhnU+uZ7v2kXnD5vqzZVo="
        crossorigin="anonymous">
</script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/Chart.js/2.8.0/Chart.min.js"></script>
<script src="~/ChartJs.Blazor/ChartJsInterop.js" type="text/javascript" language="javascript"></script>
```

or this code if you want the bundled version of `Chart.Js`, but without the locales of `moment.js` (`moment.js` itself is then included in the bundle):

```html
<script src="https://cdnjs.cloudflare.com/ajax/libs/Chart.js/2.8.0/Chart.bundle.min.js"></script> <!--Contains moment.js for time axis-->
<script src="~/ChartJs.Blazor/ChartJsInterop.js" type="text/javascript" language="javascript"></script>
```

# Contributors
* [Joelius300](https://github.com/Joelius300)
* [SeppPenner](https://github.com/SeppPenner)
