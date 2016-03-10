### Solid Fill Example ###
```
int[] line1 = new int[] { 5, 10, 50, 34, 10, 25 };
LineChart lineChart = new LineChart(250, 150);
lineChart.SetTitle("Solid fill test");
lineChart.SetData(line1);

lineChart.AddAxis(new ChartAxis(ChartAxisType.Left));
lineChart.AddAxis(new ChartAxis(ChartAxisType.Bottom));

// Specify the area to fill (background or chart area)
// and the fill color
SolidFill bgFill = new SolidFill(ChartFillTarget.Background, "EFEFEF");
SolidFill chartAreaFill = new SolidFill(ChartFillTarget.ChartArea, "000000");

// In this case we are applying solid fills to both the background and the
// chart area
lineChart.AddSolidFill(bgFill);
lineChart.AddSolidFill(chartAreaFill);

lineChart.GetUrl();
```
[See the chart](http://chart.apis.google.com/chart?cht=lc&chs=250x150&chd=s:FKyiKZ&chtt=Solid+fill+test&chf=bg,s,EFEFEF|c,s,000000&chxt=y,x&chxl=0:|1:&chxp=&chxr=&chxs=)