# Changelog
<details open="open">
<summary>0.10.4</summary>

* We updated everything to .NET Core 3 which means this library has no more preview dependencies.
* The issue with static assets has been resolved. The readme has been updated to include how you can include the static assets without copying.
* More special enums have been implemented for a more typesafe experience. Also some were renamed to their respective singular name.
  * ChartTypes -> ChartType
  * Positions -> Position
  * AxisDisplay
  * BorderAlign
  * BorderCapStyle
  * BorderJoinStyle
  * CubicInterpolationMode
  * FontStyle
  * PointStyle
  * ScaleBound
* We reworked the Tooltips which means it's now more complete (but there are still things missing like callbacks which may be implemented later on in the original repo) and it's also available for every chart-option.
* We reworked the bar-chart. There were some side-effects of this since the axes which were used for the line-chart.
  * Move all Axes from the specific chart to the Common namespace. This affects line- and polar-area-charts.
  * Some common classes like `SubTicks`, `Minor-` and `MajorTicks` have been moved around in the common namespace because there is now `Common.Axes` and `Common.Axes.Ticks`.
  * Bar-charts accept all cartesian axes but there are some extra properties for bar-axes. For this reason there are specific axes for bar-charts in the `BarChart.Axes` namespace which derive from the cartesian axes.
  * All Time related classes except for the `TimeAxis` and the `TimeTicks` were moved to `Common.Time`.
  * Generally make more complete by adding new properties to axes and bar-charts. Lots of refactoring is also always something required in a rework.

</details>

<details>
<summary>0.10.3</summary>

* Remove unnecessary highlight.js
* Lots of XML-documentation improvements
* Lots of bug-fixes
  * Multiple wrong property names, types and or locations
  * Fix a bug that caused the wrong onClick & generateLabels function to be used for Pie- and Polar-Area-Chart
* Make the Canvas-id read-only so users don't have to come up with unique names. A GUID will be used instead.
* Lots of general improvements (refactoring, remove redundancies, etc)
* Implement indexable options
  * [Indexable options](https://www.chartjs.org/docs/latest/general/options.html#indexable-options) can store either a single value or an array of values. If it's a single value it will be applies to all element. If it's an array it will be applied to the element with the same index.
* Update to preview9
* Rework Pie-Chart
  * Make more complete by adding classes and properties.
  * Adjust options so it can be used with doughnut-chart
* Remove Doughnut-Chart
  * This was done because the Pie-chart and the Doughnut-chart are exactly the same with one single difference; the CutoutPercentage-default is 50 for doughnut and 0 for pie.  
  The PieOptions now have an optional argument called 'doughnutCutout'. If true, the CutoutPercentage will be set to 50.
* Rework Polar-Area-Chart
  * Remove redundancies and move common classes to the Common namespace. This might affect line-charts (missing namespace).
  * Update Ticks to be more general and complete. There is a known issue with the Major- and the Minor-ticks (wrong properties) which will be fixed in a later update.
  * Make more complete by adding classes and properties.
* <details><summary>Rename classes to comply with the consistent naming conventions. From XXChartYY to XXYY.</summary>
 
  * BarChartAxis  ->  BarAxis
  * BarChartConfig  ->  BarConfig
  * BarChartData  ->  BarData
  * BarChartOptions  ->  BarOptions
  * BarChartOptionsScales  ->  BarOptionsScales
  * BarChartDataset  ->  BarDataset
  * BaseBarChartDataset  ->  BaseBarDataset
  * IndividualBarChartDataset  ->  IndividualBarDataset
  * BubbleChartConfig  ->  BubbleConfig
  * BubbleChartData  ->  BubbleData
  * BubbleData  ->  BubbleDataPoint
  * BubbleChartDataset  ->  BubbleDataset
  * BubbleChartOptions  ->  BubbleOptions
  * BubbleChartPointStyle  ->  BubblePointStyle
  * BaseChartConfigOptions  ->  BaseConfigOptions
  * ChartConfigBase  ->  ConfigBase
  * LineChartConfig  ->  LineConfig
  * LineChartData  ->  LineData
  * LineChartDataset  ->  LineDataset
  * LineChartOptions  ->  LineOptions
  * LineChartOptionsHover  ->  LineOptionsHover
  * MixedChartConfig  ->  MixedConfig
  * MixedChartData  ->  MixedData
  * MixedChartOptions  ->  MixedOptions
  * PieChartConfig  ->  PieConfig
  * PieChartData  ->  PieData
  * PieChartDataset  ->  PieDataset
  * PieChartOptions  ->  PieOptions
  * PolarAreaChartConfig  ->  PolarAreaConfig
  * RadarChartConfig  ->  RadarConfig
  * RadarChartData  ->  RadarData
  * RadarChartDataset  ->  RadarDataset
  * RadarChartOptions  ->  RadarOptions
  * RadarChartPointStyles  ->  RadarPointStyles
  * ScatterChartAxis  ->  ScatterAxis
  * ScatterChartConfig  ->  ScatterConfig
  * ScatterChartData  ->  ScatterData
  * ScatterChartDataset  ->  ScatterDataset
  * ScatterChartOptions  ->  ScatterOptions
  * ScatterChartScales  ->  ScatterScales
  * TimeTupel -> TimeTuple (typo)
  
</details>

</details>

<details>
<summary>0.10.2</summary>
    
* Update ReadMe
* Clean and update .csproj file
* Create nuget package
* Update XML-docs handling

</details>
