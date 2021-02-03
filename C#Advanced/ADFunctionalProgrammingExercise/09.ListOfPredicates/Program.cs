using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.ListOfPredicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int range = int.Parse(Console.ReadLine());
            int[] dividers = Console.ReadLine().Split()
                .Select(int.Parse).ToArray();

            List<int> results = new List<int>();

            for (int i = 1; i <= range; i++)
            {
                results.Add(i);
            }

            results = results.Where(
                x =>
                {
                    int count = dividers.Length;
                    foreach (var divider in dividers)
                    {
                        if (x % divider == 0)
                        {
                            count--;
                        }
                        if (count == 0)
                        {
                            return true;
                        }
                    }
                    return false;
                }).ToList();

            Console.WriteLine(string.Join(" ", results));
        }
    }
}
