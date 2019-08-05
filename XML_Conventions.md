# XML-docs guidelines (for consistency)

## General
**If there is a similar class or property etc try to keep the consistency and use the same/similar summary.**

### Constructors

> Creates a new instance of <see cref="CLASS"/>

#### Example LineChartConfig
```
/// <summary>
/// Creates a new instance of <see cref="LineChartConfig"/>
/// </summary>
```

## Config
### Class summary
 
> Config for a <see cref="CHART"/>

#### Example LineChartConfig
```
/// <summary>
/// Config for a <see cref="ChartJs.Blazor.Charts.ChartJsLineChart"/>
/// </summary>
```

## Options
### Class summary

> The options-subconfig of a <see cref="CONFIG"/>

#### Example LineChartOptions
```
/// <summary>
/// The options-subconfig of a <see cref="LineChartConfig"/>
/// </summary>
```

## Data
### Class summary

> The data-subconfig of a <see cref="CONFIG"/>

#### Example LineChartData
```
/// <summary>
/// The data-subconfig of a <see cref="LineChartConfig"/>
/// </summary>
```

## Dataset
### Class summary

> A dataset for a <see cref="CHART"/>

### typeparam name="TData"

It should also include a mention of the wrappers if it implements the covariant IMixableDataset.

> Defines the type of data in this dataset. Use Wrappers from <see cref="Common.Wrappers"/> for value types.

#### Example LineChartDataset<TData>
```
/// <summary>
/// A dataset for a <see cref="Charts.ChartJsLineChart"/>
/// </summary>
/// <typeparam name="TData">Defines the type of data in this dataset. Use Wrappers from <see cref="Common.Wrappers"/> for value types.</typeparam>
```

## Anything with color

If there is a property that represents a color, it should be of type string (unless there's wrapper implemented -> maybe in the future). It should contain a mention of `ColorUtil`.

> See <see cref="Util.Color.ColorUtil"/> for working with colors.

#### Example ScaleLabel.FontColor
```
/// <summary>
/// The fontcolor of the label
/// <para>See <see cref="Util.Color.ColorUtil"/> for working with colors.</para>
/// </summary>
```