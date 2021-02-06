using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals.Birds
{
  public class Hen:Bird
    {
        public Hen(string name, double weight, double wingSize)
           : base(name, weight, wingSize)
        {
        }

        public override double WeightMultiplier => 0.35;

        public override ICollection<Type> FoodPreferred =>
            new List<Type>() { typeof(Meat),typeof(Vegetable)
                ,typeof(Seeds),typeof(Fruit) };

        public override string ProduceSound()
        {
            return "Cluck";
        }
    }
}
