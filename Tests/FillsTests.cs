using System.Collections.Generic;
using System.Diagnostics;
using GoogleChartSharp;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class FillsTests
    {
        [Test]
        public void solidFillTest()
        {
            var lineChart = new LineChart(250, 150)
                                {
                                    Title = "Solid fill test",
                                    Axes = new Axes { new Axis(AxisLocation.Left), new Axis(AxisLocation.Bottom) },
                                    Fills = new Fills
                                                {
                                                    new SolidFill(FillTarget.Background, "EFEFEF"),
                                                    new SolidFill(FillTarget.ChartArea, "000000")
                                                }
                                };


            lineChart.Data = new[] {5, 10, 50, 34, 10, 25};
            var actual =  lineChart.GetUrl();
            var expected = "http://chart.apis.google.com/chart?cht=lc&chs=250x150&chd=s:FKyiKZ&chtt=Solid+fill+test&chf=bg,s,EFEFEF|c,s,000000&chxt=y,x&chxr=&chxs=";
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void linearGradientFillTest()
        {
            var lineChart = new LineChart(250, 150)
                                {
                                    Title = "Linear Gradient fill test",
                                    Axes = new Axes { new Axis(AxisLocation.Bottom), new Axis(AxisLocation.Left)},
                                    Fills = new Fills
                                                {
                                                    new SolidFill(FillTarget.Background, "EFEFEF"),
                                                    new LinearGradientFill
                                                        {
                                                            FillTarget = FillTarget.ChartArea,
                                                            Angle = 45,
                                                            ColorOffsetPairs = new[]
                                                                                   {
                                                                                       new ColorOffsetPair("FFFFFF", 0),
                                                                                       new ColorOffsetPair("76A4FB",
                                                                                                           0.75)
                                                                                   }
                                                        }
                                                    
                                                }
                                };


            lineChart.Data = (new[] {5, 10, 50, 34, 10, 25});
            var actual =  lineChart.GetUrl();
            var expected = "http://chart.apis.google.com/chart?cht=lc&chs=250x150&chd=s:FKyiKZ&chtt=Linear+Gradient+fill+test&chf=bg,s,EFEFEF|c,lg,45,FFFFFF,0,76A4FB,0.75&chxt=x,y&chxr=&chxs=";
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void linearStripesTest()
        {
            var chart = new LineChart(250, 150)
                            {
                                Title = "Linear Stripes Test",
                                Axes = new Axes { new Axis(AxisLocation.Left), new Axis(AxisLocation.Bottom) },
                                Fills = new Fills
                                            {new SolidFill(FillTarget.Background, "EFEFEF"),
                                                new LinearStripesFill
                                                    {
                                                        FillTarget = FillTarget.ChartArea,
                                                        Angle = 0,
                                                        ColorWidthPairs =
                                                            new[]
                                                                {
                                                                    new ColorWidthPair("CCCCCC", 0.2),
                                                                    new ColorWidthPair("FFFFFF", 0.2)
                                                                }
                                                    }
                                                
                                            }
                            };


            chart.Data = (new float[] {10, 30, 75, 40, 15});
            var actual =  chart.GetUrl();
            var expected = "http://chart.apis.google.com/chart?cht=lc&chs=250x150&chd=t:10,30,75,40,15&chtt=Linear+Stripes+Test&chf=bg,s,EFEFEF|c,ls,0,CCCCCC,0.2,FFFFFF,0.2&chxt=y,x&chxr=&chxs=";
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void singleLineAreaFillTest()
        {
            var chart = new LineChart(250, 150)
                            {
                                Title = "Area fill test",
                                Axes = new Axes { new Axis(AxisLocation.Bottom), new Axis(AxisLocation.Left) },
                                Markers = new[] {new FillArea("224499", 0)},
                                Data = new float[] {10, 30, 75, 40, 15}
                            };


            var actual =  chart.GetUrl();
            var expected = "http://chart.apis.google.com/chart?cht=lc&chs=250x150&chd=t:10,30,75,40,15&chtt=Area+fill+test&chxt=x,y&chxr=&chxs=&chm=B,224499,0,0,0";
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void multiLineAreaFillsTest()
        {
            var lineChart = new LineChart(250, 150)
                                {
                                    Title = "Area fills test",
                                    Axes = new Axes {new Axis(AxisLocation.Left), new Axis(AxisLocation.Bottom)},
                                    Markers = new[] {new FillArea("FF0000", 0, 1), new FillArea("224499", 1, 2)},
                                    Data = new[]
                                               {
                                                   new float[] {15, 45, 5, 30, 10},
                                                   new float[] {35, 65, 25, 50, 30},
                                                   new float[] {55, 85, 45, 70, 50}
                                               }
                                };


            var actual =  lineChart.GetUrl();
            var expected = "http://chart.apis.google.com/chart?cht=lc&chs=250x150&chd=t:15,45,5,30,10|35,65,25,50,30|55,85,45,70,50&chtt=Area+fills+test&chxt=y,x&chxr=&chxs=&chm=b,FF0000,0,1,0|b,224499,1,2,0";
            Assert.AreEqual(expected, actual);
        }
    }
}