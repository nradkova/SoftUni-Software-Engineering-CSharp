using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._240219
{
    class Program
    {
        static void Main(string[] args)
        {
            int capacity = int.Parse(Console.ReadLine());
            Stack<string> inputData = new Stack<string>
                (Console.ReadLine().Split().ToList());
            Queue<string> halls = new Queue<string>();

            List<int> guests = new List<int>();
            int currentGroup = 0;
            int number = 0;
            string currentHall = string.Empty;
            int currentCapacity = capacity;
            while (inputData.Count > 0)
            {
                if (Int32.TryParse(inputData.Peek(), out number))
                {
                    currentGroup = number;
                    if (currentGroup <= currentCapacity
                        && currentHall != string.Empty)
                    {
                        currentCapacity -= currentGroup;
                        guests.Add(currentGroup);
                    }
                    else if (currentGroup > currentCapacity
                             && currentHall != string.Empty)
                    {
                        Console.WriteLine($"{currentHall} ->" +
                            $" {string.Join(", ", guests)} ");
                        currentHall = string.Empty;
                        guests.Clear();
                        currentCapacity = capacity;

                        if (halls.Count > 0)
                        {
                            currentHall = halls.Dequeue();
                            currentCapacity -= currentGroup;
                            guests.Add(currentGroup);
                        }
                    }
                }
                else
                {
                    if (currentHall != string.Empty)
                    {
                        halls.Enqueue(inputData.Peek());
                    }
                    else
                    {
                        currentHall = inputData.Peek();
                    }
                }
                inputData.Pop();
            }
        }
    }
}
