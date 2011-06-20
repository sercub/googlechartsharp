using System.Text;

namespace GoogleChartSharp
{
    public abstract class Fill
    {
        /// <summary>
        /// The area that will be filled.
        /// </summary>
        public FillTarget FillTarget { get; set; }

        public abstract void AppendFillPart(StringBuilder builder);

        protected string getTypeUrlChar()
        {
            switch (FillTarget)
            {
                case FillTarget.ChartArea:
                    return "c";
                case FillTarget.Background:
                    return "bg";
            }
            return null;
        }
    }
}