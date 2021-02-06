using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Models.Animals.Birds
{
    public abstract class Bird : Animal
    {
        protected Bird(string name, double weight,double wingSize)
            : base(name, weight)
        {
            WingSize = wingSize;
        }
        public double WingSize { get; }
        public override string ToString()
        {
            return base.ToString()+
                $"{WingSize}, {Weight}, {FoodEaten}]";
        }
    }
}
