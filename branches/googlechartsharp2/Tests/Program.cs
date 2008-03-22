using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

using googlechartsharp;

namespace Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            using (TextWriter tw = new StreamWriter(("test.html")))
            {
                tw.WriteLine("<h3>Data Encoding</h3>");
                tw.WriteLine(imageTag(DataTests.SimpleEncodingTest()));
                tw.WriteLine(imageTag(DataTests.ExtendedEncodingTest()));
                tw.WriteLine(imageTag(DataTests.TextEncodingTest()));

                tw.WriteLine("<br />");

                tw.WriteLine("<h3>Line Charts</h3>");
                tw.WriteLine(imageTag(LineChartTests.SimpleLineTest()));
                tw.WriteLine(imageTag(LineChartTests.PairLineTest()));
                tw.WriteLine(imageTag(LineChartTests.SparklineTest()));

                tw.WriteLine();

                tw.WriteLine("<h3>Fills</h3>");
                tw.WriteLine(imageTag(FillsTests.SingleLineAreaFill()));
                tw.WriteLine(imageTag(FillsTests.MultiLineAreaFill()));
                tw.WriteLine(imageTag(FillsTests.SolidFillTest()));
            }

            Process.Start(new FileInfo("test.html").FullName);
        }

        static string imageTag(string url)
        {
            return String.Format("<img src=\"{0}\" />", url);
        }
    }
}
