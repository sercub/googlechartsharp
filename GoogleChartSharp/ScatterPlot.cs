using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleChartSharp
{
    public class ScatterPlot : Chart
    {
        public ScatterPlot(int width, int height)
            : base(width, height)
        {

        }

        public override string urlChartType()
        {
            return "s";
        }

        public override ChartType getChartType()
        {
            return ChartType.ScatterPlot;
        }
    }
}
