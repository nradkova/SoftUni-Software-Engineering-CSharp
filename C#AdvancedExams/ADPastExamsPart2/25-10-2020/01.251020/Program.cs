using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._25102020
{
    class Program
    {
        static void Main(string[] args)
        {
            var tasks = new Stack<int>
                (Console.ReadLine()
                .Split(", ")
                .Select(int.Parse));
            var threads = new Queue<int>
                (Console.ReadLine()
                .Split(" ")
                .Select(int.Parse));
            var target =int.Parse(Console.ReadLine());
            var lastThread = 0;
            while (threads.Count>0&&tasks.Count>0)
            {
                var task = tasks.Peek();
                var thread = threads.Peek();
                if (target == task)
                {
                    lastThread = thread;
                    break;
                }
                if (thread>=task)
                {
                    tasks.Pop();
                    threads.Dequeue();
                }
                else
                {
                    threads.Dequeue();
                }
            }
            Console.WriteLine($"Thread with value {lastThread}" +
                $" killed task {target}");
            Console.WriteLine(string.Join(" ",threads));
        }
    }
}
