using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleChartSharp
{
    public class VennDiagram : Chart
    {
        public VennDiagram(int width, int height)
            : base(width, height)
        {
        }

        protected override string urlChartType()
        {
            return "v";
        }

        protected override ChartType getChartType()
        {
            return ChartType.VennDiagram;
        }
    }
}
