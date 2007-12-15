using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleChartSharp
{
    public abstract class Chart
    {
        private const string API_BASE = "http://chart.apis.google.com/chart?";
        protected Queue<string> urlElements = new Queue<string>();

        private int width;
        private int height;
        private string data;
        private string title;
        private string titleColor;

        public Chart(int width, int height)
        {
            this.width = width;
            this.height = height;
        }

        public void SetWidth(int width)
        {
            this.width = width;
        }

        public void SetHeight(int height)
        {
            this.height = height;
        }

        #region Chart Data
        public void SetData(int[] data)
        {
            this.data = ChartData.Encode(data);
        }

        public void SetData(ICollection<int[]> data)
        {
            this.data = ChartData.Encode(data);
        }

        public void SetData(float[] data)
        {
            this.data = ChartData.Encode(data);
        }

        public void SetData(ICollection<float[]> data)
        {
            this.data = ChartData.Encode(data);
        }
        #endregion

        # region Chart Title
        public void SetTitle(string title)
        {
            string urlTitle = title.Replace(" ", "+");
            urlTitle = urlTitle.Replace(Environment.NewLine, "|");
            this.title = urlTitle;
        }

        public void SetTitle(string title, string hexColor)
        {
            SetTitle(title);
            this.titleColor = hexColor;
        }

        public void SetTitle(string title, string hexColor, int fontSize)
        {
            SetTitle(title);
            this.titleColor = hexColor + "," + fontSize;
        }
        #endregion

        public string GetUrl()
        {
            collectUrlElements();
            return generateUrlString();
        }

        public abstract string chartType();


        protected virtual void collectUrlElements()
        {
            urlElements.Clear();
            urlElements.Enqueue(String.Format("cht={0}", this.chartType()));
            urlElements.Enqueue(String.Format("chs={0}x{1}", this.width, this.height));
            urlElements.Enqueue(this.data);
            if (title != null)
            {
                urlElements.Enqueue(String.Format("chtt={0}", this.title));
            }
            if (titleColor != null)
            {
                urlElements.Enqueue(String.Format("chts={0}", this.titleColor));
            }
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
