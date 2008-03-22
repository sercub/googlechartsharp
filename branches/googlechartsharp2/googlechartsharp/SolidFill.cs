using System;
using System.Collections.Generic;
using System.Text;

namespace googlechartsharp
{
    public class SolidFill
    {
        private ChartFillTarget fillTarget;
        private string color;

        /// <summary>
        /// Create a solid fill
        /// </summary>
        /// <param name="fillTarget">The area that will be filled.</param>
        /// <param name="color">an RRGGBB format hexadecimal number</param>
        public SolidFill(ChartFillTarget fillTarget, string color)
        {
            this.fillTarget = fillTarget;
            this.color = color;
        }

        public override string ToString()
        {
            string typeChar = string.Empty;

            switch (this.fillTarget)
            {
                case ChartFillTarget.ChartArea:
                    typeChar = "c";
                    break;
                case ChartFillTarget.Background:
                    typeChar = "bg";
                    break;
            }

            return string.Format("{0},s,{1}", typeChar, this.color);
        }

        internal static string GetDelimiter()
        {
            return "|";
        }
    }

    public enum ChartFillTarget
    {
        /// <summary>
        /// Fill the entire background of the chart
        /// </summary>
        Background,

        /// <summary>
        /// Fill only the chart area of the chart
        /// </summary>
        ChartArea
    }
}
