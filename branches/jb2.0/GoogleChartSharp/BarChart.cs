using System;
using System.Collections.Generic;

namespace GoogleChartSharp
{
    /// <summary>
    /// Bar Chart
    /// </summary>
    public class BarChart : Chart
    {
        /// <summary>
        /// Create a bar chart
        /// </summary>
        /// <param name="width">Width in pixels</param>
        /// <param name="height">Height in pixels</param>
        /// <param name="orientation">The orientation of the bars.</param>
        /// <param name="style">Bar chart style when using multiple data sets</param>
        public BarChart(int width, int height, BarChartOrientation orientation, BarChartStyle style)
            : base(width, height)
        {
            ZeroLine = 0;
            Orientation = orientation;
            Style = style;
        }

        /// <summary>
        /// Return the chart identifier used in the chart url.
        /// </summary>
        /// <value></value>
        protected override string UrlChartType
        {
            get
            {
                char orientationChar = Orientation == BarChartOrientation.Horizontal ? 'h' : 'v';
                char styleChar = Style == BarChartStyle.Stacked ? 's' : 'g';

                return String.Format("b{0}{1}", orientationChar, styleChar);
            }
        }

        /// <summary>
        /// Return the chart type for this chart
        /// </summary>
        /// <value></value>
        protected override ChartType ChartType
        {
            get { return ChartType.BarChart; }
        }

        public BarChartOrientation Orientation { get; set; }

        public BarChartStyle Style { get; set; }

        public int BarWidth { get; set; }

        public double ZeroLine { get; set; }


        /// <summary>
        /// Collect all the elements that will make up the chart url.
        /// </summary>
        protected override List<string> collectUrlElements()
        {
            var res = base.collectUrlElements();

            if (BarWidth != 0)
            {
                res.Add(String.Format("chbh={0}", BarWidth));
            }
            if (ZeroLine != 0)
            {
                res.Add(String.Format("chp={0}", ZeroLine));
            }
            return res;
        }
    }
}