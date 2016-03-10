### Shape Markers Example ###
```
/*
Mark data points with shapes
*/
float[] fdata = new float[] { 10, 30, 75, 40, 15 };
LineChart chart = new LineChart(300, 150);
chart.SetTitle("Shape markers test");
chart.SetData(fdata);

chart.AddAxis(new ChartAxis(ChartAxisType.Left));
chart.AddAxis(new ChartAxis(ChartAxisType.Bottom));

// ShapeMarker Parameters:
//   ShapeMarkerType - describes the shape of the marker
//   Color - a RRGGBB hex color code
//   Dataset index - 0 means the first dataset
//   Data point index - the datapoint to mark
//   Size - the size of the marker in pixels
chart.AddShapeMarker(new ShapeMarker(ShapeMarkerType.Arrow, "FF0000", 0, 0, 5));
chart.AddShapeMarker(new ShapeMarker(ShapeMarkerType.Circle, "00FF00", 0, 1, 15));
chart.AddShapeMarker(new ShapeMarker(ShapeMarkerType.Cross, "0000FF", 0, 2, 15));
chart.AddShapeMarker(new ShapeMarker(ShapeMarkerType.VerticalLine, "FF0000", 0, 3, 2));

chart.GetUrl();
```
[See the chart](http://chart.apis.google.com/chart?cht=lc&chs=300x150&chd=t:10,30,75,40,15&chtt=Shape+markers+test&chxt=y,x&chxl=0:|1:&chxp=&chxr=&chxs=&chm=a,FF0000,0,0,5|o,00FF00,0,1,15|c,0000FF,0,2,15|V,FF0000,0,3,2)