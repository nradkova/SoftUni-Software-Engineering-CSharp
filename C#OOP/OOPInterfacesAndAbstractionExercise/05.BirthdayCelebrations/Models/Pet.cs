using System;
using System.Collections.Generic;
using System.Text;

namespace BirthdayCelebrations.Models
{
    public class Pet : IBorn
    {
        public Pet(string name, string birthDate)
        {
            Name = name;
            BirthDate = birthDate;
        }
        public string Name { get; set; }
        public string BirthDate { get; }
        public void PrintBirthDate()
        {
            Console.WriteLine(BirthDate);
        }
    }
}
