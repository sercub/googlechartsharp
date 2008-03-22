using System;
using System.Collections.Generic;
using System.Text;

namespace googlechartsharp
{
    public class ScalingRange
    {
        private float minimum;
        private float maximum;

        public ScalingRange(float minimum, float maximum)
        {
            this.minimum = minimum;
            this.maximum = maximum;
        }

        public override string ToString()
        {
            return minimum.ToString() + "," + maximum.ToString();
        }

        public static string Delimiter
        {
            get { return ","; }
        }
    }
}
