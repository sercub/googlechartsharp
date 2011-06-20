using System.Collections.Generic;
using System.Linq;

namespace GoogleChartSharp
{
    /// <summary>A line chart with multiple sets of data</summary>
    public class MultiLineChart : LineChart
    {
        /// <summary>
        /// Create a multi line chart with one line per dataset. Points are evenly spaced along the x-axis.
        /// </summary>
        /// <param name="width">width in pixels</param>
        /// <param name="height">height in pixels</param>
        public MultiLineChart(int width, int height) : base(width, height)
        {
        }

        protected override string UrlChartType
        {
            get
            {
                return "lxy";
            }
        }
    }
    /// <summary>A Line Chart with a single set of data </summary>
    public class LineChart : Chart
    {
        /// <summary>
        /// Create a line chart with one line per dataset. Points are evenly spaced along the x-axis.
        /// </summary>
        /// <param name="width">width in pixels</param>
        /// <param name="height">height in pixels</param>
        public LineChart(int width, int height)
            : base(width, height)
        {
            LineStyles = new List<LineStyle>();
        }

        protected override string UrlChartType
        {
            get
            {
                return "lc";
            }
        }

        protected override ChartType ChartType
        {
            get { return ChartType.LineChart; }
        }


        public IEnumerable<LineStyle> LineStyles { get; set; }

        protected override List<string> collectUrlElements()
        {
            List<string> res = base.collectUrlElements();
            if (LineStyles.Count() > 0)
            {
                string s = "chls=";
                foreach (LineStyle lineStyle in LineStyles)
                {
                    s += lineStyle.LineThickness + ",";
                    s += lineStyle.LengthOfSegment + ",";
                    s += lineStyle.LengthOfBlankSegment + "|";
                }
                res.Add(s.TrimEnd("|".ToCharArray()));
            }
            return res;
        }
    }
}