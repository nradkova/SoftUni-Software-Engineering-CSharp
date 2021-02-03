using System;
using System.Collections.Generic;
using System.Text;

namespace _03.GenericSwapMethodStrings
{
  public  class CustomList<T>
    {
        private List<T> list;
        public CustomList()
        {
            list = new List<T>();
        }
        
        public void Add(T item)
        {
            this.list.Add(item);
        }
        public void Swap(int index1,int index2)
        {
            T temp = this.list[index1];
            this.list[index1] = this.list[index2];
            this.list[index2] = temp;
        }
        public void ForEach(Action<T>action)
        {
            for (int i = 0; i < this.list.Count; i++)
            {
                action(this.list[i]);
            }
        }
    }
}
