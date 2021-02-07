using System;
using System.Collections.Generic;
using System.Text;
using MilitaryElite.Contracts;
using MilitaryElite.Enumerations;

namespace MilitaryElite.Models
{
    public class SpecialisedSoldier : Private,ISpecialisedSoldier
    {
      
        public SpecialisedSoldier(int id, string firstName
            , string lastName, decimal salary
            , SoldierCropEnum corps)
            : base(id, firstName, lastName, salary)
        {
            Corps = corps;
        }
      
        public SoldierCropEnum Corps { get; }
    }
}
