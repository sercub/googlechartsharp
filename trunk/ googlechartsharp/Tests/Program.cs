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
            int[] data = new int[] { 0, 1, 2, 3, 4, 5, -1, 6 };
            LineChart chart = new LineChart(300, 300);
            chart.SetData(data);
            Process.Start(chart.GetUrl());
        }
    }
}
