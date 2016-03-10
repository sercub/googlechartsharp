### Two Dimensional Pie Chart Example ###
```
int[] data = new int[] { 10, 20, 30, 40 };

// Create a Pie Chart that is 250 pixels wide and 150 pixels tall
PieChart pieChart = new PieChart(250, 150);
pieChart.SetTitle("2D Test");
pieChart.SetData(data);

// Label each slice in the same order as the dataset
pieChart.SetPieChartLabels(new string[] { "A", "B", "C", "D" });

pieChart.GetUrl();
```
[See this chart](http://chart.apis.google.com/chart?cht=p&chs=250x150&chd=s:KUeo&chtt=2D+Test&chl=A|B|C|D)

### Three Dimensional Pie Chart Example ###
```
int[] data = new int[] { 10, 20, 30, 40 };

// Specify that this is a 3D Pie Chart
PieChart pieChart = new PieChart(300, 150, PieChartType.ThreeD);
pieChart.SetTitle("3D Test");
pieChart.SetData(data);

// Label each slice in the same order as the dataset
pieChart.SetPieChartLabels(new string[] { "A", "B", "C", "D" });

// Optional - We can specify a color for each item of data or
// if we specify fewer colors they are interpolated
pieChart.SetDatasetColors(new string[] { "0000FF" });

pieChart.GetUrl();
```
[See this chart](http://chart.apis.google.com/chart?cht=p3&chs=300x150&chd=s:KUeo&chtt=3D+Test&chco=0000FF&chl=A|B|C|D)