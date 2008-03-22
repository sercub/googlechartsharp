using System;
using System.Collections.Generic;
using System.Text;

using googlechartsharp;

namespace Tests
{
    public class LineChartTests
    {
        public static string SimpleLineTest()
        {
            Chart chart = new Chart(ChartTypes.SimpleLine, 150, 100);
            chart.AddDataSet(new int[] { 10, 25, 15, 5, 30 });
            chart.AddDataSet(new int[] { 5, 15, 60, 30, 15 });
            chart.SetEncoding(EncodingTypes.Simple);
            chart.SetTitle(new ChartTitle("Simple Line Test"));
            chart.AddDataSetColor("FF0000");
            chart.AddDataSetColor("00FF00");
            return chart.GetUrlString();
        }

        public static string PairLineTest()
        {
            Chart chart = new Chart(ChartTypes.PairLine, 150, 100);
            chart.AddDataSet(new float[] { 20f, 40f, 60f, 80f, 100f });
            chart.AddDataSet(new float[] { 0f, 10f, 80f, 50f, 90f });
            chart.SetEncoding(EncodingTypes.Text);
            chart.SetTitle(new ChartTitle("Pair Line Test"));
            return chart.GetUrlString();
        }

        public static string SparklineTest()
        {
            Chart chart = new Chart(ChartTypes.SparkLine, 150, 100);
            chart.AddDataSet(new int[] { 10, 25, 15, 5, 30 });
            chart.SetEncoding(EncodingTypes.Simple);
            chart.SetTitle(new ChartTitle("Spark Line Test"));
            return chart.GetUrlString();
        }
    }
}
