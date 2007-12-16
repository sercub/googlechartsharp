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

        public override string chartType()
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

        public override void SetLegend(string[] strs)
        {
            throw new InvalidFeatureForChartTypeException();
        }

        public void SetPieChartLabels(string[] labels)
        {
            this.pieChartLabels = labels;
        }
    }

    public enum PieChartType
    {
        TwoD,
        ThreeD
    }
}
