### Scatter Plot Example ###
```
// The first dataset is used as the x-axis coordinates of each mark
// The second dataset is used as the y-axis coordinates
int[] xData = { 10, 20, 30, 40, 50 };
int[] yData = { 10, 20, 30, 40, 50 };

List<int[]> dataset = new List<int[]>();
dataset.Add(xData);
dataset.Add(yData);

ScatterPlot scatterPlot = new ScatterPlot(150, 150);
scatterPlot.SetTitle("Scatter Plot");
scatterPlot.SetData(dataset);

scatterPlot.AddAxis(new ChartAxis(ChartAxisType.Left));
scatterPlot.AddAxis(new ChartAxis(ChartAxisType.Bottom));

return scatterPlot.GetUrl();
```
[See this chart](http://chart.apis.google.com/chart?cht=s&chs=150x150&chd=s:KUeoy,KUeoy&chtt=Scatter+Plot&chxt=y,x&chxl=0:|1:&chxp=&chxr=&chxs=)