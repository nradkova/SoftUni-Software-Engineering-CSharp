using System;
using System.Collections.Generic;
using System.Linq;
using FoodShortage.Models;

namespace FoodShortage
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IBuyer> buyers = new List<IBuyer>();
            int numberOfPeople = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfPeople; i++)
            {
                string[] info = Console.ReadLine().Split();
                if (info.Length == 3)
                {
                    IBuyer rebel = new Rebel(info[0], int.Parse(info[1]), info[2]);
                    buyers .Add(rebel);
                }
                if (info.Length == 4)
                {
                    IBuyer citizen = new Citizen(info[0], int.Parse(info[1]), info[2],info[3]);
                    buyers.Add(citizen);
                }
            }
            string name = string.Empty;
            while ((name =Console.ReadLine())!="End")
            {
                if (buyers.Any(b => b.Name == name))
                {
                    IBuyer buyer = buyers.FirstOrDefault(b => b.Name == name);
                    buyer.BuyFood();
                }
            }
            int totalFood =buyers.Sum(b=>b.Food);
            Console.WriteLine(totalFood);
        }
    }
}
