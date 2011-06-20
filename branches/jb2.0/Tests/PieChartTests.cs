using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using GoogleChartSharp;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class PieChartTests
    {
        [Test]
        public void TwoDTest()
        {
            int[] data = new int[] { 10, 20, 30, 40 };
            PieChart pieChart = new PieChart(250, 150)
                                    {
                                        Title = "2D Test",
                                        Data = data,
                                        Labels = (new[] {"A", "B", "C", "D"})
                                    };

            var actual = pieChart.GetUrl();
            var expected = "http://chart.apis.google.com/chart?cht=p&chs=250x150&chd=s:KUeo&chtt=2D+Test&chl=A|B|C|D";
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ThreeDTest()
        {
            int[] data = new int[] { 10, 20, 30, 40 };
            PieChart pieChart = new PieChart(300, 150, PieChartType.ThreeD)
                                    {
                                        Title = "3D Test",
                                        Data = data,
                                        Labels = (new[] {"A", "B", "C", "D"}),
                                        DatasetColors = (new[] {"0000FF"})
                                    };

            var actual = pieChart.GetUrl();
            var expected="http://chart.apis.google.com/chart?cht=p3&chs=300x150&chd=s:KUeo&chtt=3D+Test&chco=0000FF&chl=A|B|C|D";
            Assert.AreEqual(expected, actual);
        }
    }
}
