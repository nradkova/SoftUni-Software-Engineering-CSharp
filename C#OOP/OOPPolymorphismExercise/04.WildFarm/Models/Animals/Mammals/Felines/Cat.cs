using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals.Mammals.Felines
{
    public class Cat : Feline
    {
        public Cat(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed)
        {
        }

        public override double WeightMultiplier =>0.30;

        public override ICollection<Type> FoodPreferred => 
           new List<Type>() {typeof (Vegetable) ,typeof (Meat)};

        public override string ProduceSound()
        {
           return "Meow";
        }
    }
}
