using System;
using System.Collections.Generic;
using System.Text;

namespace googlechartsharp
{
    /// <summary>
    /// Fill the area between / under lines
    /// </summary>
    public class AreaFill
    {
        private AreaFillType type;
        private string color;
        private int startLineIndex;
        private int endLineIndex;


        /// <summary>
        /// Create a fill area between lines for use on a line chart.
        /// </summary>
        /// <param name="color">an RRGGBB format hexadecimal number</param>
        /// <param name="startLineIndex">line indexes are determined by the order in which datasets are added. The first set is index 0, then index 1 etc</param>
        /// <param name="endLineIndex">line indexes are determined by the order in which datasets are added. The first set is index 0, then index 1 etc</param>
        public AreaFill(string color, int startLineIndex, int endLineIndex)
        {
            this.type = AreaFillType.MultiLine;
            this.color = color;
            this.startLineIndex = startLineIndex;
            this.endLineIndex = endLineIndex;
        }

        /// <summary>
        /// Fill all the area under a line
        /// </summary>
        /// <param name="color">an RRGGBB format hexadecimal number</param>
        /// <param name="lineIndex">line indexes are determined by the order in which datasets are added. The first set is index 0, then index 1 etc</param>
        public AreaFill(string color, int lineIndex)
        {
            this.type = AreaFillType.SingleLine;
            this.color = color;
            this.startLineIndex = lineIndex;
        }

        public override string ToString()
        {
            string formatLetter = string.Empty;

            switch (this.type)
            {
                case AreaFillType.SingleLine:
                    formatLetter = "B";
                    break;
                case AreaFillType.MultiLine:
                    formatLetter = "b";
                    break;
            }

            return String.Format("{0},{1},{2},{3},{4}", formatLetter, this.color, this.startLineIndex.ToString(), 
                this.endLineIndex.ToString(), "0");
        }

        public static string GetDelimiter()
        {
            return "|";
        }
    }

    /// <summary>
    /// Specify area fill behavior
    /// </summary>
    public enum AreaFillType
    {
        /// <summary>
        /// All area under the line will be filled
        /// </summary>
        SingleLine,

        /// <summary>
        /// The area between this line and the next will be filled
        /// </summary>
        MultiLine
    }
}
