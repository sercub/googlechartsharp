using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleChartSharp
{
    public class SolidFill : Fill
    {


        /// <summary>
        /// an RRGGBB format hexadecimal number
        /// </summary>
        public string Color { get; set; }

        /// <summary>
        /// Create a solid fill
        /// </summary>
        /// <param name="fillTarget">The area that will be filled.</param>
        /// <param name="color">an RRGGBB format hexadecimal number</param>
        public SolidFill(FillTarget fillTarget, string color)
        {
            this.FillTarget = fillTarget;
            this.Color = color;
        }


        public override void AppendFillPart(StringBuilder builder)
        {
            builder.Append(getTypeUrlChar()).Append(",s,").Append(Color);
        }
    }
}
