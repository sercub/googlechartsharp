using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleChartSharp
{
    public enum LineChartType
    {
        SingleDataSet,
        MultiDataSet
    }

    public class LineChart : Chart
    {
        private LineChartType lineChartType = LineChartType.SingleDataSet;

        public LineChart(int width, int height) 
            : base(width, height)
        {
            this.lineChartType = LineChartType.SingleDataSet;
        }

        public LineChart(int width, int height, LineChartType lineChartType)
            : base(width, height)
        {
            this.lineChartType = lineChartType;
        }

        public override string chartType()
        {
            if (this.lineChartType == LineChartType.MultiDataSet)
            {
                return "lxy";
            }
            return "lc";
        }
    }
}
