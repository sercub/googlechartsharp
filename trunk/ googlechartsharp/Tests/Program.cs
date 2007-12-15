using System;
using System.Collections.Generic;
using System.Text;
using GoogleChartSharp;
using System.Diagnostics;
using System.Drawing;

namespace Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            object[] test = new object[] { 0, 1, 2, 3, 4, 50 };
            object[] test2 = new object[] { 0, 1, 2, 3, 4, 50 };

            List<object[]> oList = new List<object[]>();
            oList.Add(test);
            oList.Add(test2);

            Console.WriteLine(ChartData.SimpleEncoding(test));
            Console.WriteLine(ChartData.SimpleEncoding(oList));

            object[] textTest = new object[] { 0.0, 1.0, 1.5, null, 5.6 };
            object[] textTest2 = new object[] { 99.9, 100.0, null, 45.6 };

            List<object[]> textList = new List<object[]>();
            textList.Add(textTest);
            textList.Add(textTest2);

            Console.WriteLine(ChartData.TextEncoding(textTest));
            Console.WriteLine(ChartData.TextEncoding(textList));

            object[] extendedTest = new object[] { 0, 25, 26, 51, 52, 61, 62, 63 };
            object[] extendedTest2 = new object[] { 64, 89, 90, 115, 116, 125, 126, 127 };
            object[] extendedTest3 = new object[] { 4032, 4057, 4058, 4083, 4084, 4093, 4094, 4095 };

            List<object[]> extendedList = new List<object[]>();
            extendedList.Add(extendedTest);
            extendedList.Add(extendedTest2);
            extendedList.Add(extendedTest3);

            Console.WriteLine(ChartData.ExtendedEncoding(extendedTest));
            Console.WriteLine(ChartData.ExtendedEncoding(extendedTest2));
            Console.WriteLine(ChartData.ExtendedEncoding(extendedTest3));
            Console.WriteLine(ChartData.ExtendedEncoding(extendedList));

            BarChart chart = new BarChart(300, 300, BarChartOrientation.Horizontal, BarChartStyle.Stacked);
            chart.SetBarWidth(10);
            chart.SetData(test);
            Process.Start(chart.GetUrl());
        }
    }
}
