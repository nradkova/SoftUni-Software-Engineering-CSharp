using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals.Mammals
{
   public  class Dog:Mammal
    {
        public Dog(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion)
        {
        }

        public override double WeightMultiplier => 0.40;

        public override ICollection<Type> FoodPreferred =>
            new List<Type> { typeof(Meat)};

        public override string ProduceSound()
        {
            return "Woof!";
        }
    }
}
