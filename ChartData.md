## Chart Data Limitations ##
Please read the [Chart Data](http://code.google.com/apis/chart/#chart_data) section of the Google Chart Api Developer's Guide. Even though this library attempts to abstract encoding datasets you should read enough to understand the limitations of the Api.

A dataset of type int[.md](.md) with values less than or equal to 61 will be encoded using simple encoding.

A dataset of type int[.md](.md) with values less than or equal to 4095 will be encoded using extended encoding.

A dataset of type float[.md](.md) with values less than or equal to 100 will be encoded using text encoding.

## Single Dataset ##
A single dataset can be contained in either an int[.md](.md) or a float[.md](.md). You set a chart's data set using the `Chart.SetData()` method.

For example:
```
using GoogleChartSharp;

/*
Create a single integer dataset
*/
int[] intData = new int[] {0, 10, 20, 30, 40};

/*
Create a single float dataset
*/
float[] floatData = new float[] {0.0, 0.5, 1.0, 1.5, 2.0};

/* 
Create a new line chart with width 150 and height 150. The default line chart
uses one data set per line, evenly spacing the data points out along the x axis.
*/
LineChart lineChart = new LineChart(150, 150);

/*
Set the chart to use the integer dataset
*/
lineChart.SetData(intData);
string url = lineChart.GetUrl();

/*
Set the chart to use the float dataset
*/
lineChart.SetData(floatData);
string otherUrl = lineChart.GetUrl();
```

### Multiple Datasets ###
A chart can also use multiple datasets. The datasets (of type int[.md](.md) or float[.md](.md)) must be contained in a data structure that implements the ICollection interface.
```
using GoogleChartSharp;

/*
This pair of datasets describes a line. The first set is the X axis coordinated and the second set is the Y axis coordinates.
*/
int[] xCoords = new int[] {0, 10, 20, 30, 40};
int[] yCoords = new int[] {0, 10, 20, 30, 40};

/*
Add the pair of datasets to the collection. To draw multiple lines on the chart add additional dataset pairs to the collection.
*/
List<int[]> datasets = new List<int[]>();
line1.Add(xCoords);
line1.Add(yCoords);

/*
Note that we have to specify a MultiDataSet line chart type.
*/
LineChart lineChart = new LineChart(150, 150, LineChartType.MultiDataSet);
lineChart.SetData(datasets);
string url = lineChart.GetUrl();
```

### Missing Values ###
In all dataset types a missing value should be represented by a -1.
```
int[] intData = new int[] { 0, 10, -1, 30, 40};
float[] floatData = new float[] { 0.0, 0.5, -1, 1.5, 2.0 };
```