using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals.Birds
{
    public class Owl : Bird
    {
        public Owl(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {
        }

        public override double WeightMultiplier=> 0.25;

        public override ICollection<Type> FoodPreferred =>
            new List<Type>() { typeof(Meat) };

        public override string ProduceSound()
        {
           return "Hoot Hoot";
        }
    }
}
