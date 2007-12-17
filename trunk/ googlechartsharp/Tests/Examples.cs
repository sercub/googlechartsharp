using System;
using System.Collections.Generic;
using System.Text;
using GoogleChartSharp;

namespace Tests
{
    class Examples
    {
        public static string simpleAxis()
        {
            ChartAxis bottomAxis = new ChartAxis(ChartAxisType.Bottom);

            int[] line1 = new int[] { 5, 10, 50, 34, 10, 25 };
            LineChart lineChart = new LineChart(150, 150);

            lineChart.AddAxis(bottomAxis);
            lineChart.SetData(line1);
            return lineChart.GetUrl();
        }

        public static string axisLabels()
        {
            ChartAxis leftAxis = new ChartAxis(ChartAxisType.Left, new string[] { "one", "two", "three" });
            ChartAxis bottomAxis = new ChartAxis(ChartAxisType.Bottom);
            bottomAxis.AddLabel(new ChartAxisLabel("a", 0));
            bottomAxis.AddLabel(new ChartAxisLabel("b", 10));
            bottomAxis.AddLabel(new ChartAxisLabel("c", 50));
            bottomAxis.AddLabel(new ChartAxisLabel("d", 100));

            int[] line1 = new int[] { 5, 10, 50, 34, 10, 25 };
            LineChart lineChart = new LineChart(150, 150);

            lineChart.AddAxis(leftAxis);
            lineChart.AddAxis(bottomAxis);
            lineChart.SetData(line1);
            return lineChart.GetUrl();
        }

        public static string axisRange()
        {
            ChartAxis bottomAxis = new ChartAxis(ChartAxisType.Bottom);
            bottomAxis.SetRange(0, 50);

            int[] line1 = new int[] { 5, 10, 50, 34, 10, 25 };
            LineChart lineChart = new LineChart(150, 150);

            lineChart.AddAxis(bottomAxis);
            lineChart.SetData(line1);
            return lineChart.GetUrl();
        }

        public static string stackingAxes()
        {
            ChartAxis bottomAxis = new ChartAxis(ChartAxisType.Bottom);
            ChartAxis bottomAxis2 = new ChartAxis(ChartAxisType.Bottom);
            bottomAxis2.SetRange(0, 50);

            int[] line1 = new int[] { 5, 10, 50, 34, 10, 25 };
            LineChart lineChart = new LineChart(150, 150);

            lineChart.AddAxis(bottomAxis);
            lineChart.AddAxis(bottomAxis2);

            lineChart.SetData(line1);
            return lineChart.GetUrl();
        }
    }
}
