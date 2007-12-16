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
                // Test Line Chart
                data = new int[] { 40, 30, 20, 10, 0 };

                LineChart chart = new LineChart(150, 150);
                chart.SetTitle("Simple Line Chart", "FF0000");
                chart.AddSolidFill(ChartFillTarget.Background, "EFEFEF");
                chart.AddSolidFill(ChartFillTarget.ChartArea, "000000");
                chart.SetData(data);

                ChartAxis bottomAxis = new ChartAxis(ChartAxisType.Bottom);
                bottomAxis.SetRange(0, 500);
                bottomAxis.HexColor = "00FF00";
                bottomAxis.FontSize = 14;
                chart.AddAxis(bottomAxis);

                ChartAxis topAxis = new ChartAxis(ChartAxisType.Top);
                topAxis.AddLabel(new ChartAxisLabel("one", 0));
                topAxis.AddLabel(new ChartAxisLabel("two", 75));
                topAxis.AddLabel(new ChartAxisLabel("three", 100));
                chart.AddAxis(topAxis);

                chart.AddShapeMarker(new ShapeMarker(ShapeMarkerType.Arrow, "FF0000", 0, 1, 5));
                chart.AddShapeMarker(new ShapeMarker(ShapeMarkerType.VerticalLine, "00FF00", 0, 3, 2));
                tw.WriteLine(getImageTag(chart.GetUrl()));

                // Test XY Line Chart
                fDataList.Clear();
                fdata = new float[] { 0, 30, 60, 70, 90, 95, 100 };
                fDataList.Add(fdata);
                fdata = new float[] { 20, 30, 40, 50, 60, 70, 80 };
                fDataList.Add(fdata);
                fdata = new float[] { 10, 30, 40, 45, 52 };
                fDataList.Add(fdata);
                fdata = new float[] { 100, 90, 40, 20, 10 };
                fDataList.Add(fdata);
                LineChart xyLineChart = new LineChart(300, 150, LineChartType.MultiDataSet);
                xyLineChart.SetData(fDataList);
                xyLineChart.SetDatasetColors(new string[] { "FF0000", "00FF00" });
                xyLineChart.AddLineStyle(new LineStyle(3, 6, 3));
                xyLineChart.SetLegend(new string[] {"First", "Second"});
                xyLineChart.SetGrid(20, 50, 1, 0);
                xyLineChart.AddRangeMarker(new RangeMarker(RangeMarkerType.Horizontal, "E5ECF9", 0.2, 0.7));
                tw.WriteLine(getImageTag(xyLineChart.GetUrl()));
                #endregion

                #region Bar Charts
                // Horizontal Stacked Bar Chart
                tw.WriteLine("<h3>Bar Charts</h3>");
                data = new int[] { 0, 10, 20, 30, -1, 40 };
                BarChart barChart = new BarChart(150, 150, BarChartOrientation.Horizontal, BarChartStyle.Stacked);
                barChart.SetData(data);
                ChartAxis leftAxis = new ChartAxis(ChartAxisType.Left, new string[] { "a", "b", "c", "d", "e", "f" });
                barChart.AddAxis(leftAxis);
                tw.WriteLine(getImageTag(barChart.GetUrl()));

                // Vertical Stacked Bar Chart
                data = new int[] { 0, 10, 20, 30, -1, 40 };
                barChart = new BarChart(200, 150, BarChartOrientation.Vertical, BarChartStyle.Stacked);
                barChart.SetBarWidth(10);
                barChart.SetData(data);
                tw.WriteLine(getImageTag(barChart.GetUrl()));
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
