using System;
using System.Collections.Generic;
using System.Text;

using googlechartsharp;

namespace Tests
{
    public class DataTests
    {
        public static string SimpleEncodingTest()
        {
            Chart chart = new Chart(ChartTypes.SimpleLine, 150, 100);
            chart.AddDataSet(new int[] { 5, 20, 15, 5, 35, 10 });
            chart.SetEncoding(EncodingTypes.Simple);
            chart.SetTitle(new ChartTitle("Simple Encoding"));
            return chart.GetUrlString();
        }

        public static string ExtendedEncodingTest()
        {
            Chart chart = new Chart(ChartTypes.SimpleLine, 150, 100);
            chart.AddDataSet(new int[] { 5, 20, 500, 4000, 35, 10 });
            chart.SetEncoding(EncodingTypes.Extended);
            chart.SetTitle(new ChartTitle("Extended Encoding"));
            return chart.GetUrlString();
        }

        public static string TextEncodingTest()
        {
            Chart chart = new Chart(ChartTypes.SimpleLine, 150, 100);
            chart.AddDataSet(new float[] {1.0f, 50.0f, 30.0f, 90.0f, 25.0f });
            chart.SetEncoding(EncodingTypes.Text);
            chart.SetTitle(new ChartTitle("Text Encoding", "CC00CC", 20));
            return chart.GetUrlString();
        }
    }
}
