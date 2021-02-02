using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _01.ReverseStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Stack<char> stack = new Stack<char>(input.ToCharArray());
            while (stack.Count > 1)
            {
                Console.Write(stack.Pop());
            }
            Console.Write(stack.Pop());
            Console.WriteLine();
        }
    }
}
