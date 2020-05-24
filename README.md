# ChartJs interop with Blazor


[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](/LICENSE.md)
[![GitHub issues](https://img.shields.io/github/issues/mariusmuntean/chartjs.blazor)](https://github.com/mariusmuntean/ChartJs.Blazor/issues)
[![GitHub forks](https://img.shields.io/github/forks/mariusmuntean/chartjs.blazor)](https://github.com/mariusmuntean/ChartJs.Blazor/network/members)
[![GitHub stars](https://img.shields.io/github/stars/mariusmuntean/chartjs.blazor)](https://github.com/mariusmuntean/ChartJs.Blazor/stargazers)

[![Join the chat at https://gitter.im/ChartJs-Blazor/community](https://badges.gitter.im/ChartJs-Blazor/community.svg)](https://gitter.im/ChartJs-Blazor/community?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge)

[![NuGet Downloads](https://img.shields.io/nuget/dt/ChartJs.Blazor?label=NuGet%20Downloads)](https://www.nuget.org/packages/ChartJs.Blazor/)

[![Netlify Status](https://api.netlify.com/api/v1/badges/4edc0972-1674-4ff7-8fdc-41e643b33738/deploy-status)](https://app.netlify.com/sites/chartjs-blazor-samples/deploys)


# Introduction

This is a Blazor library that wraps [ChartJs](https://github.com/chartjs/Chart.js). You can use the library in both client- and server-side projects. See the *Getting Started*, browse the samples or reach out on Twitter if you need help.

Don't know what Blazor is? Read [here](https://dotnet.microsoft.com/apps/aspnet/web-apps/client).

# Getting started

## Prerequisites


You need an IDE that supports Blazor and .Net Core SDK 3.x+

1. [Visual Studio 2019](https://visualstudio.microsoft.com/downloads/) (Community Edition is fine) or [VisualStudio for Mac](https://visualstudio.microsoft.com/vs/mac/) or [Jetbrains Rider](https://www.jetbrains.com/rider/)
2. [.NET Core 3.0](https://dotnet.microsoft.com/download/dotnet-core/3.0) or newer


## Installation

There's a NuGet package available: [ChartJs.Blazor](https://www.nuget.org/packages/ChartJs.Blazor/)

In case you prefer the command line:

```bash
dotnet add package ChartJs.Blazor
```

## Usage

### Assets
Before you can start creating a chart, you have to add some static assets to your project. These come bundled with ChartJs.Blazor, so you only need to add a few lines to your `Index.html`/`_Host.cshtml`.

In your `_Host.cshtml` (server-side) or in your `index.html` (client-side) add the following lines to the `body` tag **after** the `_framework` reference

```html
<!-- Reference the included moment.js javascript file. -->
<script src="_content/ChartJs.Blazor/moment-with-locales.min.js" type="text/javascript" language="javascript"></script>

<!-- Reference the included ChartJs javascript file. -->
<script src="_content/ChartJs.Blazor/Chart.min.js" type="text/javascript" language="javascript"></script>

<!-- This is the glue between the C# code and the ChartJs charts -->
<script src="_content/ChartJs.Blazor/ChartJsBlazorInterop.js" type="text/javascript" language="javascript"></script>

<!-- Some styling -->
<link rel="stylesheet" href="_content/ChartJs.Blazor/ChartJSBlazor.css" />
```

### Imports
Now add a reference to `ChartJs.Blazor` in your `_Imports.razor`
```csharp
@using ChartJs.Blazor;
```

### Chart
Now you can create a .razor file where you display one of the charts.
Let's show a pie chart with 4 slices 🍕.

Make your page known to the router by adding a `@page` statement
```csharp
@page "/MyPieChart"
```

Then add a few `@using` statements
```csharp
@using ChartJs.Blazor.Charts
@using ChartJs.Blazor.ChartJS.PieChart
@using ChartJs.Blazor.ChartJS.Common.Properties
@using ChartJs.Blazor.Util
```

Below the `@using` statements add a `Chart` component
```html
<Chart @ref="_pieChartJs"
        Config="@_config"
        TConfig="PieConfig"
        Width="600"
        Height="300"/>
```
The last step is to make the `Chart` from above, reachable from your code to configure it and to give it some data to display. In the `@code` section of your .razor file create matching variables to reference the chart and its configuration. Finally, give your chart a title and some data. The finished code should look like this:

```csharp
    private PieConfig _config;
    private Chart<PieConfig> _pieChartJs;

    protected override void OnInitialized()
    {
        _config = new PieConfig
        {
            Options = new PieOptions
            {
                Title = new OptionsTitle
                {
                    Display = true,
                    Text = "Sample chart from Blazor"
                },
                Responsive = true,
                Animation = new ArcAnimation
                {
                    AnimateRotate = true,
                    AnimateScale = true
                }
            }
        };

        _config.Data.Labels.AddRange(new[] {"A", "B", "C", "D"});

        var pieSet = new PieDataset
        {
            BackgroundColor = new[] { ColorUtil.RandomColorString(), ColorUtil.RandomColorString(), ColorUtil.RandomColorString(), ColorUtil.RandomColorString() },
            BorderWidth = 0,
            HoverBackgroundColor = ColorUtil.RandomColorString(),
            HoverBorderColor = ColorUtil.RandomColorString(),
            HoverBorderWidth = 1,
            BorderColor = "#ffffff",
        };

        pieSet.Data.AddRange(new double[] {4, 5, 6, 7});
        _config.Data.Datasets.Add(pieSet);
    }
```

**Breakdown**

First, in your  `Index.html`/`_Host.cshtml` you've added references to static assets from `ChartJs.Blazor`. During build time, library assets get packaged under *_content/LibraryName*.

Then, you've imported `ChartJs.Blazor` in your `_Imports.razor`. The Blazor Team mentioned that this shouldn't be necessary in the future.

In your .razor file you added the `Chart` component and gave it some width and height. You specified that the component should use the variable `_config` as the chart's configuration object. You also told Blazor that you want a direct reference to the chart and that the reference should be saved in your `_pieChartJs` variable.

Note: for the moment you need to explicitly specify the type of the configuration object `TConfig="PieConfig"`. That won't be necessary in the future.

When your page's `OnInitialized()` method is executed you're setting the chart's configuration and dataset to be displayed.


## Known Limitations

### Library

* Client-side Blazor projects are currently affected by a bug in `JSON.NET` tracked by this [issue](https://github.com/JamesNK/Newtonsoft.Json/issues/2020).

    There are two known workarounds:

    * **Prefered Option** - add a file named [Linker.xml](https://docs.microsoft.com/en-us/aspnet/core/host-and-deploy/blazor/configure-linker?view=aspnetcore-3.0) to the root of your client-side project to instruct the Mono linker to keep a certain constructor that `JSON.NET` invokes via reflection.
    Make sure to select `BlazorLinkerDescription` as the build action of the `Linker.xml` file. In case that your IDE doesn't offer that option, simply edit the `.csproj` file and add this to it:
        ```xml
            <ItemGroup>
                <BlazorLinkerDescriptor Include="Linker.xml" />
            </ItemGroup>
        ```
        The content of the `Linker.xml` should be similar to this (adjust to your project's entry point assembly):
        ```xml
            <?xml version="1.0" encoding="UTF-8" ?>
            <!--
            This file specifies which parts of the BCL or Blazor packages must not be
            stripped by the IL Linker even if they aren't referenced by user code.
            -->
            <linker>
                <assembly fullname="mscorlib">
                    <!--
                        Preserve the methods in WasmRuntime because its methods are called by
                        JavaScript client-side code to implement timers.
                        Fixes: https://github.com/aspnet/Blazor/issues/239
                        -->
                    <type fullname="System.Threading.WasmRuntime" />
                </assembly>
                <assembly fullname="System.Core">
                    <!--
                        System.Linq.Expressions* is required by Json.NET and any
                        expression.Compile caller. The assembly isn't stripped.
                        -->
                    <type fullname="System.Linq.Expressions*" />
                </assembly>
                <!-- The app's entry point assembly is listed. -->
                <assembly fullname="ChartJs.Blazor.Sample.ClientSide" />
                <!-- Take care of System.MissingMethodException: Constructor on type 'System.ComponentModel.ReferenceConverter' not found. -->
                <assembly fullname="System">
                    <type fullname="System.ComponentModel.ReferenceConverter">
                    <method signature="System.Void .ctor(System.Type)" />
                    </type>
                </assembly>
            </linker>
        ```

    * ***Alternative Option*** - include the following line in the parent component:

        ```csharp
        private ReferenceConverter ReferenceConverter = new ReferenceConverter(typeof(PROBLEMATIC_COMPONENT));
        ```

        where `PROBLEMATIC_COMPONENT` is a placeholder for the chart-component you're using inside this component (e.g. `ChartJsBarChart`, `ChartJsPieChart`, `ChartJsLineChart`, ..).

### Samples

* When publishing the client-side Blazor sample, the generated **dist** folder is missing **_content\ChartJs.Blazor**. This seems to be a known bug in the current version of client-side Blazor. To work around this bug you need to go to the **publish** folder and locate the **wwwroot** folder. There you should find the missing **_content** folder. Copy the **_content** folder to the **dist** folder. The final **dist** folder should look like this
```shell
│   index.html
│
├───css
│   │   site.css
│   │
│   ├───bootstrap
│   │       bootstrap.min.css
│   │       bootstrap.min.css.map
│   │
│   └───open-iconic
│       │   FONT-LICENSE
│       │   ... truncated for brevity
│
├───_content
│   └───ChartJs.Blazor
│           Chart.min.js
│           ChartJSBlazor.css
│           ChartJsBlazorInterop.js
│           moment-with-locales.min.js
│
└───_framework
    │   blazor.boot.json
    │   blazor.server.js
    │   blazor.webassembly.js
    │
    ├───wasm
    │       mono.js
    │       mono.wasm
    │
    └───_bin
            ChartJs.Blazor.dll
            ChartJs.Blazor.pdb
            ... truncated for brevity
            System.Xml.Linq.dll
```

### Dig deeper
For detailed instructions read the [Chart.Js](https://www.chartjs.org/docs/latest/charts/) documentation to understand how each chart works.

## A word on the samples
The **samples** folder contains three projects, one for a client-side Blazor app, another one for a server-side Blazor app and a shared project. The shared project is not really necessary but that is how I chose to avoid code duplication.

The documentation might lag the actual development state (who likes to write documentation, am I right?) but the samples will probably never lag the actual state of the library. This is due to the way in which I develop where I constantly run the samples to play with new features of ChartJs.

To make it easier for you to see what ChartJs.Blazor can do I host the client-side samples with [Netlify](https://www.netlify.com) on [www.iheartblazor.com](https://www.iheartblazor.com) (and a few other domains 😁)


If you go there you should see something like this:
![Charts](media/samples.gif)

# Contributors
This projects slowly develops a community which started to give back.
## Special thanks to: ##
* [Joelius300](https://github.com/Joelius300) for keeping the project alive, developing it further and finally giving me the needed motivation to revive it.

## Many thanks to: #
* [SeppPenner](https://github.com/SeppPenner)
* [MindSwipe](https://github.com/MindSwipe)
* [Lars](https://github.com/larshg)
* [Jan](https://github.com/mashbrno)

We're very grateful for your contributions!

# Contributing
We really like people helping us with the project. Nevertheless, take your time to read our contributing guidelines [here](CONTRIBUTING.md).

Also keep in mind that this library is just a bridge from Blazor (C#) to Chart.js (JavaScript) so if you have a question on how to achieve something or experience unexpected behaviour, research how to do/fix it with JavaScript and only when you know how to get the correct behaviour in JavaScript open an issue here with all that information. It will greatly help us to give feedback and prevents us from wasting our limited time on issues that aren't really connected to this library. Thank you!
