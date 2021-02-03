using System;
using System.Collections.Generic;

namespace _03.PeriodicTable
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            SortedSet<string> periodicTable = new SortedSet<string>();

            for (int i = 0; i < number; i++)
            {
                string[] elements = Console.ReadLine().Split();
                for (int j = 0; j < elements.Length; j++)
                {
                    if (!periodicTable.Contains(elements[j]))
                    {
                        periodicTable.Add(elements[j]);
                    }
                }
            }
            Console.WriteLine(string.Join(" ",periodicTable));
        }
    }
}
