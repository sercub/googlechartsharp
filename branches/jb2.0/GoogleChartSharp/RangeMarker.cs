using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleChartSharp
{
    public class RangeMarker : Marker
    {
        public RangeMarkerType Type { get; set; }

        /// <summary>
        /// an RRGGBB format hexadecimal number.
        /// </summary>
        public string Color { get; set; }

        /// <summary>
        /// for horizontal range markers is the position on the y-axis at which the range starts where 0.00 is the bottom and 1.00 is the top.
        /// for vertical range markers is the position on the x-axis at which the range starts where 0.00 is the left and 1.00 is the right.
        /// </summary>
        public double StartPoint { get; set; }

        /// <summary>
        /// for horizontal range markers is the position on the y-axis at which the range ends where 0.00 is the bottom and 1.00 is the top.
        /// for vertical range markers is the position on the x-axis at which the range ends where 0.00 is the left and 1.00 is the right.
        /// </summary>
        public double EndPoint { get; set; }

        /// <summary>
        /// Create a range marker for line charts and scatter plots
        /// </summary>
        /// <param name="rangeMarkerType"></param>
        /// <param name="color">an RRGGBB format hexadecimal number</param>
        /// <param name="startPoint">Must be between 0.0 and 1.0. 0.0 is axis start, 1.0 is axis end.</param>
        /// <param name="endPoint">Must be between 0.0 and 1.0. 0.0 is axis start, 1.0 is axis end.</param>
        public RangeMarker(RangeMarkerType rangeMarkerType, string color, double startPoint, double endPoint)
        {
            this.Type = rangeMarkerType;
            this.Color = color;
            this.StartPoint = startPoint;
            this.EndPoint = endPoint;
        }

        private string GetTypeUrlChar()
        {
            switch (this.Type)
            {
                case RangeMarkerType.Horizontal:
                    return "r";
                case RangeMarkerType.Vertical:
                    return "R";
            }
            return null;
        }

        //public override string GetUrlString()
        //{
        //    string s = string.Empty;
        //    s += GetTypeUrlChar() + ",";
        //    s += Color + ",";
        //    // this value is ignored - but has to be a number
        //    s += "0" + ",";
        //    s += StartPoint.ToString() + ",";
        //    s += EndPoint.ToString();
        //    return s;
        //}

        public override void AppendUrlPart(StringBuilder sb)
        {
            sb.Append(GetTypeUrlChar()).Append(",");
            sb.Append(Color).Append(",");
            // this value is ignored - but has to be a number
            sb.Append("0").Append(",");
            sb.Append(StartPoint).Append(",");
            sb.Append(EndPoint);
        }
    }
}
