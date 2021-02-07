using System;
using System.Collections.Generic;
using System.Text;
using MilitaryElite.Contracts;

namespace MilitaryElite.Models
{
   public class LieutenantGeneral:Private,ILieutenantGeneral
    {
        public LieutenantGeneral(int id, string firstName
            ,string lastName, decimal salary,ICollection<IPrivate>privates)
            :base(id,firstName,lastName,salary)
        {
            Privates = privates;
          
        }
        public ICollection<IPrivate> Privates { get;}
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine($"Privates:");
            foreach (var @private in Privates)
            {
                sb.AppendLine(@private.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
