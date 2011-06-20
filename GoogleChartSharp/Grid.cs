using System;

namespace GoogleChartSharp
{
    public class Grid
    {
        public Grid()
        {
        }
        public Grid(float xStepSize, float yStepSize)
        {
            XStepSize = xStepSize;
            YStepSize = yStepSize;
        }
        public Grid(float xStepSize, float yStepSize, float lineSegmentLength, float blankSegmentLength)
        {
            XStepSize = xStepSize;
            YStepSize = yStepSize;
            LineSegmentLength = lineSegmentLength;
            BlankSegmentLength = blankSegmentLength;
        }

        public float? XStepSize { get; set; }
        public float? YStepSize { get; set; }
        public float? LineSegmentLength { get; set; }
        public float? BlankSegmentLength { get; set; }

        public string GetUrlElement()
        {
            if (XStepSize == null || YStepSize == null)
                return null;
            if (BlankSegmentLength != null && LineSegmentLength != null)
                return String.Format("chg={0},{1},{2},{3}", XStepSize, YStepSize, LineSegmentLength, BlankSegmentLength);
            return String.Format("chg={0},{1}", XStepSize, YStepSize);
        }
    }
}
