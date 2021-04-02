using System;

using WarCroft.Constants;
using WarCroft.Entities.Inventory;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Characters.Contracts
{
    public abstract class Character
    {
        private string name;
       
        protected Character(string name, double health,
            double armor, double abilityPoints, Bag bag)
        {
            Name = name;
            BaseHealth = health;
            Health = health;
            BaseArmor= armor;
            Armor = armor;
            AbilityPoints = abilityPoints;
            Bag = bag;
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException
                        (Constants.ExceptionMessages
                        .CharacterNameInvalid);						
                }
                name = value;
            }
        }

        public double BaseHealth { get; }

        public double Health { get;  set; }

        public double BaseArmor { get; }

        public double Armor { get;  set; }

        public bool IsAlive { get; set; } = true;

        public double AbilityPoints { get; private set; }
      
        public Bag Bag { get; private set; }
       
        public void EnsureAlive()
        {
            if (!IsAlive)
            {
                throw new InvalidOperationException
                    (ExceptionMessages.AffectedCharacterDead);
            }
        }

        public void TakeDamage(double hitPoints)
        {
            EnsureAlive();
            if (hitPoints>Armor)
            {
                Health -= hitPoints - Armor;
                Armor = 0;
            }
            else
            {
                Armor -= hitPoints;
            }
            if (Health<=0)
            {
                Health = 0;
                IsAlive = false;
            }
        }

        public void UseItem(Item item)
        {
            EnsureAlive();
            item.AffectCharacter(this);
        }

    }
}