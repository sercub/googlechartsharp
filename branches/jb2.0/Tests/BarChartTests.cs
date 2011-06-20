using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using GoogleChartSharp;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class BarChartTests
    {
        [Test]
        public void horizontalStackedTest()
        {
            BarChart barChart = new BarChart(150, 150, BarChartOrientation.Horizontal, BarChartStyle.Stacked)
                                    {
                                        Title = "Horizontal Stacked",
                                        Axes = new Axes { new Axis(AxisLocation.Bottom), new Axis(AxisLocation.Left) },
                                        Data = new[] {new int[] {10, 5, 20, 15}, new int[] {10, 10, 10, 10}},
                                        DatasetColors = new string[] {"FF0000", "00AA00"}
                                    };

            var actual = barChart.GetUrl();
            var expected = "http://chart.apis.google.com/chart?cht=bhs&chs=150x150&chd=s:KFUP,KKKK&chtt=Horizontal+Stacked&chco=FF0000,00AA00&chxt=x,y&chxr=&chxs=";
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void verticalStackedTest()
        {
            BarChart barChart = new BarChart(150, 150, BarChartOrientation.Vertical, BarChartStyle.Stacked)
                                    {
                                        Title = "Vertical Stacked",
                                        Axes = new Axes { new Axis(AxisLocation.Bottom), new Axis(AxisLocation.Left) },
                                        Data = new[] {new int[] {10, 5, 20, 15}, new int[] {10, 10, 10, 10}},
                                        DatasetColors = (new string[] {"FF0000", "00AA00"})
                                    };

            var actual = barChart.GetUrl();
            var expected = "http://chart.apis.google.com/chart?cht=bvs&chs=150x150&chd=s:KFUP,KKKK&chtt=Vertical+Stacked&chco=FF0000,00AA00&chxt=x,y&chxr=&chxs=";
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void horizontalGroupedTest()
        {


            BarChart barChart = new BarChart(150, 150, BarChartOrientation.Horizontal, BarChartStyle.Grouped)
                                    {
                                        Title = "Horizontal Grouped",
                                        Axes = new Axes { new Axis(AxisLocation.Bottom), new Axis(AxisLocation.Left) },
                                        Data = new[] {new[] {10, 5, 20}, new[] {5, 10, 20}},
                                        DatasetColors = (new[] {"FF0000", "00AA00"}),
                                        BarWidth = 10
                                        
                                    };

            

            var actual = barChart.GetUrl();
            var expected = "http://chart.apis.google.com/chart?cht=bhg&chs=150x150&chd=s:KFU,FKU&chtt=Horizontal+Grouped&chco=FF0000,00AA00&chxt=x,y&chxr=&chxs=&chbh=10";
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void verticalGroupedTest()
        {
            BarChart barChart = new BarChart(300, 150, BarChartOrientation.Vertical, BarChartStyle.Grouped)
                                    {
                                        Title = "Vertical Grouped",
                                        Axes = new Axes { new Axis(AxisLocation.Bottom), new Axis(AxisLocation.Left) },
                                        Data = new[] {new[] {10, 5, 20}, new[] {30, 35, 15}},
                                        DatasetColors = (new string[] {"FF0000", "00AA00"})
                                    };

            var actual = barChart.GetUrl();
            var expected = "http://chart.apis.google.com/chart?cht=bvg&chs=300x150&chd=s:KFU,ejP&chtt=Vertical+Grouped&chco=FF0000,00AA00&chxt=x,y&chxr=&chxs=";
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void zeroLineTest()
        {
            BarChart barChart = new BarChart(300, 150, BarChartOrientation.Vertical, BarChartStyle.Grouped)
                                    {
                                        Title = "Zero Line",
                                        Axes = new Axes { new Axis(AxisLocation.Bottom), new Axis(AxisLocation.Left) },
                                        Data = new[] {new int[] {10, 5, 20}, new int[] {30, 35, 20}},
                                        DatasetColors = (new string[] {"FF0000", "00AA00"}),
                                        ZeroLine = 0.25
                                    };


            var actual = barChart.GetUrl();
            var expected = "http://chart.apis.google.com/chart?cht=bvg&chs=300x150&chd=s:KFU,ejU&chtt=Zero+Line&chco=FF0000,00AA00&chxt=x,y&chxr=&chxs=&chp=0.25";
            Assert.AreEqual(expected, actual);
        }
    }
}
