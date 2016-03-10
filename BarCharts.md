### Stacked Bar Chart Example ###
```
// In this type of bar chart the datasets are stacked on top of each other
int[] data1 = new int[] { 10, 5, 20, 15 };
int[] data2 = new int[] { 10, 10, 10, 10 };

List<int[]> datasets = new List<int[]>();
dataset.Add(data1);
dataset.Add(data2);

// BarChartOrientation defines how the individual bars are positioned
// BarChartStyle defines how the bar chart handles multiple datasets
BarChart barChart = new BarChart(150, 150, BarChartOrientation.Horizontal, BarChartStyle.Stacked);
barChart.SetTitle("Horizontal Stacked");
barChart.AddAxis(new ChartAxis(ChartAxisType.Bottom));
barChart.AddAxis(new ChartAxis(ChartAxisType.Left));
barChart.SetData(datasets);

// Dataset colors are applied to datasets in order
// In this case the items from data1 will appear in red while the
// items from data2 will appear in green
barChart.SetDatasetColors(new string[] { "FF0000", "00AA00" });

barChart.GetUrl();
```

[See this chart](http://chart.apis.google.com/chart?cht=bhs&chs=150x150&chd=s:KFUP,KKKK&chtt=Horizontal+Stacked&chco=FF0000,00AA00&chxt=x,y&chxl=0:|1:&chxp=&chxr=&chxs=)

### Grouped Bar Chart Example ###
```
// In this type of bar chart the dataset items are displayed side by side
int[] data1 = new int[] { 10, 5, 20 };
int[] data2 = new int[] { 30, 35, 15 };

List<int[]> datasets = new List<int[]>();
dataset.Add(data1);
dataset.Add(data2);

BarChart barChart = new BarChart(300, 150, BarChartOrientation.Vertical, BarChartStyle.Grouped);
barChart.SetTitle("Vertical Grouped");
barChart.AddAxis(new ChartAxis(ChartAxisType.Bottom));
barChart.AddAxis(new ChartAxis(ChartAxisType.Left));
barChart.SetData(datasets);

barChart.SetDatasetColors(new string[] { "FF0000", "00AA00" });

barChart.GetUrl();
```
[See this chart](http://chart.apis.google.com/chart?cht=bvg&chs=300x150&chd=s:KFU,ejP&chtt=Vertical+Grouped&chco=FF0000,00AA00&chxt=x,y&chxl=0:|1:&chxp=&chxr=&chxs=)