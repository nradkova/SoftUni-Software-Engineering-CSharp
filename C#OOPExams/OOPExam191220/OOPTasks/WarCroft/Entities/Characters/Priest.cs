using WarCroft.Entities.Inventory;
using WarCroft.Entities.Characters.Contracts;

namespace WarCroft.Entities.Characters
{
    public class Priest : Character, IHealer
    {
        private const double DefaultBaseHealth = 50;
        private const double DefaultBaseArmor = 25;
        private const double DefaultAbilityPoints = 40;

        public Priest(string name)
            : base(name, DefaultBaseHealth, DefaultBaseArmor,
                  DefaultAbilityPoints, new Backpack())
        {
        }

        public void Heal(Character character)
        {
            EnsureAlive();
            character.EnsureAlive();

            character.Health += AbilityPoints;
            if (character.Health > character.BaseHealth)
            {
                character.Health = character.BaseHealth;
            }
        }
    }
}
