using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.FindEvenOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] range = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            string type = Console.ReadLine();
            Predicate<int> conditionEven = FilterEven;
            Predicate<int> conditionOdd = FilterOdd;

            for (int i = range[0]; i <= range[1]; i++)
            {
                PrintResults(type, conditionEven, conditionOdd, i);
            }
        }

        static void PrintResults(string input, Predicate<int> even, Predicate<int> odd, int num)
        {
            if (input == "even" && even(num) == true)
            {
                Console.Write(num + " ");
            }
            if (input == "odd" && odd(num) == true)
            {
                Console.Write(num + " ");
            }
        }

        static bool FilterEven(int num)
        {
            return num % 2 == 0;
        }

        static bool FilterOdd(int num)
        {
            return num % 2 != 0;
        }
    }
}
