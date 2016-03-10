### Linear Stripes Example ###
```
float[] fdata = new float[] { 10, 30, 75, 40, 15 };
LineChart chart = new LineChart(250, 150);
chart.SetTitle("Linear Stripes Test");
chart.SetData(fdata);

chart.AddAxis(new ChartAxis(ChartAxisType.Left));
chart.AddAxis(new ChartAxis(ChartAxisType.Bottom));

LinearStripesFill linearStripesFill = new LinearStripesFill(ChartFillTarget.ChartArea, 0);
linearStripesFill.AddColorWidthPair("CCCCCC", 0.2);
linearStripesFill.AddColorWidthPair("FFFFFF", 0.2);
chart.AddLinearStripesFill(linearStripesFill);

chart.AddSolidFill(new SolidFill(ChartFillTarget.Background, "EFEFEF"));
chart.GetUrl();
```
[See the chart](http://chart.apis.google.com/chart?cht=lc&chs=250x150&chd=t:10,30,75,40,15&chtt=Linear+Stripes+Test&chf=bg,s,EFEFEF|c,ls,0,CCCCCC,0.2,FFFFFF,0.2&chxt=y,x&chxl=0:|1:&chxp=&chxr=&chxs=)