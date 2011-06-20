using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using GoogleChartSharp;
using NUnit.Framework;
using System.Diagnostics;

namespace Tests
{
    [TestFixture]
    public class LineChartTests
    {
        [Test]
        public void singleDatasetPerLine()
        {
            LineChart lineChart = new LineChart(250, 150)
                                      {
                                          Title =
                                              new Title {Text = "Single Dataset Per Line", Color = "0000FF", Size = 14},
                                          Data =
                                              new[]
                                                  {
                                                      new int[] {5, 10, 50, 34, 10, 25},
                                                      new int[] {15, 20, 60, 44, 20, 35}
                                                  },
                                          Axes = new Axes { new Axis(AxisLocation.Bottom), new Axis(AxisLocation.Left) },
                                      };

            var actual = lineChart.GetUrl();
            var expected =
                "http://chart.apis.google.com/chart?cht=lc&chs=250x150&chd=s:FKyiKZ,PU8sUj&chtt=Single+Dataset+Per+Line&chts=0000FF,14&chxt=x,y&chxr=&chxs=";
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void sparklines()
        {
            LineChart lineChart = new SparkLineChart(250, 150)
                                      {
                                          Data = new[]
                                                     {
                                                         new float[]
                                                             {
                                                                 27, 25, 25, 25, 25, 27, 100, 31, 25, 36, 25, 25, 39, 25
                                                                 ,
                                                                 31, 25, 25, 25, 26, 26, 25, 25, 28, 25, 25, 100, 28, 27
                                                                 , 31, 25, 27,
                                                                 27, 29, 25, 27,
                                                                 26, 26, 25, 26, 26, 35, 33, 34, 25, 26, 25, 36, 25, 26,
                                                                 37, 33, 33, 37,
                                                                 37, 39, 25, 25, 25, 25
                                                             }
                                                     },
                                          Title = "Sparklines test"
                                      };

            var actual = lineChart.GetUrl();
            var expected =
                "http://chart.apis.google.com/chart?cht=ls&chs=250x150&chd=t:27,25,25,25,25,27,100,31,25,36,25,25,39,25,31,25,25,25,26,26,25,25,28,25,25,100,28,27,31,25,27,27,29,25,27,26,26,25,26,26,35,33,34,25,26,25,36,25,26,37,33,33,37,37,39,25,25,25,25&chtt=Sparklines+test";
            Assert.AreEqual(expected, actual);

        }

        [Test]
        public void multiDatasetPerLine()
        {
            LineChart lineChart = new MultiLineChart(250, 150)
                                      {
                                          Title =
                                              new Title {Text = "Multi Dataset Per Line", Color = "0000FF", Size = 14},
                                          Data = new[]
                                                     {
                                                         new[] {0, 15, 30, 45, 60},
                                                         new[] {10, 50, 15, 60, 12},
                                                         new[] {0, 15, 30, 45, 60},
                                                         new[] {45, 12, 60, 34, 60}
                                                     },
                                          Axes = new Axes { new Axis(AxisLocation.Bottom), new Axis(AxisLocation.Left) },
                                      };

            var actual = lineChart.GetUrl();
            var expected =
                "http://chart.apis.google.com/chart?cht=lxy&chs=250x150&chd=s:APet8,KyP8M,APet8,tM8i8&chtt=Multi+Dataset+Per+Line&chts=0000FF,14&chxt=x,y&chxr=&chxs=";
            Assert.AreEqual(expected, actual);

        }

        [Test]
        public void lineColorAndLegendTest()
        {
            LineChart lineChart = new LineChart(250, 150)
                                      {
                                          Title =
                                              new Title
                                                  {Text = "Line Color And Legend Test", Color = "0000FF", Size = 14},
                                          Data = new[]
                                                     {
                                                         new int[] {5, 10, 50, 34, 10, 25},
                                                         new int[] {15, 20, 60, 44, 20, 35}
                                                     },
                                          Axes = new Axes { new Axis(AxisLocation.Bottom), new Axis(AxisLocation.Left) },
                                          DatasetColors = (new string[] {"FF0000", "00FF00"}),
                                          Legend = new Legend {"line1", "line2"}
                                      };

            var actual = lineChart.GetUrl();
            var expected =
                "http://chart.apis.google.com/chart?cht=lc&chs=250x150&chd=s:FKyiKZ,PU8sUj&chtt=Line+Color+And+Legend+Test&chts=0000FF,14&chco=FF0000,00FF00&chdl=line1|line2&chxt=x,y&chxr=&chxs=";
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void lineStyleTest()
        {
            LineChart lineChart = new LineChart(250, 150)
                                      {
                                          Title = new Title {Text = "Line Style Test", Color = "0000FF", Size = 14},
                                          Data = new[]
                                                     {
                                                         new[] {5, 10, 50, 34, 10, 25},
                                                         new[] {15, 20, 60, 44, 20, 35}
                                                     },
                                          Axes = new Axes {new Axis(AxisLocation.Bottom), new Axis(AxisLocation.Left)},
                                          LineStyles = new[] {new LineStyle(2, 5, 1), new LineStyle(1, 1, 5)}
                                      };


            var actual = lineChart.GetUrl();
            var expected =
                "http://chart.apis.google.com/chart?cht=lc&chs=250x150&chd=s:FKyiKZ,PU8sUj&chtt=Line+Style+Test&chts=0000FF,14&chxt=x,y&chxr=&chxs=&chls=2,5,1|1,1,5";
            Assert.AreEqual(expected, actual);
        }
    }
}
