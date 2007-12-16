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
        private List<LineStyle> lineStyles = new List<LineStyle>();

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

        public override string urlChartType()
        {
            if (this.lineChartType == LineChartType.MultiDataSet)
            {
                return "lxy";
            }
            return "lc";
        }

        public void AddLineStyle(LineStyle lineStyle)
        {
            lineStyles.Add(lineStyle);
        }

        protected override void collectUrlElements()
        {
            base.collectUrlElements();
            if (lineStyles.Count > 0)
            {
                string s = "chls=";
                foreach (LineStyle lineStyle in lineStyles)
                {
                    s += lineStyle.LineThickness.ToString() + ",";
                    s += lineStyle.LengthOfSegment.ToString() + ",";
                    s += lineStyle.LengthOfBlankSegment.ToString() + "|";
                }
                urlElements.Enqueue(s.TrimEnd("|".ToCharArray()));
            }
        }

        public override ChartType getChartType()
        {
            return ChartType.LineChart;
        }
    }

    public class LineStyle
    {
        private float lineThickness;
        public float LineThickness
        {
            get { return lineThickness; }
            set { lineThickness = value; }
        }

        private float lengthOfSegment;
        public float LengthOfSegment
        {
            get { return lengthOfSegment; }
            set { lengthOfSegment = value; }
        }

        private float lengthOfBlankSegment;
        public float LengthOfBlankSegment
        {
            get { return lengthOfBlankSegment; }
            set { lengthOfBlankSegment = value; }
        }

        public LineStyle()
        {

        }

        public LineStyle(float lineThickness, float lengthOfSegment, float lengthOfBlankSegment)
        {
            this.lineThickness = lineThickness;
            this.lengthOfSegment = lengthOfSegment;
            this.lengthOfBlankSegment = lengthOfBlankSegment;
        }
    }
}
