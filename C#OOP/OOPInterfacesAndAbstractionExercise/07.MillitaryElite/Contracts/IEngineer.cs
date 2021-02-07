using MilitaryElite.Models;
using System;
using System.Collections.Generic;
using System.Text;


namespace MilitaryElite.Contracts
{
   public interface IEngineer
    {
       public ICollection<IRepair> Repairs { get; }
    }
}
