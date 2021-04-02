using System;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Collections.Generic;

using WarCroft.Constants;
using WarCroft.Entities.Items;
using WarCroft.Entities.Characters;
using WarCroft.Entities.Characters.Contracts;

namespace WarCroft.Core
{
    public class WarController
    {
        private readonly ICollection<Character> characterParty;
        private readonly ICollection<Item> itemPool;
        public WarController()
        {
            characterParty = new List<Character>();
            itemPool = new List<Item>();
        }

        public string JoinParty(string[] args)
        {
            string characterType = args[0];
            Type type = GetDefaultType(characterType);
            if (type == null)
            {
                throw new ArgumentException
                   (String.Format(ExceptionMessages
                   .InvalidCharacterType, characterType));
            }

            Character character 
                = CreateCharacter(type,args.Skip(1).ToArray());
          
            characterParty.Add(character);

            return string.Format(SuccessMessages.JoinParty, character.Name);
        }

        public string AddItemToPool(string[] args)
        {
            string itemName = args[0];

            Type type = GetDefaultType(itemName);
            if (type ==null)
            {
                throw new ArgumentException
                   (String.Format(ExceptionMessages
                   .InvalidItem, itemName));

            }

            Item item = CreateItem(type);
            
            itemPool.Add(item);

            return string.Format(SuccessMessages
                .AddItemToPool, itemName);
        }

        public string PickUpItem(string[] args)
        {
            string characterName = args[0];
            Character character = GetCharacter(characterName);

            if (itemPool.Count == 0)
            {
                throw new InvalidOperationException
                   (ExceptionMessages.ItemPoolEmpty);
            }

            Item lastItem = itemPool.Last();
            itemPool.Remove(lastItem);
            character.Bag.AddItem(lastItem);

            return string.Format(SuccessMessages.PickUpItem,
                characterName, lastItem.GetType().Name);
        }

        public string UseItem(string[] args)
        {
            string characterName = args[0];
            string itemName = args[1];

            Character character = GetCharacter(characterName);
            Item item = character.Bag.GetItem(itemName);

            character.UseItem(item);
            return string.Format(SuccessMessages.UsedItem,
                characterName, itemName);
        }

        public string GetStats()
        {
            var sortedCharacters = characterParty
                 .OrderByDescending(ch => ch.IsAlive)
                 .ThenByDescending(ch => ch.Health)
                 .ToList();

            StringBuilder sb = new StringBuilder();
            foreach (var character in sortedCharacters)
            {
                string status = "";
                if (character.IsAlive)
                {
                    status = "Alive";
                }
                else
                {
                    status = "Dead";
                }
                sb.AppendLine(string.Format(SuccessMessages
                    .CharacterStats, character.Name,
                    character.Health, character.BaseHealth,
                    character.Armor, character.BaseArmor,
                    status));
            }
            return sb.ToString().TrimEnd();
        }

        public string Attack(string[] args)
        {
            string attackerName = args[0];
            string receiverName = args[1];
            Character attacker = GetCharacter(attackerName);
            Character receiver = GetCharacter(receiverName);

            var attackMethod = attacker.GetType().GetMethod("Attack");
            if (attackMethod == null)
            {
                throw new ArgumentException
                    (string.Format(ExceptionMessages.AttackFail,
                    attackerName));
            }

            ((IAttacker)attacker).Attack(receiver);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(
               string.Format(SuccessMessages.AttackCharacter,
               attackerName, receiverName, attacker.AbilityPoints, 
               receiverName, receiver.Health, receiver.BaseHealth, 
               receiver.Armor, receiver.BaseArmor));

            if (!receiver.IsAlive)
            {
                sb.AppendLine(string.Format(
                    SuccessMessages.AttackKillsCharacter, receiverName));
            }
            return sb.ToString().TrimEnd();
        }

        public string Heal(string[] args)
        {
            string healerName = args[0];
            string receiverName = args[1];
            Character healer = GetCharacter(healerName);
            Character receiver = GetCharacter(receiverName);

            var healMethod = healer.GetType().GetMethod("Heal");
            if (healMethod == null)
            {
                throw new ArgumentException
                    (string.Format(ExceptionMessages
                    .HealerCannotHeal, healerName));
            }

            ((IHealer)healer).Heal(receiver);

            return string.Format(SuccessMessages.HealCharacter,
                healerName, receiverName, healer.AbilityPoints,
               receiverName, receiver.Health);
        }

        private Type GetDefaultType(string typeName)
        {
            Assembly asm = Assembly.GetExecutingAssembly();
            Type type = asm.GetTypes()
                .FirstOrDefault(t => t.Name == typeName);
            return type;
        }

        private Character CreateCharacter(Type type, string[] args)
        {
            Character character = null;
            string name = null;
            if (args.Length > 0)
            {
                name = args[0];
            }
            if (type.Name == "Warrior")
            {
                character = new Warrior(name);
            }
            if (type.Name == "Priest")
            {
                character = new Priest(name);
            }
            return character;
        }

        private Item CreateItem(Type type)
        {
            Item item = null;
            if (type.Name == "HealthPotion")
            {
                item = new HealthPotion();
            }
            if (type.Name == "FirePotion")
            {
                item = new FirePotion();
            }
            return item;
        }

        private Character GetCharacter(string characterName)
        {
            Character character = characterParty
                .FirstOrDefault(ch=>ch.Name==characterName);
            if (character==null)
            {
                throw new ArgumentException
                    (String.Format(ExceptionMessages
                    .CharacterNotInParty,characterName));
            }

            return character;
        }
    }
}
