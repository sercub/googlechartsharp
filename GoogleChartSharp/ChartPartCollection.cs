using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoogleChartSharp
{
    public abstract class ChartPartCollection<T> : ICollection<T>
    {
        private readonly List<T> _inner = new List<T>();
        public IEnumerator<T> GetEnumerator()
        {
            return _inner.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public void Add(T item)
        {
            _inner.Add(item);
        }

        public void Clear()
        {
            _inner.Clear();
        }

        public bool Contains(T item)
        {
            return _inner.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            _inner.CopyTo(array, arrayIndex);
        }

        public bool Remove(T item)
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

        public abstract string GetUrlElement();
    }
}
