using MilitaryElite.Contracts;
using MilitaryElite.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Models
{
    public class Engineer : SpecialisedSoldier,IEngineer
    {
        public Engineer(int id, string firstName, string lastName
            , decimal salary, SoldierCropEnum corps
            , ICollection<IRepair>repairs)
            : base(id, firstName, lastName, salary, corps)
        {
            Repairs = repairs;
        }

       public ICollection<IRepair> Repairs { get; }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine($"Corps: {this.Corps}");
            sb.AppendLine($"Repairs:");
            foreach (var repair in Repairs)
            {
                sb.AppendLine(repair.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
