using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoogleChartSharp
{
    /// <summary>
    /// Chart Axis
    /// </summary>
    public class Axis
    {
        #region Properties

        /// <summary>
        /// an RRGGBB format hexadecimal number
        /// </summary>
        public string Color { get; set; }

        /// <summary>
        /// optional if used this specifies the size in pixels
        /// </summary>
        public int FontSize { get; set; }

        /// <summary>
        /// By default: x-axis labels are centered, left y-axis labels are right aligned, right y-axis labels are left aligned
        /// </summary>
        public AxisAlignmentType Alignment { get; set; }

        /// <summary>
        /// The location of the axis in the final chart. 
        /// </summary>
        public AxisLocation Location { get; set; }

        public AxisRange Range { get; set; }

        public IEnumerable<AxisLabel> Labels { get; set; }

        #endregion

        /// <summary>
        /// Create an axis, default is range 0 - 100 evenly spaced. You can create multiple axes of the same ChartAxisType.
        /// </summary>
        /// <param name="axisLocation">Axis position</param>
        public Axis(AxisLocation axisLocation)
        {
            Labels = new List<AxisLabel>();
            Alignment = AxisAlignmentType.Unset;
            FontSize = -1;
            this.Location = axisLocation;
        }
        /// <summary>
        /// Default constructor
        /// </summary>
        public Axis()
        {
            Labels = new List<AxisLabel>();
            Alignment = AxisAlignmentType.Unset;
            FontSize = -1;
            Location = AxisLocation.Left;
        }




        internal string UrlAxisStyle()
        {
            if (Color == null)
            {
                return null;
            }
            string result = Color + ",";
            if (FontSize != -1)
            {
                result += FontSize.ToString() + ",";
            }

            if (Alignment != AxisAlignmentType.Unset)
            {
                switch (Alignment)
                {
                    case AxisAlignmentType.Left:
                        result += "-1,";
                        break;
                    case AxisAlignmentType.Centered:
                        result += "0,";
                        break;
                    case AxisAlignmentType.Right:
                        result += "1,";
                        break;
                }
            }

            return result.TrimEnd(",".ToCharArray());
        }

        internal string UrlAxisType()
        {
            switch (Location)
            {
                case AxisLocation.Bottom:
                    return "x";

                case AxisLocation.Top:
                    return "t";

                case AxisLocation.Left:
                    return "y";

                case AxisLocation.Right:
                    return "r";
            }

            throw new InvalidOperationException("AxisType is undefined.");
        }


        internal string UrlLabelPositions()
        {
            string result = Labels.Where(x => x.Position.HasValue).Aggregate(string.Empty, (current, axisLabel) => current + (axisLabel.Position + ","));
            return result.TrimEnd(",".ToCharArray());
        }

        internal string UrlRange()
        {
            if (Range != null)
            {
                return Range.GetUrlPart();
            }
            return null;
        }

        public void AppendUrlLabels(int index, StringBuilder sb)
        {
            sb.Append(index)
                .Append(":");
            Labels.Aggregate(sb, (b, x) => b.Append("|").Append(x.Text)).Append("|");
        }
    }
}
