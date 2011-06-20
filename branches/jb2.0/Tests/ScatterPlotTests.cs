using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using GoogleChartSharp;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class ScatterPlotTests
    {
        [Test]
        public void scatterPlotTest()
        {
            ScatterPlot scatterPlot = new ScatterPlot(150, 150)
                                          {
                                              Title = "Scatter Plot",
                                              Data =
                                                  new[] {new int[] {10, 20, 30, 40, 50}, new int[] {10, 20, 30, 40, 50}},
                                              Axes =
                                                  new Axes {new Axis(AxisLocation.Left), new Axis(AxisLocation.Bottom)}
                                          };

            var actual=  scatterPlot.GetUrl();
            var expected = "http://chart.apis.google.com/chart?cht=s&chs=150x150&chd=s:KUeoy,KUeoy&chtt=Scatter+Plot&chxt=y,x&chxr=&chxs=";
            Assert.AreEqual(expected, actual);
        }
    }
}
