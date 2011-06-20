using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoogleChartSharp
{
    /// <summary>
    /// Base type for all charts.
    /// </summary>
    public abstract class Chart
    {
        private const string API_BASE = "http://chart.apis.google.com/chart?";
        private const string SECURE_API_BASE = "https://chart.googleapis.com/chart?";

        /// <summary>
        /// Create a chart
        /// </summary>
        /// <param name="width">width in pixels</param>
        /// <param name="height">height in pixels</param>
        protected Chart(int width, int height)
        {
            Width = width;
            Height = height;
        }

        private int _width;

        /// <summary>
        /// Chart width in pixels.
        /// </summary>
        public int Width
        {
            get { return _width; }
            set 
            { 
                _width = value;
                if(Width * Height > 300000)
                    throw new InvalidOperationException("The total number of pixels in the chart can not be > 300000");
            }
        }

        private int _height;

        /// <summary>
        /// Chart height in pixels.
        /// </summary>
        public int Height
        {
            get { return _height; }
            set 
            { 
                _height = value; 
                                if(Width * Height > 300000)
                    throw new InvalidOperationException("The total number of pixels in the chart can not be > 300000");
            }
        }

        public Title Title { get; set; }

        public IEnumerable<string> DatasetColors { get; set; }

        public Fills Fills { get; set; }

        public virtual Legend Legend { get; set; }
        public virtual Axes Axes { get; set; }

        public Grid Grid
        {
            get { return _grid; }
            set
            {
                if (!(ChartType == ChartType.LineChart || ChartType == ChartType.ScatterPlot))
                {
                    throw new InvalidFeatureForChartTypeException();
                }
                _grid = value;
            }
        }


        private Grid _grid;


        public IEnumerable<Marker> Markers { get; set; }


        public ChartData Data { get; set; }


        /// <summary>
        /// Return the chart api url for this chart
        /// </summary>
        /// <returns></returns>
        public string GetUrl()
        {
            
            return generateUrlString(collectUrlElements());
        }

        /// <summary>
        /// Returns the api chart identifier for the chart
        /// </summary>
        /// <value></value>
        protected abstract string UrlChartType { get; }

        protected abstract ChartType ChartType { get; }

        /// <summary>
        /// Collect all the elements that will be used in the chart url
        /// </summary>
        protected virtual List<string> collectUrlElements()
        {
            var urlElements = new List<String>();
            urlElements.Clear();
            urlElements.Add(String.Format("cht={0}", UrlChartType));
            urlElements.Add(String.Format("chs={0}x{1}", Width, Height));
            urlElements.Add(Data.GetUrlElement());

            // chart title
            if (Title != null)
            {
                urlElements.AddRange(Title.GetUrlElements());
            }


            // dataset colors
            if (DatasetColors != null)
            {
                urlElements.Add("chco="+String.Join(",", DatasetColors.ToArray()));
            }

            if (Fills != null && Fills.Count > 0)
            {
                urlElements.Add(Fills.GetUrlElement());
            }


            if (Legend != null && Legend.Count > 0)
            {
                urlElements.Add(Legend.GetUrlElement());
            }


            // Axes
            if (Axes != null && Axes.Count > 0)
            {
                foreach (string item in Axes.GetUrlElements())
                {
                    urlElements.Add(item);
                }
            }

            // Grid
            if (Grid != null)
            {
                urlElements.Add(Grid.GetUrlElement());
            }

            // Markers
            
            if(Markers != null)
            {
                StringBuilder sb = new StringBuilder("chm=");
                int count = 0;
                foreach(var marker in Markers)
                {
                    if (count > 0)
                        sb.Append("|");

                    marker.AppendUrlPart(sb);
                    count++;
                }
                if(count > 0)
                    urlElements.Add(sb.ToString());
            }
            return urlElements;

        }

        private string generateUrlString(List<string> urlElements)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(API_BASE);
            int count = 0;
            foreach(var part in urlElements)
            {
                if (count > 0)
                    sb.Append("&");
                sb.Append(part);
                count++;
            }
            return sb.ToString();
        }
    }
}