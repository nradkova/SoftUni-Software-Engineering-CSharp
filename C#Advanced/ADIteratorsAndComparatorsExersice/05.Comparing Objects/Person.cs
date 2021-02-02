using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace CompareObjects
{
    public class Person : IComparable <Person>
    {
        private string name;
        private int age;
        private string town;
        //private List<Person> people;
        public Person(string name, int age, string town)
        {
            this.name = name;
            this.age = age;
            this.town = town;
        }

        public int CompareTo(Person other)
        {
            int result = -1;
            if (other != null)
            {
                if (this.name.CompareTo(other.name) == 0
                    && this.age.CompareTo(other.age) == 0
                    && this.town.CompareTo(other.town) == 0)
                {
                    return result = 0;
                }
            }
            return result;
        }
    }
}
