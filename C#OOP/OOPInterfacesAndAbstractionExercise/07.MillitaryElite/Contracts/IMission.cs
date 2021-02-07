using System;
using System.Collections.Generic;
using System.Text;
using MilitaryElite.Enumerations;

namespace MilitaryElite.Contracts
{
   public  interface IMission
    {
        public string CodeName { get;}
        public MissionStateEnum State { get; }
        public void CompleteMission(string mission);
    }
}
