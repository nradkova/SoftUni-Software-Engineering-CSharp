using System;
using System.Collections;
using System.Collections.Generic;

namespace _07.HotPotato
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine().Split();
            Queue<string> kids = new Queue<string>(names);
            int n = int.Parse(Console.ReadLine());
            while (kids.Count>1)
            {
                for (int i = 1; i < n; i++)
                {
                    kids.Enqueue(kids.Dequeue());
                }
                Console.WriteLine($"Removed {kids.Dequeue()}");
            }
            Console.WriteLine($"Last is {kids.Dequeue()}");
        }
    }
}
