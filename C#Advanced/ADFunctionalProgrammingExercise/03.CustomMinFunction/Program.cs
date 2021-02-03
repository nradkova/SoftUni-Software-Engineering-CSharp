using System;
using System.Linq;

namespace _03.CustomMinFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split()
                .Select(int.Parse).ToArray();

            Func<int[], int> minValue = GetValue;

            Console.WriteLine(minValue(numbers));
        }
        static int GetValue(int[] numbers)
        {
            int minValue = int.MaxValue;
            foreach (var number in numbers)
            {
                if (number<minValue)
                {
                    minValue = number;
                }
            }
            return minValue;
        }
    }
}
