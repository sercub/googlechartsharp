using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using GoogleChartSharp;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class GridTests
    {
        [Test]
        public void stepSizeTest()
        {
            int[] line1 = new int[] { 5, 10, 50, 34, 10, 25 };
            LineChart lineChart = new LineChart(250, 150);
            lineChart.Title = "Step Size Test";
            lineChart.Axes = new Axes {new Axis(AxisLocation.Left), new Axis(AxisLocation.Bottom)};
            lineChart.Data = line1;
            lineChart.Grid = new Grid(20, 50);

            var actual =  lineChart.GetUrl();
            var expected = "http://chart.apis.google.com/chart?cht=lc&chs=250x150&chd=s:FKyiKZ&chtt=Step+Size+Test&chxt=y,x&chxr=&chxs=&chg=20,50";
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void allParamsTest()
        {
            int[] line1 = new int[] { 5, 10, 50, 34, 10, 25 };
            LineChart lineChart = new LineChart(250, 150);
            lineChart.Title = "All Params Test";
            lineChart.Axes = new Axes {new Axis(AxisLocation.Left), new Axis(AxisLocation.Bottom)};
            lineChart.Data = line1;

            lineChart.Grid = new Grid(20, 50, 1, 5);

            var actual =  lineChart.GetUrl();
            var expected = "http://chart.apis.google.com/chart?cht=lc&chs=250x150&chd=s:FKyiKZ&chtt=All+Params+Test&chxt=y,x&chxr=&chxs=&chg=20,50,1,5";
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void solidGridTest()
        {
            int[] line1 = new int[] { 5, 10, 50, 34, 10, 25 };
            LineChart lineChart = new LineChart(250, 150);
            lineChart.Title = "Solid Grid Test";
            lineChart.Axes = new Axes { new Axis(AxisLocation.Left), new Axis(AxisLocation.Bottom) };
            lineChart.Data = line1;

            lineChart.Grid = new Grid(20, 50, 1, 0);

            var actual =  lineChart.GetUrl();
            var expected = "http://chart.apis.google.com/chart?cht=lc&chs=250x150&chd=s:FKyiKZ&chtt=Solid+Grid+Test&chxt=y,x&chxr=&chxs=&chg=20,50,1,0";
            Assert.AreEqual(expected, actual);
        }
    }
}
