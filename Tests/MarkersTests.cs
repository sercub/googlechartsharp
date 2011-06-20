using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using GoogleChartSharp;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class MarkersTests
    {
        [Test]
        public void rangeMarkersTest()
        {
            LineChart chart = new LineChart(250, 150)
                                  {
                                      Title = "Range markers test",
                                      Data = (new float[] {10, 30, 75, 40, 15}),
                                      Axes = new Axes {new Axis(AxisLocation.Left), new Axis(AxisLocation.Bottom)},
                                      Markers = new[]
                                                    {
                                                        new RangeMarker(RangeMarkerType.Horizontal, "EFEFEF", 0.2, 0.7),
                                                        new RangeMarker(RangeMarkerType.Vertical, "CCCCCC", 0.4, 0.6)
                                                    }
                                  };

            var actual = chart.GetUrl();
            var expected =
                "http://chart.apis.google.com/chart?cht=lc&chs=250x150&chd=t:10,30,75,40,15&chtt=Range+markers+test&chxt=y,x&chxr=&chxs=&chm=r,EFEFEF,0,0.2,0.7|R,CCCCCC,0,0.4,0.6";
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void shapeMarkersTest()
        {
            LineChart chart = new LineChart(300, 150)
                                  {
                                      Title = "Shape markers test",
                                      Axes = new Axes {new Axis(AxisLocation.Left), new Axis(AxisLocation.Bottom)},
                                      Markers =
                                          new[]
                                              {
                                                  new ShapeMarker(ShapeMarkerType.Arrow, "FF0000", 0, 0, 5),
                                                  new ShapeMarker(ShapeMarkerType.Circle, "00FF00", 0, 1, 15),
                                                  new ShapeMarker(ShapeMarkerType.Cross, "0000FF", 0, 2, 15),
                                                  new ShapeMarker(ShapeMarkerType.VerticalLine, "FF0000", 0, 3, 2)
                                              },
                                      Data = (new float[] {10, 30, 75, 40, 15})
                                  };


            var actual = chart.GetUrl();
            var expected =
                "http://chart.apis.google.com/chart?cht=lc&chs=300x150&chd=t:10,30,75,40,15&chtt=Shape+markers+test&chxt=y,x&chxr=&chxs=&chm=a,FF0000,0,0,5|o,00FF00,0,1,15|c,0000FF,0,2,15|V,FF0000,0,3,2";

            Assert.AreEqual(expected, actual);
        }
    }
}
