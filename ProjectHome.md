## A C# wrapper for the Google Chart API. ##

See the source code that generated this chart on the [UsageExamples](UsageExamples.md) page.
### Documentation ###
The library [documentation](Documentation.md) provides examples of all the Chart API features.

If you have any questions after reading the documentation, the [Google Chart API Developer's Guide](http://code.google.com/apis/chart/) is an excellent reference.

### A Simple Example ###
```
using GoogleChartSharp;

int[] data = new int[] { 0, 10, 20, 30, 40 };
LineChart chart = new LineChart(150, 150);
chart.SetData(data);
string url = chart.GetUrl();
```
[See the chart](http://chart.apis.google.com/chart?cht=lc&chs=150x150&chd=s:AKUeo)