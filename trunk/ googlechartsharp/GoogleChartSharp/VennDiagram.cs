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

        public override string chartType()
        {
            return "v";
        }
    }
}
