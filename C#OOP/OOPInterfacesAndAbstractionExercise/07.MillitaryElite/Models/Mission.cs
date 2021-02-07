using System;
using System.Collections.Generic;
using System.Text;
//using MilitaryElite.Enumerations;
using MilitaryElite.Contracts;
using MilitaryElite.Enumerations;

namespace MilitaryElite.Models
{
    public class Mission:IMission
    {
       
        public Mission(string codeName, MissionStateEnum state)
        {
            CodeName = codeName;
            State = state;
        }
        public string CodeName { get; set; }
        public MissionStateEnum State { get; }

        public void CompleteMission(String mission)
        {
            
        }
        public override string ToString()
        {
            return $"Code Name: {CodeName} State: {State}";
        }
    }
}
