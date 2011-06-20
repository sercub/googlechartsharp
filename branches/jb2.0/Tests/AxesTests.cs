using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using GoogleChartSharp;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class AxesTests
    {
        [Test]
        public void allBasicAxesTest()
        {


            LineChart lineChart = new LineChart(250, 150)
                                      {
                                          Title = new Title {Text = "Basic Axes Test", Color = "0000FF", Size = 14},
                                          Data = new[] {new[] {5, 10, 50, 34, 10, 25}, new[] {15, 20, 60, 44, 20, 35}},
                                          Axes = new Axes
                                                     {
                                                         new Axis(AxisLocation.Bottom),
                                                         new Axis(AxisLocation.Left),
                                                         new Axis(AxisLocation.Right),
                                                         new Axis(AxisLocation.Top)
                                                     }
                                      };


            var actual = lineChart.GetUrl();
            var expected = "http://chart.apis.google.com/chart?cht=lc&chs=250x150&chd=s:FKyiKZ,PU8sUj&chtt=Basic+Axes+Test&chts=0000FF,14&chxt=x,y,r,t&chxr=&chxs=";
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void axesLabelsTest()
        {

            LineChart lineChart = new LineChart(250, 150)
                                      {
                                          Title = new Title {Text = "Axis Labels Test", Color = "0000FF", Size = 14},
                                          Data = new[] {new[] {5, 10, 50, 34, 10, 25}, new[] {15, 20, 60, 44, 20, 35}},
                                          Axes = new Axes
                                                     {
                                                         new Axis
                                                             {
                                                                 Location = AxisLocation.Bottom,
                                                                 Labels =
                                                                     new[]
                                                                         {
                                                                             new AxisLabel("b"), new AxisLabel("o"),
                                                                             new AxisLabel("t"),
                                                                             new AxisLabel("t"), new AxisLabel("o"),
                                                                             new AxisLabel("m")
                                                                         }
                                                             },
                                                         new Axis
                                                             {
                                                                 Location = AxisLocation.Left,
                                                                 Labels =
                                                                     new[]
                                                                         {
                                                                             new AxisLabel("l"), new AxisLabel("e"),
                                                                             new AxisLabel("f"),
                                                                             new AxisLabel("t")
                                                                         }
                                                             },
                                                         new Axis
                                                             {
                                                                 Location = AxisLocation.Right,
                                                                 Labels = new[]
                                                                              {
                                                                                  new AxisLabel("r"),
                                                                                  new AxisLabel("i"),
                                                                                  new AxisLabel("g"),
                                                                                  new AxisLabel("h"),
                                                                                  new AxisLabel("t"),
                                                                              }
                                                             },
                                                         new Axis
                                                             {
                                                                 Location = AxisLocation.Top,
                                                                 Labels = new[]
                                                                              {
                                                                                  new AxisLabel("t"),
                                                                                  new AxisLabel("o"),
                                                                                  new AxisLabel("p")
                                                                              }
                                                             }
                                                     }
                                      };

            var actual = lineChart.GetUrl();
            var expected =
                "http://chart.apis.google.com/chart?cht=lc&chs=250x150&chd=s:FKyiKZ,PU8sUj&chtt=Axis+Labels+Test&chts=0000FF,14&chxt=x,y,r,t&chxl=0:|b|o|t|t|o|m|1:|l|e|f|t|2:|r|i|g|h|t|3:|t|o|p&chxr=&chxs=";
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void axesRangeTest()
        {


            LineChart lineChart = new LineChart(250, 150)
                                      {
                                          Title = new Title {Text = "Axes Range Test", Color = "0000FF", Size = 14},
                                          Data = new[] {new[] {5, 10, 50, 34, 10, 25}, new[] {15, 20, 60, 44, 20, 35}},
                                          Axes = new Axes
                                                     {
                                                         new Axis
                                                             {
                                                                 Location = AxisLocation.Top,
                                                                 Range = new AxisRange {LowerBound = 0, UpperBound = 10}
                                                             },
                                                         new Axis
                                                             {
                                                                 Location = AxisLocation.Right,
                                                                 Range = new AxisRange {LowerBound = 0, UpperBound = 10}
                                                             },
                                                         new Axis
                                                             {
                                                                 Location = AxisLocation.Bottom,
                                                                 Range = new AxisRange {LowerBound = 0, UpperBound = 10}
                                                             },
                                                         new Axis
                                                             {
                                                                 Location = AxisLocation.Left,
                                                                 Range = new AxisRange {LowerBound = 0, UpperBound = 10}
                                                             }
                                                     }
                                      };


            var actual = lineChart.GetUrl();
            var expected =
                "http://chart.apis.google.com/chart?cht=lc&chs=250x150&chd=s:FKyiKZ,PU8sUj&chtt=Axes+Range+Test&chts=0000FF,14&chxt=t,r,x,y&chxr=0,0,10|1,0,10|2,0,10|3,0,10&chxs=";
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void axesStyleTest()
        {


            LineChart lineChart = new LineChart(250, 150)
                                      {
                                          Title = new Title {Text = "Axes Style Test", Color = "0000FF", Size = 14},
                                          Data = new[] {new[] {5, 10, 50, 34, 10, 25}, new[] {15, 20, 60, 44, 20, 35}},
                                          Axes = new Axes
                                                     {
                                                         new Axis(AxisLocation.Top)
                                                             {
                                                                 Range = new AxisRange {LowerBound = 0, UpperBound = 10},
                                                                 Labels =
                                                                     new[]
                                                                         {
                                                                             new AxisLabel("test", 2),
                                                                             new AxisLabel("test", 6)
                                                                         },
                                                                 FontSize = 12,
                                                                 Color = "FF0000",
                                                                 Alignment = AxisAlignmentType.Left
                                                             },
                                                         new Axis(AxisLocation.Bottom)
                                                             {
                                                                 Labels =
                                                                     new[]
                                                                         {
                                                                             new AxisLabel("test", 2),
                                                                             new AxisLabel("test", 6)
                                                                         },
                                                                 Range = new AxisRange {LowerBound = 0, UpperBound = 10},
                                                                 FontSize = 14,
                                                                 Color = "00FF00",
                                                                 Alignment = AxisAlignmentType.Right
                                                             }
                                                     }
                                      };

            var actual =  lineChart.GetUrl();
            var expected =
                "http://chart.apis.google.com/chart?cht=lc&chs=250x150&chd=s:FKyiKZ,PU8sUj&chtt=Axes+Style+Test&chts=0000FF,14&chxt=t,x&chxl=0:|test|test|1:|test|test&chxp=0,2,6|1,2,6&chxr=0,0,10|1,0,10&chxs=0,FF0000,12,-1|1,00FF00,14,1";
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void stackedAxesTest()
        {

            LineChart lineChart = new LineChart(250, 150)
                                      {
                                          Title = new Title {Text = "Stacked Axes Test", Color = "0000FF", Size = 14},
                                          Data = new[] {new[] {5, 10, 50, 34, 10, 25}, new[] {15, 20, 60, 44, 20, 35}},
                                          Axes = new Axes {new Axis(AxisLocation.Bottom), new Axis(AxisLocation.Bottom)}
                                      };


            var actual =  lineChart.GetUrl();
            var expected =
                "http://chart.apis.google.com/chart?cht=lc&chs=250x150&chd=s:FKyiKZ,PU8sUj&chtt=Stacked+Axes+Test&chts=0000FF,14&chxt=x,x&chxr=&chxs=";
            Assert.AreEqual(expected, actual);
        }
    }
}
