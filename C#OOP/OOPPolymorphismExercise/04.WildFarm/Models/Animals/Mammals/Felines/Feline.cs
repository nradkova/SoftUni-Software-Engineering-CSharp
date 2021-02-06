using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Models.Animals.Mammals.Felines
{
    public abstract class Feline : Mammal
    {
        protected Feline(string name, double weight
            , string livingRegion,string breed)
            : base(name, weight, livingRegion)
        {
            Breed = breed;
        }

        public string Breed { get; }
        public override string ToString()
        {
            return $"{this.GetType().Name} [{ Name}, { Breed}," +
                $" { Weight}, { LivingRegion}, { FoodEaten}]";
        }
    }
}
