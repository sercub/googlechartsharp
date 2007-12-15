using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleChartSharp
{
    public abstract class Chart
    {

        private const string API_BASE = "http://chart.apis.google.com/chart?";
        private Queue<string> urlElements = new Queue<string>();

        #region Properties

        private int height;
        public int Height
        {
            get { return height; }
            set { height = value; }
        }

        private int width;
        public int Width
        {
            get { return width; }
            set { width = value; }
        }

        public string Url
        {
            get 
            {
                collectUrlElements();
                return generateUrlString(); 
            }
        }

        private string data;
        public string Data
        {
            get { return data; }
        }

        #endregion

        public Chart(int width, int height)
        {
            this.width = width;
            this.height = height;
        }

        public void SetData(object[] data)
        {
            this.data = ChartData.Encode(data);
        }

        public void SetData(ICollection<object[]> data)
        {
            this.data = ChartData.Encode(data);
        }

        public abstract string chartType();

        private void collectUrlElements()
        {
            urlElements.Clear();
            urlElements.Enqueue(this.chartType());
            urlElements.Enqueue(String.Format("chs={0}x{1}", this.Width, this.Height));
            urlElements.Enqueue(this.data);
        }

        private string generateUrlString()
        {
            string url = string.Empty;

            url += Chart.API_BASE;
            url += urlElements.Dequeue();

            while (urlElements.Count > 0)
            {
                url += "&" + urlElements.Dequeue();
            }

            return url;
        }
    }
}
