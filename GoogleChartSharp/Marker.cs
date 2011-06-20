using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoogleChartSharp
{
    public abstract class Marker
    {
        ///public abstract string GetUrlString();

        public abstract void AppendUrlPart(StringBuilder sb);
    }
}
