using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleChartSharp
{
    public class LinearGradient
    {
        private ChartFillTarget fillTarget;
        /// <summary>
        /// The area that will be filled.
        /// </summary>
        public ChartFillTarget FillTarget
        {
            get { return fillTarget; }
            set { fillTarget = value; }
        }

        private int angle;
        /// <summary>
        /// specifies the angle of the gradient between 0 (horizontal) and 90 (vertical)
        /// </summary>
        public int Angle
        {
            get { return angle; }
            set { angle = value; }
        }

        private List<ColorOffsetPair> colorOffsetPairs = new List<ColorOffsetPair>();

        /// <summary>
        /// Create a linear gradient
        /// </summary>
        /// <param name="fillTarget">area to be filled</param>
        /// <param name="angle">specifies the angle of the gradient between 0 (horizontal) and 90 (vertical)</param>
        public LinearGradient(ChartFillTarget fillTarget, int angle)
        {
            this.fillTarget = fillTarget;
            this.angle = angle;
        }

        /// <summary>
        /// Add a color/offset pair to the linear gradient
        /// </summary>
        /// <param name="color">RRGGBB format hexadecimal number</param>
        /// <param name="offset">specify at what point the color is pure where: 0 specifies the right-most chart position and 1 the left-most</param>
        public void AddColorOffsetPair(string color, int offset)
        {
            this.colorOffsetPairs.Add(new ColorOffsetPair(color, offset));
        }

        private string getTypeUrlChar()
        {
            switch (fillTarget)
            {
                case ChartFillTarget.ChartArea:
                    return "c";
                case ChartFillTarget.Background:
                    return "bg";
            }
            return null;
        }

        public String GetUrlString()
        {
            string s = string.Empty;
            s += getTypeUrlChar() + ",";
            s += "lg,";
            s += angle.ToString() + ",";

            foreach (ColorOffsetPair colorOffsetPair in colorOffsetPairs)
            {
                s += colorOffsetPair.color + ",";
                s += colorOffsetPair.offset + ",";
            }

            return s.TrimEnd(",".ToCharArray());
        }

        private class ColorOffsetPair
        {
            /// <summary>
            /// RRGGBB format hexadecimal number
            /// </summary>
            public string color;

            /// <summary>
            /// specify at what point the color is pure where: 0 specifies the right-most 
            /// chart position and 1 the left-most.
            /// </summary>
            public int offset;

            /// <summary>
            /// 
            /// </summary>
            /// <param name="color">RRGGBB format hexadecimal number</param>
            /// <param name="offset">specify at what point the color is pure where: 0 specifies the right-most chart position and 1 the left-most</param>
            public ColorOffsetPair(string color, int offset)
            {
                this.color = color;
                this.offset = offset;
            }
        }
    }
}
