using System;
using System.Collections.Generic;
using System.Text;

namespace FoodShortage.Models
{
    public class Rebel : IBuyer
    {
        public Rebel(string name,int age, string group)
        {
            Name = name;
            Age = age;
            Group = group;
            Food = 0;
        }

        public string Name { get; set; }
        public int Age { get; }
        public string Group { get; }
        public int Food { get; private set; }


        public int BuyFood()
        {
          return  Food += 5;
        }
    }
}
