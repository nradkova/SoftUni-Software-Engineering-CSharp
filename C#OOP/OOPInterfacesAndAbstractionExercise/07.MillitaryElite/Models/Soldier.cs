using MilitaryElite.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Models
{
   public class Soldier:ISoldier
    {
        public Soldier(int id, string firstName, string lastName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
        }
        public int  Id { get; }
        public string FirstName { get;}
        public string LastName { get;}
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
