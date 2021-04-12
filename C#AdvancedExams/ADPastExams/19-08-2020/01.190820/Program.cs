using System;
using System.Collections.Generic;
using System.Linq;

namespace Practice
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> lilies = new Stack<int>
                (Console.ReadLine()
                .Split(", ")
                .Select(int.Parse));
            Queue<int> roses = new Queue<int>
                (Console.ReadLine()
                .Split(", ")
                .Select(int.Parse));
            int target = 5;
            int flowersLeft = 0;
            int wreaths = 0;
            while (lilies.Count > 0 & roses.Count > 0)
            {
                var lily = lilies.Pop();
                var rose = roses.Peek();
                if (lily + rose == 15)
                {
                    roses.Dequeue();
                    wreaths++;
                }
                else if (lily + rose > 15)
                {
                    lilies.Push(lily - 2);
                }
                else 
                {
                    roses.Dequeue();
                    flowersLeft += lily + rose;
                }
            }
            wreaths += flowersLeft / 15;
            if (wreaths >= target)
            {
                Console.WriteLine($"You made it, you are going to " +
                    $"the competition with {wreaths} wreaths!");
            }
            else
            {
                Console.WriteLine($"You didn't make it," +
                    $" you need {target - wreaths} wreaths more!");
            }
        }
    }
}
