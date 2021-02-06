using Raiding.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding.Models
{
   public class Druid:BaseHero
    {
        private const int POWER = 80;
        public Druid(string name)
            : base(name)
        {
            Power = POWER;
        }

        public override string CastAbility()
        {
            return string.Format(Common.Constants.HealingCastAbilityMsg
                , this.GetType().Name, Name, Power);
        }
    }
}
