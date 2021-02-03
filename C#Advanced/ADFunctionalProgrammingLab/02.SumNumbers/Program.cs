using System;
using System.Linq;

namespace _02.SumNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(", ")
                .Select(int.Parse)
                .ToArray();

            Func<int[], int> countDelegate = Count;
            Func<int[], int> sumDelegate =Sum;

            CalculateAndPrint(numbers, countDelegate);
            CalculateAndPrint(numbers, sumDelegate);

        }

        static int Count(int[] numbers)
        {
            return numbers.Length;
        }
        static int Sum(int[] numbers)
        {
            return numbers.Sum();
        }
        static void CalculateAndPrint(int[]numbers, Func<int[], int> operation)
        {
            Console.WriteLine(operation(numbers));
        }

    }
}
