using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleChartSharp
{
    public class Title
    {
        public string Text { get; set; }
        public string Color { get; set; }
        public int Size { get; set; }

        public IEnumerable<string> GetUrlElements()
        {

            if (Text != null)
            {
                yield return String.Format("chtt={0}", EncodeTitle(Text));
            }
            if (Color != null)
            {
                if (Size == 0)
                    yield return String.Format("chts={0}", Color);
                else
                    yield return String.Format("chts={0},{1}", Color, Size);
            }
        }

        protected virtual string EncodeTitle(string title)
        {
            string urlTitle = title.Replace(" ", "+");
            urlTitle = urlTitle.Replace(Environment.NewLine, "|");
            return urlTitle;
        }

        public static implicit operator Title(string titleText)
        {
            if (titleText == null)
                return null;
            else return new Title {Text = titleText};
        }
    }
}
