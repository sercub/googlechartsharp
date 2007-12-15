using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleChartSharp
{
    public class PieChart : Chart
    {
        private bool is3D;

        public PieChart(int width, int height)
            : base(width, height)
        {

        }

        public PieChart(int width, int height, bool is3D)
            : base(width, height)
        {
            this.is3D = is3D;
        }

        public override string chartType()
        {
            if (is3D)
            {
                return "p3";
            }

            return "p";
        }
    }
}
