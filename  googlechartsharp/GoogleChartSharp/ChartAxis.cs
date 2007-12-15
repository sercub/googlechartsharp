using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleChartSharp
{
    public class ChartAxis
    {
        ChartAxisType axisType;
        List<ChartAxisLabel> axisLabels = new List<ChartAxisLabel>();
        int upperBound;
        int lowerBound;
        bool rangeSet;

        public ChartAxis(ChartAxisType axisType) : this(axisType, null)
        {
        }

        public ChartAxis(ChartAxisType axisType, string[] labels)
        {
            this.axisType = axisType;

            if (labels != null)
            {
                foreach (string label in labels)
                {
                    this.axisLabels.Add(new ChartAxisLabel(label, -1));
                }
            }
        }

        public void SetRange(int lowerBound, int upperBound)
        {
            this.lowerBound = lowerBound;
            this.upperBound = upperBound;
            this.rangeSet = true;
        }

        public void AddLabel(ChartAxisLabel axisLabel)
        {
            axisLabels.Add(axisLabel);
        }

        public string urlAxisType()
        {
            switch (axisType)
            {
                case ChartAxisType.Bottom:
                    return "x";

                case ChartAxisType.Top:
                    return "t";

                case ChartAxisType.Left:
                    return "y";

                case ChartAxisType.Right:
                    return "r";
            }

            return null;
        }

        public string urlLabels()
        {
            string result = "|";
            foreach (ChartAxisLabel label in axisLabels)
            {
                result += label.Text + "|";
            }
            return result;
        }

        public string urlLabelPositions()
        {
            string result = string.Empty;
            foreach (ChartAxisLabel axisLabel in axisLabels)
            {
                if (axisLabel.Position == -1)
                {
                    return null;
                }
                result += axisLabel.Position.ToString() + ",";
            }
            return result.TrimEnd(",".ToCharArray());
        }

        public string urlRange()
        {
            if (rangeSet)
            {
                return lowerBound.ToString() + "," + upperBound.ToString();
            }
            return null;
        }
    }

    public class ChartAxisLabel
    {
        public string Text;
        public float Position;

        public ChartAxisLabel(string text)
            : this(text, -1)
        {
        }

        public ChartAxisLabel(float position)
            : this(null, position)
        {

        }

        public ChartAxisLabel(string text, float position)
        {
            this.Text = text;
            this.Position = position;
        }
    }

    public enum ChartAxisType
    {
        Bottom,
        Top,
        Left,
        Right
    }
}
