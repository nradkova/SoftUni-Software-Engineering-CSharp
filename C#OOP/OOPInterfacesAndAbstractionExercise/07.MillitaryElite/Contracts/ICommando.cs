using System;
using System.Collections.Generic;
using System.Text;
using MilitaryElite.Models;

namespace MilitaryElite.Contracts
{
   public interface ICommando
    {
        public ICollection<IMission> Missions { get;}
    }
}
