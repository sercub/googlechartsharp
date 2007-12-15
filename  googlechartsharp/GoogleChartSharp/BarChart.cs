using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleChartSharp
{
    public enum BarChartOrientation
    {
        Vertical,
        Horizontal
    }

    public enum BarChartStyle
    {
        Stacked,
        Grouped
    }

    public class BarChart : Chart
    {
        BarChartOrientation orientation;
        BarChartStyle style;
        int barWidth;

        public BarChart(int width, int height, BarChartOrientation orientation, BarChartStyle style)
            : base(width, height)
        {
            this.orientation = orientation;
            this.style = style;
        }

        public override string chartType()
        {
            char orientationChar = this.orientation == BarChartOrientation.Horizontal ? 'h' : 'v';
            char styleChar = this.style == BarChartStyle.Stacked ? 's' : 'g';

            return String.Format("b{0}{1}", orientationChar, styleChar);
        }

        public void SetBarWidth(int width)
        {
            this.barWidth = width;
        }

        protected override void collectUrlElements()
        {
            base.collectUrlElements();
            if (this.barWidth != 0)
            {
                base.urlElements.Enqueue(String.Format("chbh={0}", this.barWidth));
            }
        }
    }
}
