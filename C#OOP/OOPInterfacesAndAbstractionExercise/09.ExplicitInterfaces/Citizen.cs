using System;
using System.Collections.Generic;
using System.Text;

namespace ExplicitInterfaces
{
    public class Citizen : IPerson, IResident
    {
        public Citizen(string name, string country, int age)
        {
            Name = name;
            Age = age;
            Country = country;
        }
        public string Name { get; }

        public int Age { get; }

        public string Country { get; }

        public void GetName()
        {
            if (this is IPerson)
            {
                Console.WriteLine($"{Name}");
            }
           if (this is IResident)
            {
                Console.WriteLine($"Mr/Ms/Mrs {Name}");
            }
        }
    }
}
