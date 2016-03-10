### Single Dataset Per Line Example ###
```
// Each dataset is the set of y-axis coordinates
// they will be spaced evenly on the x-axis
int[] line1 = new int[] { 5, 10, 50, 34, 10, 25 };
int[] line2 = new int[] { 15, 20, 60, 44, 20, 35 };

List<int[]> datasets = new List<int[]>();
dataset.Add(line1);
dataset.Add(line2);

// Create a line chart that is 250 pixels wide and 150 pixels high
LineChart lineChart = new LineChart(250, 150);

// Set the title text, title color and title font size in pixels
lineChart.SetTitle("Single Dataset Per Line", "0000FF", 14);

// Set the chart to use our collection of datasets
lineChart.SetData(datasets);

// If we create an axis with only this parameter it will
// have a range of 0-100 and be evenly spaced across the chart
lineChart.AddAxis(new ChartAxis(ChartAxisType.Bottom));
lineChart.AddAxis(new ChartAxis(ChartAxisType.Left));

lineChart.GetUrl();
```
[See this chart](http://chart.apis.google.com/chart?cht=lc&chs=250x150&chd=s:FKyiKZ,PU8sUj&chtt=Single+Dataset+Per+Line&chts=0000FF,14&chxt=x,y&chxl=0:|1:&chxp=&chxr=&chxs=)

### Multiple Datasets Per Line Example ###
```
// This type of line chart expects a pair of datasets per line
// The first dataset is used as the x-axis coordinates while
// the second dataset is used as the y-axis coordinates
int[] line1x = new int[] { 0, 15, 30, 45, 60 };
int[] line1y = new int[] { 10, 50, 15, 60, 12};
int[] line2x = new int[] { 0, 15, 30, 45, 60 };
int[] line2y = new int[] { 45, 12, 60, 34, 60 };

List<int[]> datasets = new List<int[]>();
dataset.Add(line1x);
dataset.Add(line1y);
dataset.Add(line2x);
dataset.Add(line2y);

// Note we have to specify a MultiDataSet line chart
LineChart lineChart = new LineChart(250, 150, LineChartType.MultiDataSet);
lineChart.SetTitle("Multi Dataset Per Line", "0000FF", 14);
lineChart.SetData(datasets);
lineChart.AddAxis(new ChartAxis(ChartAxisType.Bottom));
lineChart.AddAxis(new ChartAxis(ChartAxisType.Left));

lineChart.GetUrl();
```
[See this chart](http://chart.apis.google.com/chart?cht=lxy&chs=250x150&chd=s:APet8,KyP8M,APet8,tM8i8&chtt=Multi+Dataset+Per+Line&chts=0000FF,14&chxt=x,y&chxl=0:|1:&chxp=&chxr=&chxs=)