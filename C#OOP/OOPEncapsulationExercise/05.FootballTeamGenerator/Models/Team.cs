using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using _05.FootballTeam.Common;

namespace _05.FootballTeam.Models
{
   public class Team
    {
        private string name;
        private readonly IList<Player> players;

        private Team()
        {
            players = new List<Player>();
        }

        public Team(string name)
            :this()
        {
            Name = name;
        }

        public string  Name 
        {
            get { return name; }
            private set { name = value; } 
        }
        public int Rating
        {
            get
            {
                if (players.Count>0)
                {
                return(int)Math.Round(players.Average(p => p.Stats));
                }
                else
                {
                    return 0;
                }
            }
        }
        public void AddPlayer(Player player)
        {
            if (!players.Contains(player))
            {
                players.Add(player);
            }
        }
        public void RemovePlayer(string name)
        {
            Player player = players.FirstOrDefault(p => p.Name == name);
            if (!players.Contains(player))
            {
                throw new ArgumentException
                    (string.Format(GlobalConstants.INVALID_PLAYER_EXC_MSG, name,Name));
            }
            players.Remove(player);
        }
    }
}
