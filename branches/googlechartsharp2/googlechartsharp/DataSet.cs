using System;
using System.Collections.Generic;
using System.Text;

namespace googlechartsharp
{
    class DataSet
    {
        private int[] intData = null;
        private float[] floatData = null;

        public DataSet(int[] data)
        {
            this.intData = data;
        }

        public DataSet(float[] data)
        {
            this.floatData = data;
        }

        public string ToString(EncodingTypes encodingType)
        {
            switch (encodingType)
            {
                case EncodingTypes.Simple:
                    return DataEncoding.SimpleEncoding(intData);
                case EncodingTypes.Text:
                    return DataEncoding.TextEncoding(floatData);
                case EncodingTypes.Extended:
                    return DataEncoding.ExtendedEncoding(intData);
            }

            return string.Empty;
        }

        public static string GetDelimiter(EncodingTypes encoding)
        {
            switch (encoding)
            {
                case EncodingTypes.Simple:
                    return ",";
                case EncodingTypes.Extended:
                    return ",";
                case EncodingTypes.Text:
                    return "|";
            }

            return string.Empty;
        }
    }

    public enum EncodingTypes
    {
        Simple,
        Text,
        Extended
    }
}
