using System;
using System.Linq;
using System.Collections.Generic;

using CounterStrike.Utilities.Messages;
using CounterStrike.Models.Players.Contracts;
using CounterStrike.Repositories.Contracts;

namespace CounterStrike.Repositories
{
    public class PlayerRepository : IRepository<IPlayer>
    {
        private readonly ICollection<IPlayer> players;

        public PlayerRepository()
        {
            players = new List<IPlayer>();
        }

        public IReadOnlyCollection<IPlayer> Models
            => (IReadOnlyCollection<IPlayer>)players;

        public void Add(IPlayer model)
        {
            if (model == null)
            {
                throw new ArgumentException
                    (ExceptionMessages.InvalidPlayerRepository);
            }
            players.Add(model);
        }

        public IPlayer FindByName(string name)
        {
            return players.FirstOrDefault(x => x.Username == name);
        }

        public bool Remove(IPlayer model)
        {
            return players.Remove(model);
        }
    }
}
