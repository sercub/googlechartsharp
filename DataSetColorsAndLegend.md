### Dataset Colors and Legend Example ###
```
int[] line1 = new int[] { 5, 10, 50, 34, 10, 25 };
int[] line2 = new int[] { 15, 20, 60, 44, 20, 35 };

List<int[]> dataset = new List<int[]>();
dataset.Add(line1);
dataset.Add(line2);

LineChart lineChart = new LineChart(250, 150);
lineChart.SetTitle("Line Color And Legend Test", "0000FF", 14);
lineChart.SetData(dataset);
lineChart.AddAxis(new ChartAxis(ChartAxisType.Bottom));
lineChart.AddAxis(new ChartAxis(ChartAxisType.Left));

// Assign a color to each dataset in the same order the datasets were added
lineChart.SetDatasetColors(new string[] { "FF0000", "00FF00" });

// Specify legend labels in the same way
// The legend will use the dataset color
lineChart.SetLegend(new string[] { "line1", "line2" });

lineChart.GetUrl();
```
[See the chart](http://chart.apis.google.com/chart?cht=lc&chs=250x150&chd=s:FKyiKZ,PU8sUj&chtt=Line+Color+And+Legend+Test&chts=0000FF,14&chco=FF0000,00FF00&chdl=line1|line2&chxt=x,y&chxl=0:|1:&chxp=&chxr=&chxs=)