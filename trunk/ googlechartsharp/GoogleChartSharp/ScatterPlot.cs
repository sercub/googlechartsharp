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

        protected override string urlChartType()
        {
            return "s";
        }

        protected override ChartType getChartType()
        {
            return ChartType.ScatterPlot;
        }
    }
}
