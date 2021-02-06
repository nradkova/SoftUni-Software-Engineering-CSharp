using Raiding.Contracts;
using Raiding.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding.Factories
{
  public class HeroFactory
    {
       
        public BaseHero CreateHero(string name,string heroType)
        {
            BaseHero hero = null;
            if (heroType== "Druid")
            {
                hero = new Druid(name);
            }
           else if (heroType == "Paladin")
            {
                hero = new Paladin(name);
            }
          else  if (heroType == "Rogue")
            {
                hero = new Rogue(name);
            }
           else if (heroType == "Warrior")
            {
                hero = new Warrior(name);
            }
            else
            {
                throw new ArgumentException(Common.Constants.InvalidHeroExcMsg);
            }
                return hero;
        }
    }
}
