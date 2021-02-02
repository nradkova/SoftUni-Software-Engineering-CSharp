using System;
using System.Collections.Generic;
using System.Text;

namespace _06.EqualityLogic
{
   public class Person : IComparable<Person>
    {

        private string name;
        private int age;
       
        public Person(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

        public int CompareTo(Person other)
        {
            int result = 1;
            if (other != null)
            {
                result = this.name.CompareTo(other.name);
                if (this.name.CompareTo(other.name) == 0)
                {
                    return result =this.age.CompareTo(other.age);
                }
            }
            return result;
        }
        public bool Equals(Person person)
        {
            if (this.name.CompareTo(person.name) == 0
                    && this.age.CompareTo(person.age) == 0)
            {
                return true;
            }
            return false;
        }
        public override bool Equals(object obj)
        {
            if (obj!=null && obj is Person person)
            {
                if (this.name.CompareTo(person.name) == 0
                    && this.age.CompareTo(person.age) == 0)
                {
                    return true;
                }
            }
            return false;
        }
        public override int GetHashCode()
        {
            return this.name.GetHashCode()+this.age.GetHashCode();
        }
    }
}
