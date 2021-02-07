using System;
using System.Collections.Generic;
using System.Text;

namespace BirthdayCelebrations.Models
{
    public class Robot : IInhabitable
    {
        public Robot(string model,string id,string birthDate)
        {
            Model = model;
            Id = id;
            BirthDate = birthDate;
        }
        public string  Model { get;}
        public  string Id { get; }
        public  string BirthDate { get; }

        public void PrintId()
        {
            Console.WriteLine(Id); ;
        }
    }
}
