using System;
using System.Collections.Generic;
using System.Text;

using googlechartsharp;

namespace Tests
{
    class FillsTests
    {
        public static string SingleLineAreaFill()
        {
            Chart chart = new Chart(ChartTypes.SimpleLine, 150, 100);
            chart.AddDataSet(new float[] { 0, 15, 25, 70, 85, 10, 25 });
            chart.SetEncoding(EncodingTypes.Text);
            chart.SetTitle(new ChartTitle("Single Line Fill"));
            chart.AddFill(new AreaFill("76A4FB", 0));

            return chart.GetUrlString();
        }

        public static string MultiLineAreaFill()
        {
            Chart chart = new Chart(ChartTypes.SimpleLine, 150, 100);
            chart.AddDataSet(new float[] { 50, 65, 90, 40, 85 });
            chart.AddDataSet(new float[] { 40, 55, 80, 30, 75 });
            chart.SetEncoding(EncodingTypes.Text);
            chart.SetTitle(new ChartTitle("MultiLine Area Fill"));
            chart.AddFill(new AreaFill("76A4FB", 0));
            chart.AddFill(new AreaFill("FF0000", 1));

            return chart.GetUrlString();
        }

        public static string SolidFillTest()
        {
            Chart chart = new Chart(ChartTypes.SimpleLine, 150, 100);
            chart.AddDataSet(new float[] { 25, 50, 95, 5, 15, 45 });
            chart.SetEncoding(EncodingTypes.Text);
            chart.SetTitle(new ChartTitle("Solid Fill Test"));
            chart.AddFill(new SolidFill(ChartFillTarget.Background, "EFEFEF"));
            return chart.GetUrlString();
        }
    }
}
