using System;
using System.Linq;
using System.Collections.Generic;

using PlayersAndMonsters.Repositories.Contracts;
using PlayersAndMonsters.Models.Players.Contracts;

namespace PlayersAndMonsters.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly ICollection<IPlayer> players;

        public PlayerRepository()
        {
            players = new List<IPlayer>();
        }

        public int Count => players.Count;

        public IReadOnlyCollection<IPlayer> Players
            => (IReadOnlyCollection<IPlayer>)players;

        public void Add(IPlayer player)
        {
            if (player==null)
            {
                throw new ArgumentException
                    ("Player cannot be null");
            }
            if (players.Any(x=>x.Username==player.Username))
            {
                throw new ArgumentException
                    ($"Player {player.Username} already exists!");
            }
            players.Add(player);
        }

        public IPlayer Find(string username)
        {
            return players.FirstOrDefault(x => x.Username == username);
        }

        public bool Remove(IPlayer player)
        {
            if (!players.Any(x => x.Username == player.Username))
            {
                throw new ArgumentException
                     ("Player cannot be null");
            }
            return players.Remove(player);
        }
    }
}
