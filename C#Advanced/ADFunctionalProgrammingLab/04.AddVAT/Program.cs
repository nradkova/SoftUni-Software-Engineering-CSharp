using System;
using System.Linq;

namespace _04.AddVAT
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal[] numbers = Console.ReadLine().Split(", ")
                .Select(decimal.Parse)
                .Select(x =>
                {
                    return  x*1.2m;
                })
                .ToArray();

            foreach (var number in numbers)
            {
                Console.WriteLine($"{number:f2}");
            }

        }
    }
}
