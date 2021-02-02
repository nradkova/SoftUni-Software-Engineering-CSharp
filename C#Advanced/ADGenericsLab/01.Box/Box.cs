using System;
using System.Collections.Generic;
using System.Text;

namespace BoxOfT
{
    public class Box<T>
    {
        private List<T> list;
        public Box()
        {
            this.list = new List<T>();
        }
        public int Count
        {
            get
            {
                return list.Count;
            }
        }

        public void Add(T element)
        {
            list.Add(element);
        }
        public T Remove()
        {
           T last = list[list.Count - 1];
            list.Remove(last);
            return last;
        }
    }
}
