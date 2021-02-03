using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.BasicStackOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().
                Select(int.Parse).ToArray();
            int inputN = input[0];
            int inputS = input[1];
            int inputX = input[2];
            Stack<int> stack = new Stack<int>();
            int[] numbers= Console.ReadLine().Split().
                Select(int.Parse).ToArray();
            for (int i = 0; i < inputN; i++)
            {
                stack.Push(numbers[i]);
            }
            while (stack.Count>0&&inputS>0)
            {
                stack.Pop();
                inputS--;
            }
            foreach (var num in stack)
            {
                if (num==inputX)
                {
                    Console.WriteLine("true");
                    return;
                }
            }
            if (stack.Count>0)
            {
                Console.WriteLine(stack.Min());
            }
            else
            {
                Console.WriteLine(0);
            }
        }
    }
}
