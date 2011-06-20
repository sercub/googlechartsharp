using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using GoogleChartSharp;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class Examples
    {
        [Test]
        public void superSimple()
        {
            int[] data = new int[] { 0, 10, 20, 30, 40 };
            LineChart chart = new LineChart(150, 150);
            chart.Data = data;
            var actual = chart.GetUrl();
            var expected="http://chart.apis.google.com/chart?cht=lc&chs=150x150&chd=s:AKUeo";
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void simpleAxis()
        {
            int[] line1 = new int[] { 5, 10, 50, 34, 10, 25 };
            LineChart lineChart = new LineChart(150, 150);

            lineChart.Axes = new Axes {new Axis(AxisLocation.Bottom)};
            lineChart.Data = line1;
            var actual = lineChart.GetUrl();
            var expected = "http://chart.apis.google.com/chart?cht=lc&chs=150x150&chd=s:FKyiKZ&chxt=x&chxr=&chxs=";
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void axisLabels()
        {
            int[] line1 = new int[] { 5, 10, 50, 34, 10, 25 };
            LineChart lineChart = new LineChart(150, 150)
                                      {
                                          Axes = new Axes
                                                     {
                                                         new Axis
                                                             {
                                                                 Location = AxisLocation.Left,
                                                                 Labels =
                                                                     new[]
                                                                         {
                                                                             new AxisLabel("one"),
                                                                             new AxisLabel("two"),
                                                                             new AxisLabel("three")
                                                                         }
                                                             },
                                                         new Axis
                                                             {
                                                                 Location = AxisLocation.Bottom,
                                                                 Labels = new[]
                                                                              {
                                                                                  new AxisLabel("a", 0),
                                                                                  new AxisLabel("b", 10),
                                                                                  new AxisLabel("c", 50),
                                                                                  new AxisLabel("d", 100)
                                                                              }
                                                             }
                                                     }
                                      };
            lineChart.Data = line1;
            var actual = lineChart.GetUrl();
            var expected = "http://chart.apis.google.com/chart?cht=lc&chs=150x150&chd=s:FKyiKZ&chxt=y,x&chxl=0:|one|two|three|1:|a|b|c|d&chxp=1,0,10,50,100&chxr=&chxs=";
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void axisRange()
        {
            int[] line1 = new int[] { 5, 10, 50, 34, 10, 25 };
            LineChart lineChart = new LineChart(150, 150);

            lineChart.Axes = new Axes {new Axis(AxisLocation.Bottom)
                                           {
                                               Range = new AxisRange {LowerBound = 0, UpperBound = 50}
                                           }};
            lineChart.Data = line1;
            var actual = lineChart.GetUrl();
            var expected = "http://chart.apis.google.com/chart?cht=lc&chs=150x150&chd=s:FKyiKZ&chxt=x&chxr=0,0,50&chxs=";
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void stackingAxes()
        {
            int[] line1 = new int[] { 5, 10, 50, 34, 10, 25 };
            LineChart lineChart = new LineChart(150, 150);
            lineChart.Axes = new Axes
                                 {
                                     new Axis(AxisLocation.Bottom),
                                     new Axis(AxisLocation.Bottom)
                                         {
                                             Range = new AxisRange {LowerBound = 0, UpperBound = 50}
                                         }
                                 };

            lineChart.Data = line1;
            var actual = lineChart.GetUrl();
            var expected = "http://chart.apis.google.com/chart?cht=lc&chs=150x150&chd=s:FKyiKZ&chxt=x,x&chxr=1,0,50&chxs=";
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void xkcd()
        {
            float[] data = new float[] { 35, 30, 26, 22, 17, 5, 96, 5, 4, 3, 2, 2, 1, 1 };

            string[] axisLabels = new string[] {".00", ".02", ".04", ".06", ".08", ".10",
                                                ".12", ".14", ".16", ".18", ".20", ".22",
                                                ".24", ".26"};

            LineChart lineChart = new LineChart(400, 200)
                                      {
                                          Title = new Title {Text = "Programming Skill", Color = "000000", Size = 14},
                                          Axes = new Axes
                                                     {
                                                         new Axis(AxisLocation.Bottom)
                                                             {
                                                                 Range = new AxisRange {LowerBound = 0, UpperBound = 30},
                                                                 Labels =
                                                                     axisLabels.Select((x, i) => new AxisLabel(x, i*2)).
                                                                     ToArray()
                                                             },
                                                         new Axis(AxisLocation.Bottom)
                                                             {
                                                                 Labels = new[] {
                                                                             new AxisLabel( "Blood Alcohol Concentration (%)", 50)
                                                                         }
                                                             }
                                                     }
                                      };
            lineChart.Data = data;

            var actual = lineChart.GetUrl();
            var expected = "http://chart.apis.google.com/chart?cht=lc&chs=400x200&chd=t:35,30,26,22,17,5,96,5,4,3,2,2,1,1&chtt=Programming+Skill&chts=000000,14&chxt=x,x&chxl=0:|.00|.02|.04|.06|.08|.10|.12|.14|.16|.18|.20|.22|.24|.26|1:|Blood Alcohol Concentration (%)&chxp=0,0,2,4,6,8,10,12,14,16,18,20,22,24,26|1,50&chxr=0,0,30&chxs=";
            Assert.AreEqual(expected, actual);
        }
    }
}
