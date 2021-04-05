using System;
using System.Linq;
using System.Reflection;

using PlayersAndMonsters.Models.Cards.Contracts;
using PlayersAndMonsters.Core.Factories.Contracts;

namespace PlayersAndMonsters.Core.Factories
{
    public class CardFactory : ICardFactory
    {
        public CardFactory()
        {
        }

        public ICard CreateCard(string type, string name)
        {
            Assembly asm = Assembly.GetCallingAssembly();

            Type cardType = asm.GetTypes()
                .FirstOrDefault(t => t.Name.StartsWith(type));

            ICard card = (ICard)Activator
                .CreateInstance(cardType, name);
            
            return card;
        }
    }
}
