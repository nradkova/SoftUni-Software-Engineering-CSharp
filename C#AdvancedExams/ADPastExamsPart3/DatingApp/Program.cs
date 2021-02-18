using System;
using System.Collections.Generic;
using System.Linq;

namespace DatingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var males = new Stack<int>
                (Console.ReadLine()
                .Split()
                .Select(int.Parse));
            var females = new Queue<int>
                (Console.ReadLine()
                .Split()
                .Select(int.Parse));
            var matches = 0;
            while (males.Count>0&&females.Count>0)
            {
                int male = males.Peek();
                int female = females.Peek();
                if (female<= 0)
                {
                    females.Dequeue();
                    continue;
                }
                if (male <= 0)
                {
                    males.Pop();
                    continue;
                }
                if (female%25==0)
                {
                    females.Dequeue();
                    females.Dequeue();
                    continue;
                }
                if (male % 25 == 0)
                {
                    males.Pop();
                    males.Pop();
                    continue;
                }
                if (male==female)
                {
                    matches++;
                    females.Dequeue();
                    males.Pop();
                }
                else
                {
                    females.Dequeue();
                    males.Push(males.Pop()-2);
                }
            }
            Console.WriteLine($"Matches: {matches}");
            if (males.Count==0)
            {
                Console.WriteLine("Males left: none");
            }
            else
            {
                Console.WriteLine($"Males left: {string.Join(", ",males)}");
            }
            if (females.Count == 0)
            {
                Console.WriteLine("Females left: none");
            }
            else
            {
                Console.WriteLine($"Females left: {string.Join(", ", females)}");
            }
        }
    }
}
