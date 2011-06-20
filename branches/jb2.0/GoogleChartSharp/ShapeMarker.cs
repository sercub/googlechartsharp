using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleChartSharp
{
    public class ShapeMarker : Marker
    {
        public ShapeMarkerType Type { get; set; }

        /// <summary>
        /// an RRGGBB format hexadecimal number.
        /// </summary>
        public string Color { get; set; }

        /// <summary>
        /// the index of the line on which to draw the marker. This is 0 for the first data set, 1 for the second and so on
        /// </summary>
        public int DatasetIndex { get; set; }

        /// <summary>
        /// a floating point value that specifies on which data point the marker will be drawn. This is 1 for the first data set, 2 for the second and so on. Specify a fraction to interpolate a marker between two points
        /// </summary>
        public float DataPoint { get; set; }

        /// <summary>
        /// the size of the marker in pixels
        /// </summary>
        public int Size { get; set; }

        /// <summary>
        /// Create a shape marker for points on line charts and scatter plots
        /// </summary>
        /// <param name="markerType"></param>
        /// <param name="hexColor">RRGGBB format hexadecimal number</param>
        /// <param name="datasetIndex">the index of the line on which to draw the marker. This is 0 for the first data set, 1 for the second and so on</param>
        /// <param name="dataPoint">a floating point value that specifies on which data point the marker will be drawn. This is 1 for the first data set, 2 for the second and so on. Specify a fraction to interpolate a marker between two points.</param>
        /// <param name="size">the size of the marker in pixels</param>
        public ShapeMarker(ShapeMarkerType markerType, string color, int datasetIndex, float dataPoint, int size)
        {
            this.Type = markerType;
            this.Color = color;
            this.DatasetIndex = datasetIndex;
            this.DataPoint = dataPoint;
            this.Size = size;
        }

        internal string GetTypeUrlChar()
        {
            switch (this.Type)
            {
                case ShapeMarkerType.Arrow:
                    return "a";
                case ShapeMarkerType.Cross:
                    return "c";
                case ShapeMarkerType.Diamond:
                    return "d";
                case ShapeMarkerType.Circle:
                    return "o";
                case ShapeMarkerType.Square:
                    return "s";
                case ShapeMarkerType.VerticalLineToDataPoint:
                    return "v";
                case ShapeMarkerType.VerticalLine:
                    return "V";
                case ShapeMarkerType.HorizontalLine:
                    return "h";
                case ShapeMarkerType.XShape:
                    return "x";
            }
            return null;
        }

        //public override string GetUrlString()
        //{
        //    string s = string.Empty;
        //    s += GetTypeUrlChar() + ",";
        //    s += Color + ",";
        //    s += DatasetIndex + ",";
        //    s += DataPoint + ",";
        //    s += Size.ToString();
        //    return s;
        //}

        public override void AppendUrlPart(StringBuilder sb)
        {
            sb.Append(GetTypeUrlChar()).Append(",");
            sb.Append(Color).Append(",");
            sb.Append(DatasetIndex).Append(",");
            sb.Append(DataPoint).Append(",");
            sb.Append(Size.ToString());
        }
    }
}
