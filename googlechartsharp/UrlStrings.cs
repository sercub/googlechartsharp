using System;
using System.Collections.Generic;
using System.Text;

namespace googlechartsharp
{
    internal class UrlStrings
    {
        internal static string ChartType(ChartTypes type)
        {
            switch (type)
            {
                case ChartTypes.SimpleLine:
                    return "cht=lc";
                case ChartTypes.PairLine:
                    return "cht=lxy";
                case ChartTypes.SparkLine:
                    return "cht=ls";
                case ChartTypes.HorizontalStackedBar:
                    return "cht=bhs";
                case ChartTypes.VerticalStackedBar:
                    return "cht=bvs";
                case ChartTypes.HorizontalGroupedBar:
                    return "cht=bhs";
                case ChartTypes.VerticalGroupedBar:
                    return "cht=bvg";
            }

            return string.Empty;
        }

        internal static string ChartSize(int width, int height)
        {
            return String.Format("chs={0}x{1}", width.ToString(), height.ToString());
        }

        internal static string ChartData(EncodingTypes encodingType, List<DataSet> dataSets)
        {
            string result = string.Empty;

            switch (encodingType)
            {
                case EncodingTypes.Simple:
                    result += "chd=s:";
                    break;
                case EncodingTypes.Text:
                    result += "chd=t:";
                    break;
                case EncodingTypes.Extended:
                    result += "chd=e:";
                    break;
            }

            foreach (DataSet dataSet in dataSets)
            {
                result += dataSet.ToString(encodingType) + DataSet.Delimiter;
            }

            return result.TrimEnd(DataSet.Delimiter.ToCharArray());
        }

        internal static string ChartTitle(ChartTitle chartTitle)
        {
            if (chartTitle != null)
            {
                return chartTitle.ToString();
            }

            return string.Empty;
        }
    }
}
