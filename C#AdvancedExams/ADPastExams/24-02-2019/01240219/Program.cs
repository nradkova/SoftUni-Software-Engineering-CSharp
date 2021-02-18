using System;
using System.Collections.Generic;

namespace _01._240219
{
    class Program
    {
        static void Main(string[] args)
        {
            int capacity = int.Parse(Console.ReadLine());
            var line = new Stack<string>(Console.ReadLine().Split());
            var halls = new Queue<string>();
            var visitors = new Queue<int>();
            var openHall = string.Empty;
            var currentCapacity = capacity;
            while (line.Count > 0)
            {
                var current = line.Peek();

                if (int.TryParse(current, out int group) && halls.Count > 0)
                {
                    if (currentCapacity >= group)
                    {
                        line.Pop();
                        visitors.Enqueue(group);
                        currentCapacity -= group;
                        continue;
                    }

                    Console.WriteLine($"{openHall} -> {string.Join(", ", visitors)}");
                    halls.Dequeue();

                    if (halls.Count == 0)
                    {
                        return;
                    }
                    currentCapacity = capacity;
                    visitors = new Queue<int>();
                    openHall = halls.Peek();
                }
                else if (!int.TryParse(current, out int num))
                {
                    halls.Enqueue(line.Pop());
                    openHall = halls.Peek();
                }
                else
                {
                    line.Pop();
                }
            }
        }
    }
}
