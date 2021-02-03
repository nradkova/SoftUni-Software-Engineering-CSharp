using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace _02.StackSum
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>(Console.ReadLine().Split().
                Select(int.Parse).ToArray());
            string command = string.Empty;
            while ((command=Console.ReadLine().ToLower())!="end")
            {
                var tokens = command.Split();
                if (tokens[0]=="add")
                {
                    AddValues(stack,tokens);
                }
                else if (tokens[0] == "remove")
                {

                    RemoveValues(stack, int.Parse(tokens[1]));
                }
            }
            Console.WriteLine($"Sum: {stack.Sum()}");
        }

        private static void RemoveValues(Stack<int> stack, int count)
        {
            if (stack.Count>=count)
            {
                while (count>=1)
                {
                stack.Pop();
                    count--;
                }
            }
        }

        public static void AddValues(Stack<int> stack,string[] tokens)
        {
            for (int i = 1; i < tokens.Length; i++)
            {
                stack.Push(int.Parse(tokens[i]));
            }
        }
    }
}
