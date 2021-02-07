using System;
using System.Collections.Generic;
using System.Text;

namespace FoodShortage.Models
{
    public class Citizen : IBuyer
    {
        public Citizen(string name, int age,string id,string birthDate)
        {
            Name = name;
            Age = age;
            Id = id;
            BirthDate = birthDate;
            Food = 0;
        }
        public string Name { get; }
        public int Age { get;}
        public  string Id { get; }
        public  string BirthDate { get; }
        public int Food { get; private set; }

        public int BuyFood()
        {
            return Food += 10;
        }
    }
}
