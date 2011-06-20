using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleChartSharp
{
    public class LinearGradientFill : Fill
    {


        /// <summary>
        /// specifies the angle of the gradient between 0 (horizontal) and 90 (vertical)
        /// </summary>
        public int Angle { get; set; }

        public IEnumerable<ColorOffsetPair> ColorOffsetPairs { get; set; }
        public override void AppendFillPart(StringBuilder builder)
        {
            builder
                .Append(getTypeUrlChar())
                .Append(",")
                .Append("lg,")
                .Append(Angle)
                .Append(",");

            int count = 0;
            foreach (ColorOffsetPair colorOffsetPair in ColorOffsetPairs)
            {
                if (count > 0)
                    builder.Append(",");
                colorOffsetPair.AppendOffsetPair(builder);

                count++;
            }

            
        }
    }

    ///<summary>
    ///</summary>
    public class ColorOffsetPair
    {
        /// <summary>
        /// RRGGBB format hexadecimal number
        /// </summary>
        public string Color { get; set; }

        /// <summary>
        /// specify at what point the color is pure where: 0 specifies the right-most 
        /// chart position and 1 the left-most.
        /// </summary>
        public double Offset { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="color">RRGGBB format hexadecimal number</param>
        /// <param name="offset">specify at what point the color is pure where: 0 specifies the right-most chart position and 1 the left-most</param>
        public ColorOffsetPair(string color, double offset)
        {
            this.Color = color;
            this.Offset = offset;
        }
        public void AppendOffsetPair(StringBuilder builder)
        {
            builder.Append(Color).Append(",").Append(Offset);
        }
    }
}
