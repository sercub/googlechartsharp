using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleChartSharp
{
    public class ShapeMarker
    {
        ShapeMarkerType type;
        public ShapeMarkerType Type
        {
            get { return type; }
            set { type = value; }
        }

        string hexColor;
        /// <summary>
        /// an RRGGBB format hexadecimal number.
        /// </summary>
        public string HexColor
        {
            get { return hexColor; }
            set { hexColor = value; }
        }

        int datasetIndex;
        /// <summary>
        /// the index of the line on which to draw the marker. This is 0 for the first data set, 1 for the second and so on
        /// </summary>
        public int DatasetIndex
        {
            get { return datasetIndex; }
            set { datasetIndex = value; }
        }

        float dataPoint;
        /// <summary>
        /// a floating point value that specifies on which data point the marker will be drawn. This is 1 for the first data set, 2 for the second and so on. Specify a fraction to interpolate a marker between two points
        /// </summary>
        public float DataPoint
        {
            get { return dataPoint; }
            set { dataPoint = value; }
        }

        int size;
        /// <summary>
        /// the size of the marker in pixels
        /// </summary>
        public int Size
        {
            get { return size; }
            set { size = value; }
        }

        /// <summary>
        /// Create a shape marker for points on line charts and scatter plots
        /// </summary>
        /// <param name="markerType"></param>
        /// <param name="hexColor">RRGGBB format hexadecimal number</param>
        /// <param name="datasetIndex">the index of the line on which to draw the marker. This is 0 for the first data set, 1 for the second and so on</param>
        /// <param name="dataPoint">a floating point value that specifies on which data point the marker will be drawn. This is 1 for the first data set, 2 for the second and so on. Specify a fraction to interpolate a marker between two points.</param>
        /// <param name="size">the size of the marker in pixels</param>
        public ShapeMarker(ShapeMarkerType markerType, string hexColor, int datasetIndex, float dataPoint, int size)
        {
            this.type = markerType;
            this.hexColor = hexColor;
            this.datasetIndex = datasetIndex;
            this.dataPoint = dataPoint;
            this.size = size;
        }

        private string GetTypeUrlChar()
        {
            switch (this.type)
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

        public string GetUrlString()
        {
            string s = string.Empty;
            s += GetTypeUrlChar() + ",";
            s += hexColor + ",";
            s += datasetIndex + ",";
            s += dataPoint + ",";
            s += size.ToString();
            return s;
        }
    }

    public enum ShapeMarkerType
    {
        Arrow,
        Cross,
        Diamond,
        Circle,
        Square,
        VerticalLineToDataPoint,
        VerticalLine,
        HorizontalLine,
        XShape
    }
}
