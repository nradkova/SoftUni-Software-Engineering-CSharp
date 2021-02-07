using MilitaryElite.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Contracts
{
   public interface ILieutenantGeneral
    {
      public  ICollection<IPrivate> Privates { get; }
    }
}
