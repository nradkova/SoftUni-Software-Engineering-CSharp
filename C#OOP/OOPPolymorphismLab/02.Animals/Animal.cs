using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
   public abstract class Animal
    {

        public string  Name { get; set; }
        public string FavouriteFood { get; set; }

        public virtual string ExplainSelf()
        {
            return $"I am {Name} and my fovourite food is {FavouriteFood}";
        }
    }
}
