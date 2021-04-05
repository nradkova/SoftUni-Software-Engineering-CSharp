using System;
using System.Linq;
using System.Reflection;

using PlayersAndMonsters.Repositories;
using PlayersAndMonsters.Core.Factories.Contracts;
using PlayersAndMonsters.Models.Players.Contracts;

namespace PlayersAndMonsters.Core.Factories
{
    public class PlayerFactory : IPlayerFactory
    {
        public PlayerFactory()
        {
        }

        public IPlayer CreatePlayer(string type, string username)
        {
            Assembly asm = Assembly.GetCallingAssembly();

            Type playerType = asm.GetTypes()
                .FirstOrDefault(t => t.Name == type);

            IPlayer player = (IPlayer)Activator
                .CreateInstance(playerType, new CardRepository(), username);

            return player;
        }
    }
}
