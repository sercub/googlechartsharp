### Adding an axis ###
```
/*
This is the simplest way to add an axis to a chart. The only 
parameter is the axis location. The axis will have an evenly spaced range
from 0 to 100
*/
ChartAxis bottomAxis = new ChartAxis(ChartAxisType.Bottom);

int[] line1 = new int[] { 5, 10, 50, 34, 10, 25 };
LineChart lineChart = new LineChart(150, 150);

lineChart.AddAxis(bottomAxis);
lineChart.SetData(line1);
lineChart.GetUrl();
```
[See this chart](http://chart.apis.google.com/chart?cht=lc&chs=150x150&chd=s:FKyiKZ&chxt=x&chxl=0:&chxp=&chxr=&chxs=)

### Axis Labels ###
```
// This is a shorthand way of adding axis labels. Include an array of label strings
// and they will be evenly spaced along the axis.
ChartAxis leftAxis = new ChartAxis(ChartAxisType.Left, new string[] { "one", "two", "three" });

// This method of adding axes gives the most control.
// ChartAxisLabel is constructed with a label string and a position.
// It will appear on the axis at that position.
// Note that the position is in relation to the axis range, in this case 0-100.
ChartAxis bottomAxis = new ChartAxis(ChartAxisType.Bottom);
bottomAxis.AddLabel(new ChartAxisLabel("a", 0));
bottomAxis.AddLabel(new ChartAxisLabel("b", 10));
bottomAxis.AddLabel(new ChartAxisLabel("c", 50));
bottomAxis.AddLabel(new ChartAxisLabel("d", 100));

int[] line1 = new int[] { 5, 10, 50, 34, 10, 25 };
LineChart lineChart = new LineChart(150, 150);

lineChart.AddAxis(leftAxis);
lineChart.AddAxis(bottomAxis);
lineChart.SetData(line1);
lineChart.GetUrl();
```
[See this chart](http://chart.apis.google.com/chart?cht=lc&chs=150x150&chd=s:FKyiKZ&chxt=y,x&chxl=0:|one|two|three|1:|a|b|c|d&chxp=1,0,10,50,100&chxr=&chxs=)

### Setting the Axis Range ###
```
ChartAxis bottomAxis = new ChartAxis(ChartAxisType.Bottom);

// The axis range will be 0-50 evenly spaced along the axis
bottomAxis.SetRange(0, 50);

int[] line1 = new int[] { 5, 10, 50, 34, 10, 25 };
LineChart lineChart = new LineChart(150, 150);

lineChart.AddAxis(bottomAxis);
lineChart.SetData(line1);
return lineChart.GetUrl();
```
[See this chart](http://chart.apis.google.com/chart?cht=lc&chs=150x150&chd=s:FKyiKZ&chxt=x&chxl=0:&chxp=&chxr=0,0,50&chxs=)

### Stacking Axises ###
```
/*
It is possible to stack axises by adding more than one to the same location 
on the chart. Here we are adding two axes to the bottom of the chart. Note 
that the first axis added in the closest to the chart.
*/
ChartAxis bottomAxis = new ChartAxis(ChartAxisType.Bottom);
ChartAxis bottomAxis2 = new ChartAxis(ChartAxisType.Bottom);
bottomAxis2.SetRange(0, 50);

int[] line1 = new int[] { 5, 10, 50, 34, 10, 25 };
LineChart lineChart = new LineChart(150, 150);

lineChart.AddAxis(bottomAxis);
lineChart.AddAxis(bottomAxis2);

lineChart.SetData(line1);
return lineChart.GetUrl();
```
[See this chart](http://chart.apis.google.com/chart?cht=lc&chs=150x150&chd=s:FKyiKZ&chxt=x,x&chxl=0:|1:&chxp=&chxr=1,0,50&chxs=)