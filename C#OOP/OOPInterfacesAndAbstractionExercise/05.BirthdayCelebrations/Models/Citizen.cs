using System;
using System.Collections.Generic;
using System.Text;

namespace BirthdayCelebrations.Models
{
    public class Citizen : IInhabitable,IBorn
    {
        public Citizen(string name, int age,string id,string birthDate)
        {
            Name = name;
            Age = age;
            Id = id;
            BirthDate = birthDate;
        }
        public string Name { get; }
        public int Age { get;}
        public  string Id { get; }
        public  string BirthDate { get; }

        public void PrintBirthDate()
        {
            Console.WriteLine(BirthDate);
        }

        public void PrintId()
        {
            Console.WriteLine(Id); ;
        }
    }
}
