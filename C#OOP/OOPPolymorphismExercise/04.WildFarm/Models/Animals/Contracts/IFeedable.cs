using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.Foods.Contracts;

namespace WildFarm.Models.Animals.Contracts
{
  public  interface IFeedable
    {
        public int FoodEaten { get; }
        public abstract double WeightMultiplier { get; }
        public abstract ICollection<Type> FoodPreferred { get; }

        public void Feed(IFood food);
    }
}
