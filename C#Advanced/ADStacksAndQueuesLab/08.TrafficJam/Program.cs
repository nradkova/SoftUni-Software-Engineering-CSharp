using System;
using System.Collections.Generic;

namespace _08.TrafficJam
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string command = string.Empty;
            Queue<string> cars = new Queue<string>();
            int count = 0;
            while ((command=Console.ReadLine())!="end")
            {
                if (command!="green")
                {
                    cars.Enqueue(command);
                }
                else
                {
                    if (n>cars.Count)
                    {
                        n = cars.Count;
                    }
                    for (int i = 0; i < n; i++)
                    {
                        Console.WriteLine($"{cars.Dequeue()} passed!");
                        count++;
                    }
                }
            }
            Console.WriteLine($"{count} cars passed the crossroads.");
        }
    }
}
