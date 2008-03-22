using System;
using System.Collections.Generic;
using System.Text;

namespace googlechartsharp
{
    public class ChartTitle
    {
        private TitleType titleType;
        private string title;
        private string color;
        private int fontsize;

        public ChartTitle(string title)
        {
            this.titleType = TitleType.TitleOnly;
            this.title = title;
        }

        public ChartTitle(string title, string color, int fontsize)
        {
            this.titleType = TitleType.Full;
            this.title = title;
            this.color = color;
            this.fontsize = fontsize;
        }

        public override string ToString()
        {
            string resultTitle = this.title;
            resultTitle = resultTitle.Replace(" ", "+");
            resultTitle = resultTitle.Replace(System.Environment.NewLine, "|");

            switch (this.titleType)
            {
                case TitleType.TitleOnly:
                    return String.Format("chtt={0}", resultTitle);
                case TitleType.Full:
                    return String.Format("chtt={0}&chts={1},{2}", resultTitle, color, fontsize.ToString());
            }

            return string.Empty;
        }

        private enum TitleType
        {
            TitleOnly,
            Full
        }
    }
}
