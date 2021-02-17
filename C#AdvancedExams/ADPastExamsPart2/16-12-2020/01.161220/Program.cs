using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._161220
{
    class Program
    {
        static void Main(string[] args)
        {
            var liquids = new Queue<int>(Console.ReadLine()
                .Split()
                .Select(int.Parse));
            var ingridients = new Stack<int>(Console.ReadLine()
                .Split()
                .Select(int.Parse));
            var cookedFood = new Dictionary<string, int>();
            var targetFood = new Dictionary<int, string>
            {
                {25,"Bread" },
                {50,"Cake" },
                {75,"Pastry" },
                {100,"Fruit Pie" }
            };
            foreach (var food in targetFood)
            {
                cookedFood.Add(food.Value, 0);
            }

            while (liquids.Count > 0 && ingridients.Count > 0)
            {
                var liquid = liquids.Dequeue();
                var ingridient = ingridients.Pop();
                var quantity = liquid + ingridient;
                if (targetFood.ContainsKey(quantity))
                {
                    var food = targetFood[quantity];
                    cookedFood[food] += 1;
                    //targetFood.Remove(quantity);
                    continue;
                }
                ingridients.Push(ingridient + 3);
            }
            if (cookedFood.All(x => x.Value>=1))
            {
                Console.WriteLine("Wohoo! You succeeded in cooking" +
                    " all the food!");
            }
            else
            {
                Console.WriteLine("Ugh, what a pity! You didn't have enough" +
                    " materials to cook everything.");
            }
            if (liquids.Count == 0)
            {
                Console.WriteLine("Liquids left: none");
            }
            else
            {
                Console.WriteLine($"Liquids left: " +
                    $"{string.Join(", ", liquids)}");
            }
            if (ingridients.Count == 0)
            {
                Console.WriteLine("Ingredients left: none");
            }
            else
            {
                Console.WriteLine($"Ingredients left: " +
                    $"{string.Join(", ", ingridients)}");
            }
            foreach (var food in cookedFood.OrderBy(x=>x.Key))
            {
                Console.WriteLine($"{food.Key}: {food.Value}");
            }
        }
    }
}
