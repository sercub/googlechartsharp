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
                tw.WriteLine(imageTag(DataTests.SimpleEncodingTest()));
                tw.WriteLine(imageTag(DataTests.ExtendedEncodingTest()));
                tw.WriteLine(imageTag(DataTests.TextEncodingTest()));
            }

            Process.Start(new FileInfo("test.html").FullName);
        }

        static string imageTag(string url)
        {
            return String.Format("<img src=\"{0}\" />", url);
        }
    }
}
