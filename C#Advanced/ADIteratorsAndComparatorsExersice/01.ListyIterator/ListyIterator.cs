using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace _1.ListyIterator
{
    public class ListyIterator<T>:IEnumerable<T>
    {
        private int index = 0;
        //private List<T> elements;
        public ListyIterator(params T[] elemements)
        {
            Elements = elemements.ToList();
        }
        public List<T> Elements { get; set; }

        public bool Move()
        {
          
            if (index+1< Elements.Count)
            {
                index++;
                return true;
            }
            return false;
        }

        public void Print()
        {
            try
            {
                Console.WriteLine(Elements[index]);
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid Operation!");
            }
        }

        public bool HasNext()
        {
            if (index + 1 < Elements.Count)
            {
                return true;
            }
            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Elements.Count; i++)
            {
                yield return Elements[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
