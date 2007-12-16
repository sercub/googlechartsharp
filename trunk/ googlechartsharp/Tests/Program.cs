using System;
using System.Collections.Generic;
using System.Text;
using GoogleChartSharp;
using System.Diagnostics;
using System.Drawing;
using System.IO;

namespace Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            using (TextWriter tw = new StreamWriter(("test.html")))
            {
                int[] data;
                float[] fdata;
                List<int[]> intDataList = new List<int[]>();
                List<float[]> fDataList = new List<float[]>();

                # region Line Charts
                tw.WriteLine("<h3>Line Charts</h3>");
                tw.WriteLine(getImageTag(LineChartTests.singleDatasetPerLine()));
                tw.WriteLine(getImageTag(LineChartTests.multiDatasetPerLine()));
                tw.WriteLine(getImageTag(LineChartTests.lineColorAndLegendTest()));
                #endregion

                #region Fills
                tw.WriteLine("<h3>Fills</h3>");
                tw.WriteLine(getImageTag(FillsTests.multiLineAreaFillsTest()));
                tw.WriteLine(getImageTag(FillsTests.singleLineAreaFillTest()));
                tw.WriteLine(getImageTag(FillsTests.linearGradientFillTest()));
                tw.WriteLine("<br />");
                tw.WriteLine(getImageTag(FillsTests.linearStripesTest()));
                tw.WriteLine(getImageTag(FillsTests.solidFillTest()));
                #endregion

                #region Markers
                tw.WriteLine("<h3>Markers</h3>");
                tw.WriteLine(getImageTag(MarkersTests.rangeMarkersTest()));
                tw.WriteLine(getImageTag(MarkersTests.shapeMarkersTest()));

                #endregion

                #region Bar Charts
                tw.WriteLine("<h3>Bar Charts</h3>");
                tw.WriteLine(getImageTag(BarChartTests.horizontalStackedTest()));
                tw.WriteLine(getImageTag(BarChartTests.verticalStackedTest()));
                #endregion

                #region Pie Charts
                // 2D Pie Chart
                tw.WriteLine("<h3>Pie Charts</h3>");
                data = new int[] { 10, 20, 30, 40 };
                PieChart pieChart = new PieChart(300, 200);
                pieChart.SetData(data);
                pieChart.SetPieChartLabels(new string[] { "one", "two", "three", "four" });
                tw.WriteLine(getImageTag(pieChart.GetUrl()));

                // 3D Pie Chart
                data = new int[] { 10, 20, 30, 40 };
                pieChart = new PieChart(400, 200, PieChartType.ThreeD);
                pieChart.SetData(data);
                pieChart.SetPieChartLabels(new string[] { "one", "two", "three", "four" });
                pieChart.SetDatasetColors(new string[] { "0000FF" });
                tw.WriteLine(getImageTag(pieChart.GetUrl()));
                #endregion

                # region Venn Diagrams
                tw.WriteLine("<h3>Venn Diagrams</h3>");
                VennDiagram venn = new VennDiagram(150, 150);
                data = new int[] { 100, 80, 60, 30, 30, 30, 10 };
                venn.SetData(data);
                tw.WriteLine(getImageTag(venn.GetUrl()));
                #endregion

                # region Scatter Plots
                tw.WriteLine("<h3>Scatter Plots</h3>");
                intDataList.Clear();
                ScatterPlot scatter = new ScatterPlot(150, 150);
                data = new int[] { 10, 20, 30, 40, 50 };
                intDataList.Add(data);
                data = new int[] { 10, 20, 30, 40, 50 };
                intDataList.Add(data);
                scatter.SetData(intDataList);
                scatter.SetGrid(20, 50);
                tw.WriteLine(getImageTag(scatter.GetUrl()));
                #endregion
            }

            Process.Start(new FileInfo("test.html").FullName);
        }

        static string getImageTag(string url)
        {
            return "<img src=\"" + url + "\" />";
        }
    }
}
