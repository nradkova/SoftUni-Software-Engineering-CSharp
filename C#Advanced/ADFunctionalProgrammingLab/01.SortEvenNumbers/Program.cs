using System;
using System.Linq;

namespace _01.SortEvenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int, bool> sortEven = x =>
            {
                return x % 2 == 0;
            };
            int[] numbers = Console.ReadLine().Split(", "
                ,StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            numbers = numbers.Where(sortEven).ToArray();
            Console.WriteLine(string.Join(", ",numbers.OrderBy(x=>x)));
        }
    }
}
