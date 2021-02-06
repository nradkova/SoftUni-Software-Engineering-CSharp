using Raiding.Contracts;
using Raiding.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Raiding.Core
{
    public class Engine : IEngine
    {
        private readonly ICollection<BaseHero> heroes;
        private readonly HeroFactory heroFactory;

        public Engine()
        {
            heroes = new List<BaseHero>();
            heroFactory = new HeroFactory();
        }
        public void Run()
        {
            int n = int.Parse(Console.ReadLine());
            while(n>0)
            {
                string heroName = Console.ReadLine();
                string heroType = Console.ReadLine();
                try
                {
                    BaseHero hero = heroFactory.CreateHero(heroName, heroType);
                    heroes.Add(hero);
                    n--;
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }
            int bossPower = int.Parse(Console.ReadLine());
            foreach (var hero in heroes)
            {
                Console.WriteLine(hero.CastAbility());
            }
            if (heroes.Sum(x=>x.Power)>=bossPower)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }

    }
}
