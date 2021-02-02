using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.CountSameValuesInArray
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<double, int> values = new Dictionary<double, int>();
            double[] numbers = Console.ReadLine().Split()
                .Select(double.Parse).ToArray();
            for (int i = 0; i < numbers.Length; i++)
            {
                if (!values.ContainsKey(numbers[i]))
                {
                    values.Add(numbers[i], 0);
                }
                values[numbers[i]]++;
            }
            foreach (var pair in values)
            {
                Console.WriteLine($"{pair.Key} - {pair.Value} times");
            }
        }
    }
}
