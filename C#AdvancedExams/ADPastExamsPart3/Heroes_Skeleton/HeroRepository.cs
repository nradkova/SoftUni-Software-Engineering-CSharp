using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heroes
{
    public class HeroRepository
    {
        private List<Hero> data;

        public HeroRepository()
        {
            data = new List<Hero>();
        }

        public int Count => data.Count;

        public void Add(Hero hero)
        {
            data.Add(hero);
        }
        public void Remove(string name)
        {
            var hero = data.FirstOrDefault(x => x.Name == name);
            if (hero!=null)
            {
                data.Remove(hero);
            }
        }
        public Hero GetHeroWithHighestStrength()
        {
            return data.OrderByDescending(x => x.Item.Strength).First();
        }
        public Hero GetHeroWithHighestAbility()
        {
            return data.OrderByDescending(x => x.Item.Ability).First();
        }
        public Hero GetHeroWithHighestIntelligence()
        {
            return data.OrderByDescending(x => x.Item.Intelligence).First();
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var hero in data)
            {
                sb.AppendLine(hero.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
