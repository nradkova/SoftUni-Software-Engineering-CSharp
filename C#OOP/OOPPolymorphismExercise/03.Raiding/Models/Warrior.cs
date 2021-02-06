using Raiding.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding.Models
{
    public class Warrior : BaseHero
    {
        private const int POWER = 100;
        public Warrior(string name) 
            : base(name)
        {
            Power = POWER;
        }

        public override string CastAbility()
        {
            return string.Format(Common.Constants.HittingCastAbilityMsg
                ,this.GetType().Name,Name,Power);
        }
       
    }
}
