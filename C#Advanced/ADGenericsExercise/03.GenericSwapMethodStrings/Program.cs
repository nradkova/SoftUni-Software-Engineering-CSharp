using System;
using System.Linq;

namespace _03.GenericSwapMethodStrings
{
   public class Program
    {
        static void Main(string[] args)
        {
            int n =int.Parse(Console.ReadLine());
            CustomList<string> list = new CustomList<string>();

            for (int i = 0; i < n; i++)
            {
                list.Add(Console.ReadLine());
            }
            int[] indeces = Console.ReadLine().Split()
                .Select(int.Parse).ToArray();
            list.Swap(indeces[0], indeces[1]);
            list.ForEach(x => Console.WriteLine($"{x.GetType()}: {x}"));
        }
    }
}
