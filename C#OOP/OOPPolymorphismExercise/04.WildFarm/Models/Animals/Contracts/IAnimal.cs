using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Models.Animals.Contracts
{
   public interface IAnimal
    {
        public string Name { get; }
        public double Weight { get; }
      
       
    }
}
