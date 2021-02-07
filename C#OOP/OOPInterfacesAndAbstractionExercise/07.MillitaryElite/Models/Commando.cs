using MilitaryElite.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;
using MilitaryElite.Contracts;

namespace MilitaryElite.Models
{
    public class Commando : SpecialisedSoldier,ICommando
    {
        private readonly ICollection<Mission> missions;

        public Commando(int id, string firstName, string lastName
            , decimal salary,  SoldierCropEnum corps
            , ICollection<IMission> missions)
            : base(id, firstName, lastName, salary, corps)
        {
            Missions = missions;
        }

        public ICollection<IMission> Missions { get; set; }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine($"Corps: {Corps}");
            sb.AppendLine($"Missions:");
            foreach (var mission in Missions)
            {
                sb.AppendLine(mission.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
