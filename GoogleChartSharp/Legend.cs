using System;
using System.Linq;

namespace GoogleChartSharp
{
    public class Legend : ChartPartCollection<string>
    {
        public override string GetUrlElement()
        {
            return "chdl=" + String.Join("|", this.ToArray());
        }
    }
}
