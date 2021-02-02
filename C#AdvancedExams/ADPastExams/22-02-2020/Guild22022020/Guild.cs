using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Guild
{
    public class Guild
    {
        private List<Player> players;
        public Guild(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            players = new List<Player>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count { get { return players.Count; } }

        public void AddPlayer(Player player)
        {
            if (players.Count < Capacity)
            {
                players.Add(player);
            }
        }
        public bool RemovePlayer(string name)
        {
            Player playerToRemove = players.FirstOrDefault
                (x => x.Name == name);
            if (playerToRemove != null)
            {
                players.Remove(playerToRemove);
                return true;
            }
            return false;
        }
        public void PromotePlayer(string name)
        {
            Player playerToPromote = players.FirstOrDefault
                (x => x.Name == name);
            if (playerToPromote.Rank != "Member")
            {
                playerToPromote.Rank = "Member";
            }
        }
        public void DemotePlayer(string name)
        {
            Player playerToPromote = players.FirstOrDefault
                (x => x.Name == name);
            if (playerToPromote.Rank != "Trial")
            {
                playerToPromote.Rank = "Trial";
            }
        }
        public Player[] KickPlayersByClass(string className)
        {
            Player[] kickedPlayers = players.Where
                (x => x.Class == className).ToArray();
            players = players.Where
                (x => x.Class != className).ToList();
            return kickedPlayers;
        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Players in the guild: {Name}");
            foreach (var player in players)
            {
                sb.AppendLine(player.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
