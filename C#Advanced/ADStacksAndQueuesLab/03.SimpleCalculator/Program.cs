using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace _03.SimpleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {

            Stack<string> stack = new Stack<string>(Console.ReadLine().Split().Reverse());
            CalculateSum(stack);
            Console.WriteLine(stack.Pop());
        }

        private static void CalculateSum(Stack<string> stack)
        {
            var temp = new List<int>();
            while (stack.Count >=3)
            {
               
                if (stack.Peek() != "+" && stack.Peek() != "-")
                {
                    temp.Add(int.Parse(stack.Pop()));
                }
                if (stack.Peek() == "+")
                {
                    stack.Pop();
                    temp.Add(int.Parse(stack.Pop()));
                    stack.Push(temp.Sum().ToString());
                    temp = new List<int>();
                }
               else if (stack.Peek() == "-")
                {
                    stack.Pop();
                    temp.Add(int.Parse(stack.Pop()));
                    stack.Push((temp[0]-temp[1]).ToString());
                    temp = new List<int>();
                }
            }
        }
    }
}
