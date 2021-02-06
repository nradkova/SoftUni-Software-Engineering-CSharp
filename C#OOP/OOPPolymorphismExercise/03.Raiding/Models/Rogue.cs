using Raiding.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding.Models
{
   public class Rogue:BaseHero
    {
        private const int POWER = 80;
        public Rogue(string name)
            : base(name)
        {
            Power = POWER;
        }

        public override string CastAbility()
        {
            return string.Format(Common.Constants.HittingCastAbilityMsg
                , this.GetType().Name, Name, Power);
        }
    }
}
