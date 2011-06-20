using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleChartSharp
{
    public class LinearStripesFill : Fill
    {
        /// <summary>
        /// specifies the angle of the gradient between 0 (vertical) and 90 (horizontal)
        /// </summary>
        public int Angle { get; set; }

        public IEnumerable<ColorWidthPair> ColorWidthPairs { get; set; }


        public override void AppendFillPart(StringBuilder builder)
        {
            builder.Append(getTypeUrlChar()).Append(",ls,").Append(Angle).Append(",");

            int count = 0;
            foreach (ColorWidthPair colorWidthPair in ColorWidthPairs)
            {
                if (count > 0)
                    builder.Append(",");
                colorWidthPair.AppendTo(builder);
                count++;
            }

            
        }
    }

    ///<summary>
    ///</summary>
    public class ColorWidthPair
    {
        /// <summary>
        /// RRGGBB format hexadecimal number
        /// </summary>
        public string Color { get; set; }

        /// <summary>
        /// must be between 0 and 1 where 1 is the full width of the chart
        /// </summary>
        public double Width { get; set; }

        /// <summary>
        /// Describes a linear stripe. Stripes are repeated until the chart is filled.
        /// </summary>
        /// <param name="color">RGGBB format hexadecimal number</param>
        /// <param name="width">must be between 0 and 1 where 1 is the full width of the chart</param>
        public ColorWidthPair(string color, double width)
        {
            this.Color = color;
            this.Width = width;
        }

        public void AppendTo(StringBuilder builder)
        {
            builder.Append(Color).Append(",").Append(Width);
        }
    }
}
