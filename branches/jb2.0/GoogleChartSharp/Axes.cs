using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoogleChartSharp
{
    public class Axes : ICollection<Axis>
    {
        private readonly List<Axis> _inner = new List<Axis>();
        public IEnumerator<Axis> GetEnumerator()
        {
            return _inner.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public void Add(Axis item)
        {
            _inner.Add(item);
        }

        public void Clear()
        {
            _inner.Clear();
        }

        public bool Contains(Axis item)
        {
            return _inner.Contains(item);
        }

        public void CopyTo(Axis[] array, int arrayIndex)
        {
            _inner.CopyTo(array, arrayIndex);
        }

        public bool Remove(Axis item)
        {
            return _inner.Remove(item);
        }

        public int Count
        {
            get { return _inner.Count; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public IEnumerable<string> GetUrlElements()
        {
            yield return buildAxisTypes();
            if(haveLabels())
            {
                yield return BuildLabels();
            }
            if(haveLabelPositions())
            {
                StringBuilder sb = new StringBuilder("chxp=");
                int count = 0;
                foreach(var item in IndexedAxes)
                {
                    if (item.Axis.Labels.Any(x => x.Position != null))
                    {
                        if (count > 0)
                            sb.Append("|");
                        sb.Append(item.Index);
                        foreach (var item1 in item.Axis.Labels)
                        {
                            sb.Append(",")
                                .Append(item1.Position);

                        }
                        count++;
                    }
                }
                yield return sb.ToString();
            }
            //yield return buildAxisLabelPositions();
            yield return buildAxisRanges();
            yield return buildAxisStyles();
        }

        private bool haveLabelPositions()
        {
            return _inner.Any(x => x.Labels.Any(y => y.Position != null));
        }

        private string BuildLabels()
        {
            var sb = new StringBuilder();
            sb.Append("chxl=");
            foreach(var item in IndexedAxes)
            {
                item.Axis.AppendUrlLabels(item.Index, sb);
            }
            sb.Remove(sb.Length - 1, 1);
            return sb.ToString();
        }

        private bool haveLabels()
        {
            return _inner.Any(x => x.Labels.Any());
        }

        private class IndexedAxis
        {
            public Axis Axis { get; set; }
            public int Index { get; set; }
        }

        private IEnumerable<IndexedAxis> IndexedAxes
        {
            get { return _inner.Select((x, i) => new IndexedAxis {Axis = x, Index = i}); }
        }




        private string buildAxisRanges()
        {
            string fmt = "{0}" + "," + "{1}";
            var rangeArray = _inner.Select((x1, i) => new {value = ((Func<Axis, string>) (x => x.UrlRange()))(x1), index = i}).Where(x => !String.IsNullOrEmpty(x.value))
                .Select(x2 => String.Format(fmt, x2.index, x2.value)).ToArray();
            return "chxr=" + string.Join("|", rangeArray);
        }

        private string buildAxisStyles()
        {
            string fmt = "{0}" + "," + "{1}";
            var styleArray = _inner.Select((x1, i) => new {value = ((Func<Axis, string>) (x => x.UrlAxisStyle()))(x1), index = i}).Where(x => !String.IsNullOrEmpty(x.value))
                .Select(x2 => String.Format(fmt, x2.index, x2.value)).ToArray();
            return "chxs=" + string.Join("|", styleArray);
        }

        private string buildAxisTypes()
        {
            var typeArray = _inner.Select(x => x.UrlAxisType()).ToArray();
            return "chxt=" + String.Join(",", typeArray);

        }
    }
}
