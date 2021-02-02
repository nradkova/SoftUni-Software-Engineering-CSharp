using System;
using System.Linq;

namespace _01.RecursiveArraySum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split()
                .Select(int.Parse).ToArray();
            int sum = Sum(numbers,0);
            Console.WriteLine(sum);
        }

        private static int Sum(int[] numbers, int index)
        {
            if(index==numbers.Length-1)
            {
                return numbers[index];
            }
            return numbers[index] + Sum(numbers, index+1);
        }
    }
}
