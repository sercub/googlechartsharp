using System.Text;

namespace GoogleChartSharp
{
    public class Fills : ChartPartCollection<Fill>
    {


        public override string GetUrlElement()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("chf=");
            int count = 0;
            foreach(var fill in this)
            {
                if (count > 0)
                    sb.Append("|");
                fill.AppendFillPart(sb);
                count++;
            }
            return sb.ToString();
        }
    }
}
