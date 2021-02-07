using System;
using System.Collections.Generic;
using System.Text;
using MilitaryElite.Enumerations;

namespace MilitaryElite.Contracts
{
   public interface ISpecialisedSoldier
    {
       public SoldierCropEnum Corps { get; }
    }
}
