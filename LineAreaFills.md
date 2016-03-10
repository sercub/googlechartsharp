### Single Line Area Fill Example ###
```
/*
Fill the entire area below a single line
*/
float[] fdata = new float[] { 10, 30, 75, 40, 15 };
LineChart chart = new LineChart(250, 150);
chart.SetTitle("Area fill test");
chart.SetData(fdata);

chart.AddAxis(new ChartAxis(ChartAxisType.Left));
chart.AddAxis(new ChartAxis(ChartAxisType.Bottom));

chart.AddFillArea(new FillArea("224499", 0));

chart.GetUrl();
```
[See the chart](http://chart.apis.google.com/chart?cht=lc&chs=250x150&chd=t:10,30,75,40,15&chtt=Area+fill+test&chxt=y,x&chxl=0:|1:&chxp=&chxr=&chxs=&chm=B,224499,0,0,0)

### Mutliple Line Area Fill Example ###
```
/*
Fill the area between lines
*/
float[] line1 = new float[] { 15, 45, 5, 30, 10 };
float[] line2 = new float[] { 35, 65, 25, 50, 30 };
float[] line3 = new float[] { 55, 85, 45, 70, 50 };

List<float[]> dataset = new List<float[]>();
dataset.Add(line1);
dataset.Add(line2);
dataset.Add(line3);

LineChart lineChart = new LineChart(250, 150, LineChartType.SingleDataSet);
lineChart.SetTitle("Area fills test");
lineChart.SetData(dataset);

lineChart.AddAxis(new ChartAxis(ChartAxisType.Left));
lineChart.AddAxis(new ChartAxis(ChartAxisType.Bottom));

lineChart.AddFillArea(new FillArea("FF0000", 0, 1));
lineChart.AddFillArea(new FillArea("224499", 1, 2));

lineChart.GetUrl();
```
[See the chart](http://chart.apis.google.com/chart?cht=lc&chs=250x150&chd=t:15,45,5,30,10|35,65,25,50,30|55,85,45,70,50&chtt=Area+fills+test&chxt=y,x&chxl=0:|1:&chxp=&chxr=&chxs=&chm=b,FF0000,0,1,0|b,224499,1,2,0)