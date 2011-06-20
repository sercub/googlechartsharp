using System;
using System.Text;

namespace GoogleChartSharp
{
    /// <summary>
    /// Fill the area between / under lines
    /// </summary>
    public class FillArea : Marker
    {
        public FillAreaType Type { get; set; }

        /// <summary>
        /// Create a fill area between lines for use on a line chart.
        /// </summary>
        /// <param name="color">an RRGGBB format hexadecimal number</param>
        /// <param name="startLineIndex">line indexes are determined by the order in which datasets are added. The first set is index 0, then index 1 etc</param>
        /// <param name="endLineIndex">line indexes are determined by the order in which datasets are added. The first set is index 0, then index 1 etc</param>
        public FillArea(string color, int startLineIndex, int endLineIndex)
        {
            Type = FillAreaType.MultiLine;
            Color = color;
            StartLineIndex = startLineIndex;
            EndLineIndex = endLineIndex;
        }

        /// <summary>
        /// Fill all the area under a line
        /// </summary>
        /// <param name="color">an RRGGBB format hexadecimal number</param>
        /// <param name="lineIndex">line indexes are determined by the order in which datasets are added. The first set is index 0, then index 1 etc</param>
        public FillArea(string color, int lineIndex)
        {
            Type = FillAreaType.SingleLine;
            Color = color;
            StartLineIndex = lineIndex;
        }

        /// <summary>
        /// an RRGGBB format hexadecimal number
        /// </summary>
        public string Color { get; set; }

        /// <summary>
        /// the index of the line at which the fill starts. This is determined by the order in which data sets are added. The first data set specified has an index of zero (0), the second 1, and so on.
        /// </summary>
        public int StartLineIndex { get; set; }

        /// <summary>
        /// the index of the line at which the fill ends. This is determined by the order in which data sets are added. The first data set specified has an index of zero (0), the second 1, and so on.
        /// </summary>
        public int EndLineIndex { get; set; }

        //public override string GetUrlString()
        //{
        //    string s = string.Empty;

        //    if (Type == FillAreaType.MultiLine)
        //    {
        //        s += "b" + ",";
        //        s += Color + ",";
        //        s += StartLineIndex + ",";
        //        s += EndLineIndex + ",";
        //        s += "0"; // ignored
        //    }
        //    else if (Type == FillAreaType.SingleLine)
        //    {
        //        s += "B" + ",";
        //        s += Color + ",";
        //        s += StartLineIndex + ",";
        //        s += "0" + ","; // ignored
        //        s += "0"; // ignored
        //    }

        //    return s;
        //}

        public override void AppendUrlPart(StringBuilder sb)
        {
            if (Type == FillAreaType.MultiLine)
            {
                sb.Append("b" + ",");
                sb.Append(Color + ",");
                sb.Append(StartLineIndex + ",");
                sb.Append(EndLineIndex + ",");
                sb.Append("0"); // ignored
            }
            else if (Type == FillAreaType.SingleLine)
            {
                sb.Append("B" + ",");
                sb.Append(Color + ",");
                sb.Append(StartLineIndex + ",");
                sb.Append("0" + ","); // ignored
                sb.Append("0"); // ignored
            }
        }
    }
}