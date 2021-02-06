using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals.Mammals.Felines
{
    public class Tiger : Feline
    {
        public Tiger(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed)
        {
        }

        public override double WeightMultiplier =>1.00;

        public override ICollection<Type> FoodPreferred =>
           new List<Type>() {typeof(Meat) };

        public override string ProduceSound()
        {
            return "ROAR!!!";

        }
    }
}
