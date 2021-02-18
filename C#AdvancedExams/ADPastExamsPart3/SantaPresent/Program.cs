using System;
using System.Collections.Generic;
using System.Linq;

namespace SantaPresent
{
    class Program
    {
        static void Main(string[] args)
        {
            var materials = new Stack<int>
                 (Console.ReadLine()
                 .Split()
                 .Select(int.Parse));
            var magicLevels = new Queue<int>
                (Console.ReadLine()
                .Split()
                .Select(int.Parse));
            var presents = new Dictionary<string, int>
            {
                { "Doll",150},
                { "Wooden train",250},
                { "Teddy bear",300},
                { "Bicycle",400}
            };
            var crafted = new SortedDictionary<string, int>();
            while (magicLevels.Count > 0 && materials.Count > 0)
            {
                var magic = magicLevels.Peek();
                var material = materials.Peek();
                if (magic == 0)
                {
                    magicLevels.Dequeue();
                    continue;
                }
                if (material == 0)
                {
                    materials.Pop();
                    continue;
                }
                if (material == 0 && magic == 0)
                {
                    magicLevels.Dequeue();
                    materials.Pop();
                    continue;
                }
                var product = magic * material;
                if (product < 0)
                {
                    materials.Push(materials.Pop() + magicLevels.Dequeue());
                    continue;
                }
                if (!presents.Any(x=>x.Value==product))
                {
                    magicLevels.Dequeue();
                    materials.Push(materials.Pop() + 15);
                    continue;
                }
                foreach (var present in presents)
                {
                    if (product==present.Value)
                    {
                        if (!crafted.ContainsKey(present.Key))
                        {
                            crafted.Add(present.Key, 0);
                        }
                        crafted[present.Key] += 1;
                        magicLevels.Dequeue();
                        materials.Pop();
                        break;
                    }
                }
            }
            if ((crafted.ContainsKey("Doll")
                &&crafted.ContainsKey("Wooden train"))
                || (crafted.ContainsKey("Teddy bear") 
                && crafted.ContainsKey("Bicycle")))
            {
                Console.WriteLine("The presents are crafted! Merry Christmas!");
            }
            else
            {
                Console.WriteLine("No presents this Christmas!");
            }
            if (materials.Count>0)
            {
                Console.WriteLine($"Materials left: " +
                    $"{string.Join(", ",materials)}");
            }
            if (magicLevels.Count > 0)
            {
                Console.WriteLine($"Magic left: " +
                    $"{string.Join(", ", magicLevels)}");
            }
            foreach (var toy in crafted)
            {
                Console.WriteLine($"{toy.Key}: {toy.Value}");
            }
        }
    }
}
