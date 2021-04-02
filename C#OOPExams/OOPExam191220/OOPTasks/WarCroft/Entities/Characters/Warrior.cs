using System;

using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Inventory;

namespace WarCroft.Entities.Characters
{
    public class Warrior : Character,IAttacker
    {
        private const double DefaultBaseHealth = 100;
        private const double DefaultBaseArmor = 50;
        private const double DefaultAbilityPoints = 40;

        public Warrior(string name) 
            : base(name, DefaultBaseHealth, DefaultBaseArmor,
                  DefaultAbilityPoints,new Satchel())
        {
        }

        public void Attack(Character character)
        {
            EnsureAlive();
            character.EnsureAlive();

            if (this.Name==character.Name)
            {
                throw new InvalidOperationException
                    (Constants.ExceptionMessages.CharacterAttacksSelf);
            }
           character.TakeDamage(AbilityPoints);
        }
    }
}
