using System;
using System.Collections;
using System.Collections.Generic;

namespace _08.BalancedParenthesis
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            if (input.Length % 2 != 0)
            {
                Console.WriteLine("NO");
                return;
            }
            Stack<char> stack = new Stack<char>();
            for (int i = 0; i < input.Length; i++)
            {
                char currentParenthesis = input[i];
                if (stack.Count > 0)
                {
                    if (stack.Peek() == '(' && currentParenthesis == ')')
                    {
                        input = input.Remove(i - 1, 2);
                        i -= 2;
                        stack.Pop();
                    }
                    else if (stack.Peek() == '{' && currentParenthesis == '}')
                    {
                        input = input.Remove(i - 1, 2);
                        i -= 2;
                        stack.Pop();
                    }
                    else if (stack.Peek() == '[' && currentParenthesis == ']')
                    {
                        input = input.Remove(i - 1, 2);
                        i -= 2;
                        stack.Pop();
                    }
                    else
                    {
                        stack.Push(currentParenthesis);
                    }
                }
                else
                {
                    stack.Push(currentParenthesis);
                }
            }
            if (stack.Count == 0)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}
