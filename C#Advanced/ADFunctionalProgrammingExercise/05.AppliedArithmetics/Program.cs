using System;
using System.Linq;

namespace _05.AppliedArithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split()
                .Select(int.Parse).ToArray();
            string command = string.Empty;
            while ((command=Console.ReadLine())!="end")
            {
                if (command == "print")
                {
                    Console.WriteLine(string.Join(" ", numbers));
                    continue;
                }

                Func<int, int> operation = x => x;
                operation = ApplyOperation(command, operation);

                for (int i = 0; i < numbers.Length; i++)
                {
                   numbers[i]= operation(numbers[i]);
                }
            }
        }

        static Func<int, int> ApplyOperation(string command, Func<int, int> operation)
        {
            switch (command)
            {
                case "add": operation = x => x + 1; break;
                case "multiply": operation = x => x * 2; break;
                case "subtract": operation = x => x - 1; break;
            }
            return operation;
        }
    }
}
