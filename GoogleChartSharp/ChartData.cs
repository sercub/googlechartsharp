using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoogleChartSharp
{
    public class ChartData
    {
        private const string _extendedEncoding = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789-.";
        private string _data;
        public ChartData (params int[] data)
        {
            _data = Encode(data);
        }
        public ChartData(IEnumerable<int> data)
        {
            _data = Encode(data);
        }
        public ChartData(params float[] data)
        {
            _data = Encode(data);
        }
        public ChartData(IEnumerable<float> data)
        {
            _data = Encode(data);
        }

        public ChartData(params float[][] data)
        {
            _data = Encode(data);
        }
        public ChartData(IEnumerable<IEnumerable<int>> data)
        {
            _data = Encode(data);
        }
        public ChartData(params int[][] data)
        {
            _data = Encode(data);
        }
        public ChartData(IEnumerable<IEnumerable<float>> data)
        {
            _data = Encode(data);
        }
        #region Encoding
        private string Encode(IEnumerable<int> data)
        {
            int maxValue = data.Max();
            if (maxValue <= 61)
            {
                return SimpleEncoding(data);
            }
            else if (maxValue <= 4095)
            {
                return ExtendedEncoding(data);
            }

            return null;
        }

        private string Encode(IEnumerable<IEnumerable<int>> data)
        {
            int maxValue = data.SelectMany(x => x).Max();
            if (maxValue <= 61)
            {
                return SimpleEncoding(data);
            }
            else if (maxValue <= 4095)
            {
                return ExtendedEncoding(data);
            }

            return null;
        }

        private string Encode(IEnumerable<float> data)
        {
            return TextEncoding(data);
        }

        private string Encode(IEnumerable<IEnumerable<float>> data)
        {
            return TextEncoding(data);
        }

 

        private string SimpleEncoding(IEnumerable<int> data)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append("chd=s:");
            simpleEncode(data, stringBuilder);
            return stringBuilder.ToString();
        }

        private string SimpleEncoding(IEnumerable<IEnumerable<int>> data)
        {
            var sb = new StringBuilder();
            sb.Append("chd=s:");

            int count = 0;

            foreach (int[] objectArray in data)
            {
                if (count > 0)
                    sb.Append(",");

                simpleEncode(objectArray, sb);
                count++;
            }

            return sb.ToString();
        }

        private void simpleEncode(IEnumerable<int> data, StringBuilder sb)
        {
            string simpleEncoding = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            string chartData = string.Empty;

            foreach (int value in data)
            {
                if (value == -1)
                {
                    sb.Append("_");
                }
                else
                {
                    sb.Append(simpleEncoding[value]);

                }
            }

        }


        private string TextEncoding(IEnumerable<float> data)
        {
            var sb = new StringBuilder("chd=t:");
            textEncode(data, sb);
            return sb.ToString();
        }

        private string TextEncoding(IEnumerable<IEnumerable<float>> data)
        {
            var sb = new StringBuilder();
            sb.Append("chd=t:");


            int count = 0;
            foreach (float[] objectArray in data)
            {
                if (count > 0)
                    sb.Append("|");
                textEncode(objectArray, sb);
                count++;
            }

            return sb.ToString();
        }

        private void textEncode(IEnumerable<float> data, StringBuilder sb)
        {
            int count = 0;
            foreach(var value in data)
            {
                if (count > 0)
                    sb.Append(",");
                if (value == -1)
                    sb.Append(-1);
                else
                    sb.Append(value);
                count++;
            }

        }



        private string ExtendedEncoding(IEnumerable<int> data)
        {
            var sb = new StringBuilder("chd=e:");
            extendedEncode(data, sb);
            return sb.ToString();
        }

        private string ExtendedEncoding(IEnumerable<IEnumerable<int>> data)
        {

            var sb = new StringBuilder("chd=e:");
            int count = 0;

            foreach (var objectArray in data)
            {
                if (count > 0)
                    sb.Append(",");

                extendedEncode(objectArray, sb);
                count++;
            }

            return sb.ToString();
        }

        private void extendedEncode(IEnumerable<int> data, StringBuilder sb)
        {
            string chartData = string.Empty;

            foreach (int value in data)
            {
                if (value == -1)
                {
                    sb.Append("__");
                }
                else
                {
                    int firstCharPos = Convert.ToInt32(Math.Floor((double)(value / _extendedEncoding.Length)));
                    int secondCharPos = Convert.ToInt32(Math.Floor((double)(value % _extendedEncoding.Length)));

                    sb.Append(_extendedEncoding[firstCharPos]).Append(_extendedEncoding[secondCharPos]);

                }
            }

        }

        #endregion


        public static implicit operator ChartData(int[] data) { return new ChartData(data); }

        public static implicit operator ChartData(float[] data) { return new ChartData(data); }

        public static implicit operator ChartData(int[][] data) { return new ChartData(data); }

        public static implicit operator ChartData(float[][] data) { return new ChartData(data); }
 

 


        public string GetUrlElement()
        {
            return _data;
        }


    }
}
