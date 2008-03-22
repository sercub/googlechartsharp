using System;
using System.Collections.Generic;
using System.Text;

namespace googlechartsharp
{
    public class Chart
    {
        private readonly string apiBase = "http://chart.apis.google.com/chart?";

        private ChartTypes chartType;
        private int width;
        private int height;
        private EncodingTypes encodingType;
        private List<DataSet> dataSets = new List<DataSet>();
        private ChartTitle chartTitle = null;
        private List<string> dataSetColors = new List<string>();

        public Chart(ChartTypes chartType, int width, int height)
        {
            this.chartType = chartType;
            this.width = width;
            this.height = height;
        }

        public void AddDataSet(int[] data)
        {
            this.dataSets.Add(new DataSet(data));
        }

        public void AddDataSet(float[] data)
        {
            this.dataSets.Add(new DataSet(data));
        }

        public void SetEncoding(EncodingTypes encodingType)
        {
            this.encodingType = encodingType;
        }

        public void SetTitle(ChartTitle chartTitle)
        {
            this.chartTitle = chartTitle;
        }

        public void AddDataSetColor(string color)
        {
            this.dataSetColors.Add(color);
        }

        public string GetUrlString()
        {
            Queue<string> pieces = CollectUrlPieces();
            string url = this.apiBase;

            url += pieces.Dequeue();
            while (pieces.Count > 0)
            {
                url += "&" + pieces.Dequeue();
            }
            
            return url;
        }

        private Queue<string> CollectUrlPieces()
        {
            Queue<string> pieces = new Queue<string>();

            pieces.Enqueue(UrlStrings.ChartType(this.chartType));
            pieces.Enqueue(UrlStrings.ChartSize(this.width, this.height));
            pieces.Enqueue(UrlStrings.ChartData(this.encodingType, this.dataSets));
            pieces.Enqueue(UrlStrings.ChartTitle(this.chartTitle));
            pieces.Enqueue(UrlStrings.DataSetColors(this.dataSetColors));

            return pieces;
        }
    }

    public enum ChartTypes
    {
        SimpleLine,
        PairLine,
        SparkLine,
        HorizontalStackedBar,
        VerticalStackedBar,
        HorizontalGroupedBar,
        VerticalGroupedBar
    }
}
