using System;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics;

namespace HashSetImplementation
{
    class Program
    {
        static void Main(string[] args)
        {
            var timer = Stopwatch.StartNew();
            StringHashSet names = new StringHashSet();
            string input = Console.ReadLine();
            while (input!="end")
            {
            names.Add(input);
                input = Console.ReadLine();
            }

            Console.WriteLine(names.Contains("Ivan"));
            Console.WriteLine(names.Contains("Vivi"));
            Console.WriteLine(names.Contains("Mariq"));
            names.Print();
            timer.Stop();
            Console.WriteLine(timer.ElapsedMilliseconds);
        }
        public class SetElements
        {
            public List<string> Names { get; set; }
        }
        public class StringHashSet
        {
            private SetElements[] array;
            public StringHashSet(int capacity = 16)
            {
                array = new SetElements[capacity];
            }
            private int HashFuction(string key)
            {
                int index = key[0] * key.Length + key[key.Length - 1] * key.Length;
                return index % array.Length;

            }

            public void Add(string key)
            {
                if (array[HashFuction(key)] != null)
                {
                    if (!array[HashFuction(key)].Names.Contains(key))
                    {
                        array[HashFuction(key)].Names.Add(key);
                    }
                }
                else
                {
                    array[HashFuction(key)] = new SetElements() { Names = new List<string>() { key } };
                }
            }
            public bool Contains(string key)
            {
                if (array[HashFuction(key)]==null ||
                    !array[HashFuction(key)].Names.Contains(key))
                {
                    return false;
                }
                return true;
            }
            public void Print()
            {
                foreach (var item in array)
                {
                    if (item != null)
                    {
                        Console.WriteLine(string.Join(" ", item.Names));
                    }
                }
            }

        }
    }
}
