using System;
using System.Collections.Generic;

namespace _06.Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, int>> wardrobe = new Dictionary<string, Dictionary<string, int>>();
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(" -> ");
                string[] items = input[1].Split(',');
                if (!wardrobe.ContainsKey(input[0]))
                {
                    wardrobe.Add(input[0], new Dictionary<string, int>());
                }
                for (int j = 0; j < items.Length; j++)
                {
                    if (!wardrobe[input[0]].ContainsKey(items[j]))
                    {
                        wardrobe[input[0]].Add(items[j], 0);
                    }
                    wardrobe[input[0]][items[j]]++;
                }  
            }
            string[] request = Console.ReadLine().Split();
            string colour = request[0];
            string cloth = request[1];
            foreach (var pair in wardrobe)
            {
                Console.WriteLine($"{pair.Key} clothes:");
                foreach (var item in pair.Value)
                {
                    if (pair.Key==colour
                        &&item.Key==cloth)
                    {
                        Console.WriteLine($"* {item.Key} - {item.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {item.Key} - {item.Value}");
                    }
                }
            }
        }
    }
}
