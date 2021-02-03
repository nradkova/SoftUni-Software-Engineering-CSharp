using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03.Stack
{
    public class CustomStack<T> : IEnumerable<T>
    {
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = Elements.Count - 1; i >= 0; i--)
            {
                yield return Elements[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public CustomStack()
        {
            Elements = new List<T>();
        }
        public List<T> Elements { get; set; }
        public int Count { get; set; }

        public void Push(params T[] elements)
        {
            for (int i = 0; i < elements.Length; i++)
            {
                Elements.Add(elements[i]);
                Count++;
            }
        }

        public void Pop()
        {
            try
            {
                Elements.RemoveAt(Count - 1);
                Count--;
            }
            catch (Exception)
            {

                Console.WriteLine("No elements");
            }
        }
    }
}
