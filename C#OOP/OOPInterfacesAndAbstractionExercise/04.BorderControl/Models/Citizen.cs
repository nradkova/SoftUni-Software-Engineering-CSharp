using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public class Citizen : Inhabitant
    {
        public Citizen(string name, int age,string id)
        {
            Name = name;
            Age = age;
            Id = id;
        }
        public string Name { get; }
        public int Age { get;}
        public override string Id { get; }
    }
}
