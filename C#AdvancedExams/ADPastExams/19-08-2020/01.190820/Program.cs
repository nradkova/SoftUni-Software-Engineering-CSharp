using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._190820
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> lilies = new Stack<int>(
                Console.ReadLine().Split(", ")
                .Select(int.Parse).ToList());
            Queue<int> roses = new Queue<int>(
                Console.ReadLine().Split(", ")
                .Select(int.Parse).ToList());
            int wreathCount = 0;
            int leftFlowers = 0;

            while (lilies.Count > 0 && roses.Count > 0)
            {
                int currentLilies = lilies.Peek();
                int currentRoses = roses.Peek();
                if (currentLilies + currentRoses == 15)
                {
                    wreathCount++;
                    lilies.Pop();
                    roses.Dequeue();
                }
                else if (currentLilies + currentRoses < 15)
                {
                    leftFlowers += lilies.Pop() + roses.Dequeue();
                }
                else
                {
                    if (currentLilies < 2)
                    {
                        leftFlowers += lilies.Pop() + roses.Dequeue();
                    }
                    else
                    {
                        lilies.Push(lilies.Pop() - 2);
                    }
                }
            }

            wreathCount += leftFlowers / 15;
            if (wreathCount >= 5)
            {
                Console.WriteLine($"You made it, you are going to the competition with 5 wreaths!");
            }
            else
            {
                Console.WriteLine($"You didn't make it, you need {5 - wreathCount} wreaths more!");
            }
        }

    }
}
