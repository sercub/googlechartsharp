using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleChartSharp
{
    public class PieChart : Chart
    {
        private PieChartType pieChartType;
        private string[] pieChartLabels;

        public PieChart(int width, int height)
            : base(width, height)
        {

        }

        public PieChart(int width, int height, PieChartType pieChartType)
            : base(width, height)
        {
            this.pieChartType = pieChartType;
        }

        protected override string urlChartType()
        {
            if (this.pieChartType == PieChartType.ThreeD)
            {
                return "p3";
            }

            return "p";
        }

        protected override void collectUrlElements()
        {
            base.collectUrlElements();
            if (pieChartLabels != null)
            {
                string s = "chl=";
                foreach (string label in pieChartLabels)
                {
                    s += label + "|";
                }
                this.urlElements.Enqueue(s.TrimEnd("|".ToCharArray()));
            }
        }

        /// <summary>
        /// Legend is not supported on Pie Charts
        /// </summary>
        /// <param name="strs"></param>
        public override void SetLegend(string[] strs)
        {
            throw new InvalidFeatureForChartTypeException();
        }

        /// <summary>
        /// Set labels for the Pie Chart slices
        /// </summary>
        /// <param name="labels">strings that will be used as label text</param>
        public void SetPieChartLabels(string[] labels)
        {
            this.pieChartLabels = labels;
        }

        protected override ChartType getChartType()
        {
            return ChartType.PieChart;
        }
    }

    public enum PieChartType
    {
        TwoD,
        ThreeD
    }
}
