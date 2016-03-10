### Linear Gradient Fill Example ###
```
int[] line1 = new int[] { 5, 10, 50, 34, 10, 25 };
LineChart lineChart = new LineChart(250, 150);
lineChart.SetTitle("Linear Gradient fill test");
lineChart.SetData(line1);

lineChart.AddAxis(new ChartAxis(ChartAxisType.Left));
lineChart.AddAxis(new ChartAxis(ChartAxisType.Bottom));

// This is a linear gradient that goes from white to blue at 45 degress 
// across the chart area.
// A color/offset pair represents a color and when that color is pure on the 
// chart with 0 as the leftmost position on the chart and 1 as the rightmost.
LinearGradientFill fill = new LinearGradientFill(ChartFillTarget.ChartArea, 45);
fill.AddColorOffsetPair("FFFFFF", 0);
fill.AddColorOffsetPair("76A4FB", 0.75);

SolidFill bgFill = new SolidFill(ChartFillTarget.Background, "EFEFEF");

lineChart.AddLinearGradientFill(fill);
lineChart.AddSolidFill(bgFill);

lineChart.GetUrl();
```
[See the chart](http://chart.apis.google.com/chart?cht=lc&chs=250x150&chd=s:FKyiKZ&chtt=Linear+Gradient+fill+test&chf=bg,s,EFEFEF|c,lg,45,FFFFFF,0,76A4FB,0.75&chxt=y,x&chxl=0:|1:&chxp=&chxr=&chxs=)