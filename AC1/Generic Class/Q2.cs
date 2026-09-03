using System;
using System.Collections.Generic;
using System.Text;

namespace AC1.Generic_Class
{
    internal class Q2<T>
    {
        private T[] _items;
        private int _top;

        public Q2(int size)
        {
            _items = new T[size];
            _top = 0;
        }
        public void Add(T item)
        {
            _items[_top++] = item;
        }

        public T Get(int index)
        {
            return _items[index];
        }
    }

}
