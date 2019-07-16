# ChartJs interop with Blazor
This is a Blazor Component that wraps [ChartJS](https://github.com/chartjs/Chart.js).
You can use the library in both client- and server-side projects.

## Introduction

This library is a modification of [this awesome library](https://github.com/mariusmuntean/ChartJs.Blazor). 
I intend to extend the functionality (mainly of the LineChart), fix issues and add more options from Chart.js (completeness).  

I fully intend giving all of this back to the community so that the original repository also gets all of these changes. Sadly because it's not a simple fork I don't know how to do that directly (let me know if you can help me with that :).

## Changelog
<details open="open">

<details><summary>0.1.0</summary>
* Initial release. 
</details>

</details>

## Please keep in mind that this is still a preview. Expect breaking changes during the next releases. I'm using this opportunity to learn Blazor.

## Prerequisites

Don't know what Blazor is? Read [here](https://github.com/aspnet/Blazor)

Prerequisites.

1. Visual Studio 15.8 or later
2. DotNetCore 2.1.402 or later


## Installation

There's a NuGet package: ~~https://www.nuget.org/packages/ChartJSBlazor~~ TODO: It's not yet there, check https://github.com/Joelius300/ChartJSBlazor/issues/4!!

Install from the command line:

```
Install-Package ChartJSBlazor
```
or 
```
dotnet add package ChartJSBlazor
```
**Note:** For server-side projects make sure to add the following line to the `Configure(...)` method of your `Startup.cs` file
```csharp
ChartJsBlazor.AddStaticResourcesToWebRootPath(env.WebRootPath);
```
Then reference the ChartJsInterop.js file from your index.(cs)html like so
```HTML
<script src="~/ChartJs.Blazor/ChartJsInterop.js" type="text/javascript" language="javascript"></script>
```

## Usage

For detailed instruction go to the [Wiki page](https://github.com/mariusmuntean/ChartJSBlazor/wiki). 

1. In you cshtml create a new ChartJsPieChart and give it an instance of PieChartConfig ...

```html
<h2>Chart JS charts using Blazor</h2>
<div class="row">
    <button class="btn btn-primary" onclick="@UpdateChart">Update Chart </button>
</div>
<ChartJsPieChart ref="pieChartJs" Config="@pieChartConfig" Width="600" Height="300"/>
```

... make sure to create that instance
```csharp
@functions{

    private PieChartConfig pieChartConfig { get; set; }
    ChartJsPieChart pieChartJs;

    protected override void OnInit()
    {
        pieChartConfig = pieChartConfig ?? new PieChartConfig
        {
            CanvasId = "myFirstPieChart",
            Options = new PieChartOptions
            {
                Text = "Sample chart from Blazor",
                Display = true,
                Responsive = true,
                Animation = new PieChartAnimation {AnimateRotate = true, AnimateScale = true}
            },
            Data = new PieChartData
            {
                Labels = new List<string> {"A", "B", "C", "D"},
                Datasets = new List<PieChartDataset>
                {
                    new PieChartDataset
                    {
                        BackgroundColor = new[] {"#ff6384", "#55ee84", "#4463ff", "#efefef"},
                        Data = new List<int> {4, 5, 6, 7},
                        Label = "Light Red",
                        BorderWidth = 0,
                        HoverBackgroundColor = new[] {"#f06384"},
                        HoverBorderColor = new[] {"#f06384"},
                        HoverBorderWidth = new[] {1}, BorderColor = "#ffffff",
                    }
                }
            }
        };
    }
}
```

2. In your index.html add these

```html
    .
    .
    .
<body>
    <app>Loading...</app>

    <!--<script src="css/bootstrap/bootstrap-native.min.js"></script>-->
    <script src="//cdnjs.cloudflare.com/ajax/libs/Chart.js/2.7.2/Chart.min.js"></script>
    <!--<script src="https://cdnjs.cloudflare.com/ajax/libs/Chart.js/2.5.0/Chart.bundle.min.js"></script>-->
    <link rel="stylesheet" href="//cdnjs.cloudflare.com/ajax/libs/highlight.js/9.12.0/styles/default.min.css">
    <script src="//cdnjs.cloudflare.com/ajax/libs/highlight.js/9.12.0/highlight.min.js"></script>
    <!--<script type="blazor-boot">
            </script>-->
    <script src="_framework/blazor.webassembly.js" type="text/javascript" language="javascript"></script>
    <script src="ChartJsInterop.js" type="text/javascript" language="javascript"></script>
</body>
    .
    .
    .
```

# Contributors
* [Joelius300](https://github.com/Joelius300)
* [SeppPenner](https://github.com/SeppPenner)
