using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleChartSharp
{
    public class ChartData
    {
        public static string Encode(object[] data)
        {
            int maxValue = findMaxValue(data);
            if (maxValue <= 100)
            {
                return TextEncoding(data);
            }
            else if (maxValue <= 61)
            {
                return SimpleEncoding(data);
            }
            else if (maxValue <= 4095)
            {
                return ExtendedEncoding(data);
            }

            return null;
        }

        public static string Encode(ICollection<object[]> data)
        {
            int maxValue = findMaxValue(data);
            if (maxValue <= 100)
            {
                return TextEncoding(data);
            }
            else if (maxValue <= 4095)
            {
                return ExtendedEncoding(data);
            }

            return null;
        }

        #region Simple Encoding

        public static string SimpleEncoding(object[] data)
        {
            return "chd=s:" + simpleEncode(data);
        }

        public static string SimpleEncoding(ICollection<object[]> data)
        {
            string chartData = "chd=s:";

            foreach (object[] objectArray in data)
            {
                chartData += simpleEncode(objectArray) + ",";
            }

            return chartData.TrimEnd(",".ToCharArray());
        }

        private static string simpleEncode(object[] data)
        {
            string simpleEncoding = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            string chartData = string.Empty;

            foreach (object o in data)
            {
                if (o == null)
                {
                    chartData += "_";
                }
                else
                {
                    int value = Convert.ToInt32(o);
                    char c = simpleEncoding[value];
                    chartData += c.ToString();
                }
            }

            return chartData;
        }

        #endregion

        #region Text Encoding

        public static string TextEncoding(object[] data)
        {
            return "chd=t:" + textEncode(data);
        }

        public static string TextEncoding(ICollection<object[]> data)
        {
            string chartData = "chd=t:";

            foreach (object[] objectArray in data)
            {
                chartData += textEncode(objectArray) + "|";
            }

            return chartData.TrimEnd("|".ToCharArray());
        }

        private static string textEncode(object[] data)
        {
            string chartData = string.Empty;

            foreach (object o in data)
            {
                if (o == null)
                {
                    chartData += "-1,";
                }
                else
                {
                    double value = Convert.ToDouble(o);
                    chartData += value.ToString() + ",";
                }
            }

            return chartData.TrimEnd(",".ToCharArray());
        }

        #endregion

        #region Extended Encoding

        public static string ExtendedEncoding(object[] data)
        {
            return "chd=e:" + extendedEncode(data);
        }

        public static string ExtendedEncoding(ICollection<object[]> data)
        {
            string chartData = "chd=e:";

            foreach (object[] objectArray in data)
            {
                chartData += extendedEncode(objectArray) + ",";
            }

            return chartData.TrimEnd(",".ToCharArray());
        }

        private static string extendedEncode(object[] data)
        {
            string extendedEncoding = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789-.";
            string chartData = string.Empty;

            foreach (object o in data)
            {
                if (o == null)
                {
                    chartData += "__";
                }
                else
                {
                    int value = Convert.ToInt32(o);
                    int firstCharPos = Convert.ToInt32(Math.Floor((double)(value / extendedEncoding.Length)));
                    int secondCharPos = Convert.ToInt32(Math.Floor((double)(value % extendedEncoding.Length)));

                    chartData += extendedEncoding[firstCharPos];
                    chartData += extendedEncoding[secondCharPos];
                }
            }

            return chartData;
        }

        #endregion


        private static int findMaxValue(object[] data)
        {
            int[] temp = Array.ConvertAll<object, int>(data, delegate(object o) { return Convert.ToInt32(o); });
            Array.Sort(temp);
            return temp[temp.Length - 1];
        }

        private static int findMaxValue(ICollection<object[]> data)
        {
            List<int> maxValuesList = new List<int>();

            foreach (object[] objectArray in data)
            {
                maxValuesList.Add(findMaxValue(objectArray));
            }

            int[] maxValues = maxValuesList.ToArray();
            Array.Sort(maxValues);
            return maxValues[maxValues.Length - 1];
        }
    }
}
