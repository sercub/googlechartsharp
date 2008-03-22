using System;
using System.Collections.Generic;
using System.Text;

namespace googlechartsharp
{
    class DataEncoding
    {    
        #region Simple Encoding

        public static string SimpleEncoding(int[] data)
        {
            return simpleEncode(data);
        }

        public static string SimpleEncoding(ICollection<int[]> data)
        {
            string chartData = string.Empty;

            foreach (int[] objectArray in data)
            {
                chartData += simpleEncode(objectArray) + ",";
            }

            return chartData.TrimEnd(",".ToCharArray());
        }

        private static string simpleEncode(int[] data)
        {
            string simpleEncoding = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            string chartData = string.Empty;

            foreach (int value in data)
            {
                if (value == -1)
                {
                    chartData += "_";
                }
                else
                {
                    char c = simpleEncoding[value];
                    chartData += c.ToString();
                }
            }

            return chartData;
        }

        #endregion

        #region Text Encoding

        public static string TextEncoding(float[] data)
        {
            return textEncode(data);
        }

        public static string TextEncoding(ICollection<float[]> data)
        {
            string chartData = string.Empty;

            foreach (float[] objectArray in data)
            {
                chartData += textEncode(objectArray) + "|";
            }

            return chartData.TrimEnd("|".ToCharArray());
        }

        private static string textEncode(float[] data)
        {
            string chartData = string.Empty;

            foreach (float value in data)
            {
                if (value == -1)
                {
                    chartData += "-1,";
                }
                else
                {
                    chartData += value.ToString() + ",";
                }
            }

            return chartData.TrimEnd(",".ToCharArray());
        }

        #endregion

        #region Extended Encoding

        public static string ExtendedEncoding(int[] data)
        {
            return extendedEncode(data);
        }

        public static string ExtendedEncoding(ICollection<int[]> data)
        {
            string chartData = string.Empty;

            foreach (int[] objectArray in data)
            {
                chartData += extendedEncode(objectArray) + ",";
            }

            return chartData.TrimEnd(",".ToCharArray());
        }

        private static string extendedEncode(int[] data)
        {
            string extendedEncoding = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789-.";
            string chartData = string.Empty;

            foreach (int value in data)
            {
                if (value == -1)
                {
                    chartData += "__";
                }
                else
                {
                    int firstCharPos = Convert.ToInt32(Math.Floor((double)(value / extendedEncoding.Length)));
                    int secondCharPos = Convert.ToInt32(Math.Floor((double)(value % extendedEncoding.Length)));

                    chartData += extendedEncoding[firstCharPos];
                    chartData += extendedEncoding[secondCharPos];
                }
            }

            return chartData;
        }

        #endregion
    }

    
}
