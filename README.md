[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](/LICENSE.md)
[![GitHub issues](https://img.shields.io/github/issues/mariusmuntean/chartjs.blazor)](https://github.com/mariusmuntean/ChartJs.Blazor/issues)
[![GitHub forks](https://img.shields.io/github/forks/mariusmuntean/chartjs.blazor)](https://github.com/mariusmuntean/ChartJs.Blazor/network/members)
[![GitHub stars](https://img.shields.io/github/stars/mariusmuntean/chartjs.blazor)](https://github.com/mariusmuntean/ChartJs.Blazor/stargazers)

[![Join the chat at https://gitter.im/ChartJs-Blazor/community](https://badges.gitter.im/ChartJs-Blazor/community.svg)](https://gitter.im/ChartJs-Blazor/community?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge)

[![NuGet Downloads (official NuGet)](https://img.shields.io/nuget/dt/ChartJs.Blazor?label=NuGet%20Downloads)](https://www.nuget.org/packages/ChartJs.Blazor/)  
[![NuGet Downloads (2.0 NuGet)](https://img.shields.io/nuget/dt/ChartJs.Blazor.Fork?label=NuGet%20Downloads)](https://www.nuget.org/packages/ChartJs.Blazor.Fork/)

[![Netlify Status](https://api.netlify.com/api/v1/badges/4edc0972-1674-4ff7-8fdc-41e643b33738/deploy-status)](https://app.netlify.com/sites/chartjs-blazor-samples/deploys)

# Introduction
This is a Blazor library that wraps [Chart.js](https://www.chartjs.org/). You can use it in both client- and server-side projects.

Don't know what Blazor is? Read [this](https://dotnet.microsoft.com/apps/aspnet/web-apps/client).

# Getting started
## Prerequisites

You need an IDE that supports Blazor and .NET Core SDK 3.x+

1. Possible IDEs are: [Visual Studio 2019](https://visualstudio.microsoft.com/downloads/) (Community Edition is fine) / [VisualStudio for Mac](https://visualstudio.microsoft.com/vs/mac/), [Jetbrains Rider](https://www.jetbrains.com/rider/) and more
2. [.NET Core 3.1](https://dotnet.microsoft.com/download/dotnet-core/3.1) or newer

## Installation

**Due to an [unfortunate situation](https://github.com/mariusmuntean/ChartJs.Blazor/issues/160), the new 2.0 release is only available in an [alternative NuGet package](https://www.nuget.org/packages/ChartJs.Blazor.Fork/) for the time being.**  
The original NuGet is [ChartJs.Blazor](https://www.nuget.org/packages/ChartJs.Blazor/).

Install our NuGet package: [ChartJs.Blazor.Fork](https://www.nuget.org/packages/ChartJs.Blazor.Fork/)

You can install it with the Package Manager in your IDE or alternatively using the command line:

```bash
dotnet add package ChartJs.Blazor.Fork
```

## Usage
### Assets

Before you can start creating a chart, you have to add some static assets to your project.

In your `_Host.cshtml` (server-side) or in your `index.html` (client-side) add the following lines to the `body` tag **after** the `_framework` reference.

```html
<script src="https://cdn.jsdelivr.net/npm/chart.js@2.9.4/dist/Chart.min.js"></script>

<!-- This is the glue between Blazor and Chart.js -->
<script src="_content/ChartJs.Blazor.Fork/ChartJsBlazorInterop.js"></script>
```

If you are using a time scale (`TimeAxis`), you also need to include Moment.js.

```html
<script src="https://cdnjs.cloudflare.com/ajax/libs/moment.js/2.29.1/moment.min.js"></script>
```

If you don't want to use CDNs, check out the [Chart.js installation page](https://www.chartjs.org/docs/latest/getting-started/installation.html) and
the [Moment.js installation page](https://momentjs.com/docs/#/use-it/) where you can find alternative ways to install the necessary libraries.

### Imports
Now add a reference to `ChartJs.Blazor` in your `_Imports.razor`.

```csharp
@using ChartJs.Blazor;
```

Other commonly used namespaces which you might want to import globally are:
- `ChartJs.Blazor.Common`
- `ChartJs.Blazor.Common.Axes`
- `ChartJs.Blazor.Common.Axes.Ticks`
- `ChartJs.Blazor.Common.Enums`
- `ChartJs.Blazor.Common.Handlers`
- `ChartJs.Blazor.Common.Time`
- `ChartJs.Blazor.Util`
- `ChartJs.Blazor.Interop`

Apart from that every chart type has a namespace e.g. `ChartJs.Blazor.PieChart`.

### Chart

Now let's create a simple pie chart!

In order to use the classes for a pie chart, we need to add `@using ChartJs.Blazor.PieChart` to the top of our component.

Then we can add a `Chart` component anywhere in the markup like so:

```html
<Chart Config="_config"></Chart>
```

The only thing left to do now is to provide the data and chart configuration by declaring an instance variable which we reference in the `Chart` component.
We do this in the `@code` section of our component.

```csharp
private PieConfig _config;

protected override void OnInitialized()
{
    _config = new PieConfig
    {
        Options = new PieOptions
        {
            Responsive = true,
            Title = new OptionsTitle
            {
                Display = true,
                Text = "ChartJs.Blazor Pie Chart"
            }
        }
    };

    foreach (string color in new string[] { "Red", "Yellow", "Green", "Blue" })
    {
        _config.Data.Labels.Add(color);
    }

    PieDataset<int> dataset = new PieDataset<int>(new[] { 6, 5, 3, 7 })
    {
        BackgroundColor = new[]
        {
            ColorUtil.ColorHexString(255, 99, 132), // Slice 1 aka "Red"
            ColorUtil.ColorHexString(255, 205, 86), // Slice 2 aka "Yellow"
            ColorUtil.ColorHexString(75, 192, 192), // Slice 3 aka "Green"
            ColorUtil.ColorHexString(54, 162, 235), // Slice 4 aka "Blue"
        }
    };

    _config.Data.Datasets.Add(dataset);
}
```

This small sample should get you started and introduce you to the most basic concepts used for creating a chart. For more relevant examples, please see our [samples](#samples).

## Samples
Since Version 2.0 we'd like to keep the samples as similar to the [official Chart.js samples](https://www.chartjs.org/samples/latest/) as possible.
Unfortunately, we're not up to date yet and many samples are missing. If you'd like to help, please check out [this issue](https://github.com/mariusmuntean/ChartJs.Blazor/issues/122) :heart:

**To check out the code of the most recent (development version - explained below) samples, go to the [ChartJs.Blazor.Samples/Client/Pages folder](./ChartJs.Blazor.Samples/Client/Pages).**

The [ChartJs.Blazor.Samples folder](./ChartJs.Blazor.Samples) contains the projects to showcase the samples. It's based on [Suchiman/BlazorDualMode](https://github.com/Suchiman/BlazorDualMode) and allows you to switch between the server- and the client-side Blazor mode.

The samples should always be up to date with the current development on master. That means that the code you see on master might not work for your version.
To browse the samples for the latest NuGet version, see the [samples on the releases branch](https://github.com/mariusmuntean/ChartJs.Blazor/tree/releases/ChartJs.Blazor.Samples/Client/Pages) or select a specific tag.
If there's not a sample for your use-case on the releases branch, check out the master one. Maybe someone already contributed what you're looking for and if not, why not do it yourself :wink:

We would usually host the samples on https://www.iheartblazor.com but unfortunately, the version shown there is really old and we highly recommend downloading and running our samples on your machine.

## Docs
We can't offer thorough docs at this time.

If you run into an issue, we recommend you to do the following steps:
- It's simple but depending on your situation it helps to go to the definition of the C#-class you're working with. The XML-docs are usually quite detailed and often contain relevant links.
- Browse our [samples](#samples) - You can find a lot of information there.
- Browse the [official Chart.js docs](https://www.chartjs.org/docs/latest/) - This library is just a wrapper, there's a very high chance you can find what you need there.
- Browse our [issues](https://github.com/mariusmuntean/ChartJs.Blazor/issues?q=is%3Aissue) - Your issue might've already been reported.
- If none of that helped, open a new issue and fill out the template with your details. There's a good chance that someone else can help you.

## Known Limitations

* Client-side Blazor projects are currently affected by a bug in `JSON.NET` tracked by [this issue](https://github.com/JamesNK/Newtonsoft.Json/issues/2020).
  If you run into this issue, use one of these two workarounds:

  * **Prefered Option** - add a file named [Linker.xml](https://docs.microsoft.com/en-us/aspnet/core/host-and-deploy/blazor/configure-linker?view=aspnetcore-3.1) to the root of your client-side project to instruct the Mono linker to keep a certain constructor that `JSON.NET` invokes via reflection.
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

  * ***Alternative Option*** - manually invoke the `ReferenceConverter` constructor to avoid the linker optimizing it away. Example:

    ```csharp
    private ReferenceConverter ReferenceConverter = new ReferenceConverter(typeof(Chart));
    ```

# Contributors
We thank everyone who has taken their time to open detailed issues, discuss problems with us or contribute code to the repository. Without you, projects like this would be very hard to maintain!

Check out the [list of contributors](https://github.com/mariusmuntean/ChartJs.Blazor/graphs/contributors).

* Owner of the project is [Marius Muntean](https://github.com/mariusmuntean).
* Current maintainer is [Joel Liechti](https://github.com/Joelius300).

# Contributing
We really like people helping us with the project. Nevertheless, take your time to read our contributing guidelines [here](CONTRIBUTING.md).
