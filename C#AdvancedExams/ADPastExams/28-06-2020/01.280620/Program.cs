using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._280620
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> firstLine = Console.ReadLine().Split(", ")
                .Select(int.Parse).ToList();
            List<int> secondLine = Console.ReadLine().Split(", ")
                .Select(int.Parse).ToList();
            Queue<int> effects = new Queue<int>(firstLine);
            Stack<int> casings = new Stack<int>(secondLine);
            int daturaCount = 0;
            int cherryCount = 0;
            int smokeCount = 0;
            bool GoalAchieved = false;
            while (effects.Count > 0 && casings.Count > 0)
            {
                int effect = effects.Peek();
                int casing = casings.Peek();
                if (effect + casing == 40)
                {
                    daturaCount++;
                    effects.Dequeue();
                    casings.Pop();
                }
                else if (effect + casing == 60)
                {
                    cherryCount++;
                    effects.Dequeue();
                    casings.Pop();
                }
                else if (effect + casing == 120)
                {
                    smokeCount++;
                    effects.Dequeue();
                    casings.Pop();
                }
                else
                {
                    if (casings.Peek() >= 5)
                    {
                        casings.Push(casings.Pop() - 5);
                    }
                }
                if (daturaCount >= 3 && cherryCount >= 3 && smokeCount >= 3)
                {
                    GoalAchieved = true;
                    break;
                }
            }
            if (GoalAchieved)
            {
                Console.WriteLine("Bene! You have successfully filled the bomb pouch!");
            }
            else
            {
                Console.WriteLine("You don't have enough materials to fill the bomb pouch.");
            }
            if (effects.Count == 0)
            {
                Console.WriteLine($"Bomb Effects: empty");
            }
            else
            {
                Console.WriteLine($"Bomb Effects: " +
                    $"{string.Join(", ", effects.ToList())}");
            }
            if (casings.Count == 0)
            {
                Console.WriteLine($"Bomb Casings: empty");
            }
            else
            {
                Console.WriteLine($"Bomb Casings: " +
                    $"{string.Join(", ", casings.ToList())}");
            }
            Console.WriteLine($"Cherry Bombs: {cherryCount}");
            Console.WriteLine($"Datura Bombs: {daturaCount}");
            Console.WriteLine($"Smoke Decoy Bombs: {smokeCount}");

        }
    }
}
