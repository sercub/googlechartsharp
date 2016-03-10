### Grid Example - Only setting the step size ###
```
int[] line1 = new int[] { 5, 10, 50, 34, 10, 25 };
LineChart lineChart = new LineChart(250, 150);
lineChart.SetTitle("Step Size Test");
lineChart.AddAxis(new ChartAxis(ChartAxisType.Left));
lineChart.AddAxis(new ChartAxis(ChartAxisType.Bottom));
lineChart.SetData(line1);

// The step size is the distance between grid lines
// It is relative to the axis range
// SetGrid(YAxisStepSize, XAxisStepSize)
lineChart.SetGrid(20, 50);

lineChart.GetUrl();
```
[See the chart](http://chart.apis.google.com/chart?cht=lc&chs=250x150&chd=s:FKyiKZ&chtt=Step+Size+Test&chxt=y,x&chxl=0:|1:&chxp=&chxr=&chxs=&chg=20,50)


### Grid Example - Using all the parameters ###
```
int[] line1 = new int[] { 5, 10, 50, 34, 10, 25 };
LineChart lineChart = new LineChart(250, 150);
lineChart.SetTitle("All Params Test");
lineChart.AddAxis(new ChartAxis(ChartAxisType.Left));
lineChart.AddAxis(new ChartAxis(ChartAxisType.Bottom));
lineChart.SetData(line1);

// The step size is the distance between grid lines
// It is relative to the axis range
// SolidLineSegmentLength is the length of each solid line segment
// BlankLineSegmentLength is the length of each blank segment that separates
// the solid segments
// SetGrid(XAxisStepSize, YAxisStepSize, SolidLineSegmentLength, BlankLineSegmentLength)
lineChart.SetGrid(20, 50, 1, 5);

lineChart.GetUrl();
```
[See the chart](http://chart.apis.google.com/chart?cht=lc&chs=250x150&chd=s:FKyiKZ&chtt=All+Params+Test&chxt=y,x&chxl=0:|1:&chxp=&chxr=&chxs=&chg=20,50,1,5)