using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.SetsElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sets = Console.ReadLine().Split()
                 .Select(int.Parse).ToArray();
            HashSet<int> firstSet = new HashSet<int>();
            HashSet<int> secondSet = new HashSet<int>();
            int n = sets[0];
            int m = sets[1];
            for (int i = 0; i < n; i++)
            {
                int number = int.Parse(Console.ReadLine());
                if (!firstSet.Contains(number))
                {
                    firstSet.Add(number);
                }
            }
            for (int i = 0; i < m; i++)
            {
                int number = int.Parse(Console.ReadLine());
                if (!secondSet.Contains(number))
                {
                    secondSet.Add(number);
                }
            }
            foreach (var number in firstSet)
            {
                if (secondSet.Contains(number))
                {
                    Console.Write(number + " ");
                }
            }
        }
    }
}
