using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleChartSharp
{
    public class LineChart : Chart
    {
        public LineChart(int width, int height) : base(width, height)
        {
            
        }

        public override string chartType()
        {
            return "cht=lc";
        }
    }
}
