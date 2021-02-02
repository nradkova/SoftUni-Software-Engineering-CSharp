using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._220220
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> firstLine = Console.ReadLine().Split()
               .Select(int.Parse).ToList();
            List<int> secondLine = Console.ReadLine().Split()
                .Select(int.Parse).ToList();

            Queue<int> firstBox = new Queue<int>(firstLine);
            Stack<int> secondBox = new Stack<int>(secondLine);
            List<int> claimedBox = new List<int>();
            while (firstBox.Count > 0 && secondBox.Count > 0)
            {
                int firstBoxItem = firstBox.Peek();
                int secondBoxItem = secondBox.Peek();
                if ((firstBoxItem + secondBoxItem) % 2 == 0)
                {
                    claimedBox.Add(firstBoxItem + secondBoxItem);
                    firstBox.Dequeue();
                    secondBox.Pop();
                }
                else
                {
                    firstBox.Enqueue(secondBox.Pop());
                }

            }
            if (firstBox.Count == 0)
            {
                Console.WriteLine($"First lootbox is empty");
            }
            else
            {
                Console.WriteLine($"Second lootbox is empty");
            }
            int claimedItems = claimedBox.Sum();
            if (claimedItems >= 100)
            {
                Console.WriteLine($"Your loot was epic! Value: {claimedItems}");
            }
            else
            {
                Console.WriteLine($"Your loot was poor... Value: {claimedItems}");
            }

        }
    }
}
