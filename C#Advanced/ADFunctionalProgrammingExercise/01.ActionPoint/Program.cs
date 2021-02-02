using System;
using System.Linq;

namespace _01.ActionPoint
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();

            Output(input);
        }

        private static void Output(string[] input)
        {
            Action<string> print = ReadAndPrintResult;
            foreach (var item in input)
            {
                print(item);
            }
        }

        static void ReadAndPrintResult(string input)
        {
            Console.WriteLine($"{input}");
        }
    }
}
