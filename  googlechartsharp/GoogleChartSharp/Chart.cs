using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleChartSharp
{
    public enum ChartFillTarget
    {
        Background,
        ChartArea
    }

    public abstract class Chart
    {
        private const string API_BASE = "http://chart.apis.google.com/chart?";
        protected Queue<string> urlElements = new Queue<string>();

        private int width;
        private int height;
        private string data;
        private string title;
        private string titleColor;
        private string[] datasetColors;
        List<string> fills = new List<string>();
        List<string> legendStrings = new List<string>();
        List<ChartAxis> axises = new List<ChartAxis>();

        public Chart(int width, int height)
        {
            this.width = width;
            this.height = height;
        }

        #region Chart Dimensions
        public void SetWidth(int width)
        {
            this.width = width;
        }

        public void SetHeight(int height)
        {
            this.height = height;
        }
        #endregion

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

        #region Colors
        public void SetDatasetColors(string[] datasetColors)
        {
            this.datasetColors = datasetColors;
        }

        public void AddSolidFill(ChartFillTarget target, string color)
        {
            string fillString = string.Empty;
            switch (target)
            {
                case ChartFillTarget.Background:
                    fillString += "bg,";
                    break;
                case ChartFillTarget.ChartArea:
                    fillString += "c,";
                    break;
            }

            fillString += "s," + color;
            fills.Add(fillString);
        }
        #endregion

        #region Labels
        public void SetLegend(string[] strs)
        {
            foreach (string s in strs)
            {
                legendStrings.Add(s);
            }
        }

        public void AddAxis(ChartAxis axis)
        {
            axises.Add(axis);
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
            if (datasetColors != null)
            {
                string s = "chco=";
                foreach (string color in datasetColors)
                {
                    s += color + ",";
                }
                urlElements.Enqueue(s.TrimEnd(",".ToCharArray()));
            }
            if (fills.Count > 0)
            {
                string s = "chf=";
                foreach (string fillString in fills)
                {
                    s += fillString + "|";
                }
                urlElements.Enqueue(s.TrimEnd("|".ToCharArray()));
            }
            if (legendStrings.Count > 0)
            {
                string s = "chdl=";
                foreach (string str in legendStrings)
                {
                    s += str + "|";
                }
                urlElements.Enqueue(s.TrimEnd("|".ToCharArray()));
            }
            if (axises.Count > 0)
            {
                string axisTypes = "chxt=";
                string axisLabels = "chxl=";
                string axisLabelPositions = "chxp=";
                string axisRange = "chxr=";

                int axisIndex = 0;
                foreach (ChartAxis axis in axises)
                {
                    axisTypes += axis.urlAxisType() + ",";
                    axisLabels += axisIndex.ToString() + ":" + axis.urlLabels();
                    string labelPositions = axis.urlLabelPositions();
                    if (! String.IsNullOrEmpty(labelPositions))
                    {
                        axisLabelPositions += axisIndex.ToString() + "," + labelPositions + "|";
                    }
                    string axisRangeStr = axis.urlRange();
                    if (!String.IsNullOrEmpty(axisRangeStr))
                    {
                        axisRange += axisIndex.ToString() + "," + axisRangeStr + "|";
                    }
                    axisIndex++;
                }
                axisTypes = axisTypes.TrimEnd(",".ToCharArray());
                axisLabels = axisLabels.TrimEnd("|".ToCharArray());
                axisLabelPositions = axisLabelPositions.TrimEnd("|".ToCharArray());
                axisRange = axisRange.TrimEnd("|".ToCharArray());

                urlElements.Enqueue(axisTypes);
                urlElements.Enqueue(axisLabels);
                urlElements.Enqueue(axisLabelPositions);
                urlElements.Enqueue(axisRange);
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
