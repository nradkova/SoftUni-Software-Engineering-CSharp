using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.FashionBoutique
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] clothes = Console.ReadLine().Split()
                 .Select(int.Parse).ToArray();
            Stack<int> stack = new Stack<int>(clothes);
            int capacity = int.Parse(Console.ReadLine());
            int currentCapacity = capacity;
            int count = 0;
            while (stack.Count > 0)
            {
                while (currentCapacity > 0)
                {
                    if ( stack.Count > 0&& stack.Peek() <= currentCapacity)
                    {
                        currentCapacity -= stack.Pop();
                    }
                    else if(stack.Count == 0 || stack.Peek() > currentCapacity)
                    {
                        break;
                    }
                }
                count++;
                currentCapacity = capacity;
            }
            Console.WriteLine(count);
        }
    }
}
