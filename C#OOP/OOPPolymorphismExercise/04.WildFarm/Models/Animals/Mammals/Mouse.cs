using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.Animals.Birds;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals.Mammals
{
    public class Mouse : Mammal
    {
        public Mouse(string name, double weight, string livingRegion)
            : base(name, weight, livingRegion)
        {
        }

        public override double WeightMultiplier => 0.10;

        public override ICollection<Type> FoodPreferred => 
            new List<Type> { typeof (Vegetable),typeof(Fruit)};

        public override string ProduceSound()
        {
            return "Squeak";
        }
    }
}
