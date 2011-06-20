using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleChartSharp
{
    public class PieChart : Chart
    {
        public PieChartType PieChartType { get; set; }
        public IEnumerable<string > Labels { get; set; }

        /// <summary>
        /// Create a 2D pie chart
        /// </summary>
        /// <param name="width">width in pixels</param>
        /// <param name="height">height in pixels</param>
        public PieChart(int width, int height)
            : base(width, height)
        {

        }

        /// <summary>
        /// Create a pie chart of specified type
        /// </summary>
        /// <param name="width">width in pixels</param>
        /// <param name="height">height in pixels</param>
        /// <param name="pieChartType"></param>
        public PieChart(int width, int height, PieChartType pieChartType)
            : base(width, height)
        {
            PieChartType = pieChartType;
        }

        protected override string UrlChartType
        {
            get
            {
                if (this.PieChartType == PieChartType.ThreeD)
                {
                    return "p3";
                }

                return "p";
            }
        }

        protected override List<String> collectUrlElements()
        {
            var res = base.collectUrlElements();
            if (Labels != null)
            {
                string s = "chl=";
                foreach (string label in Labels)
                {
                    s += label + "|";
                }
                res.Add(s.TrimEnd("|".ToCharArray()));
            }
            return res;
        }

        public override Legend Legend
        {
            get
            {
                return null;
            }
            set
            {
                throw new InvalidFeatureForChartTypeException();
            }
        }



        protected override ChartType ChartType
        {
            get { return ChartType.PieChart; }
        }
    }
}
