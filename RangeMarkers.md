### Range Markers Example ###
```
/*
Mark ranges by creating colored bands across the chart
*/
float[] fdata = new float[] { 10, 30, 75, 40, 15 };
LineChart chart = new LineChart(250, 150);
chart.SetTitle("Range markers test");
chart.SetData(fdata);

chart.AddAxis(new ChartAxis(ChartAxisType.Left));
chart.AddAxis(new ChartAxis(ChartAxisType.Bottom));

chart.AddRangeMarker(new RangeMarker(RangeMarkerType.Horizontal, "EFEFEF", 0.2, 0.7));
chart.AddRangeMarker(new RangeMarker(RangeMarkerType.Vertical, "CCCCCC", 0.4, 0.6));

chart.GetUrl();
```
[See the chart](http://chart.apis.google.com/chart?cht=lc&chs=250x150&chd=t:10,30,75,40,15&chtt=Range+markers+test&chxt=y,x&chxl=0:|1:&chxp=&chxr=&chxs=&chm=r,EFEFEF,0,0.2,0.7|R,CCCCCC,0,0.4,0.6)