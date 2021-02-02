using System;
using System.Collections.Generic;
using System.Text;

namespace _04.GenericCountMethodStrings
{
    class Box<T> where T:  IComparable
    {
        private List<T> list;
        public Box()
        {
            list = new List<T>();
        }
        public void Add(T item)
        {
            this.list.Add(item);
        }
        public  int CountGreater(T item)
        {
            int count = 0;
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].CompareTo(item)>0)
                {
                    count++;
                }
            }
            return count;
        }
    }
}
