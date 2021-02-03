using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _03.MaximumAndMinimumElement
{
    class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < lines; i++)
            {
                int[] commands = Console.ReadLine()
                    .Split().Select(int.Parse).ToArray();
                if (commands[0] == 1)
                {
                    stack.Push(commands[1]);
                }
                else if (commands[0] == 2 && stack.Count > 0)
                {
                    stack.Pop();
                }
                else if (commands[0] == 3 && stack.Count > 0)
                {
                    Console.WriteLine(stack.Max());
                }
                else if (commands[0] == 4 && stack.Count > 0)
                {
                    Console.WriteLine(stack.Min());
                }
            }
            Console.WriteLine(string.Join(", ",stack));
        }
    }
}
