using System.Linq;
using System.Collections.Generic;

using CounterStrike.Models.Players;
using CounterStrike.Models.Maps.Contracts;
using CounterStrike.Models.Players.Contracts;

namespace CounterStrike.Models.Maps
{
    public class Map : IMap
    {
        private readonly ICollection<IPlayer> terrorists;
        private readonly ICollection<IPlayer> counterTerrorists;
       
        public Map()
        {
            terrorists = new List<IPlayer>();
            counterTerrorists = new List<IPlayer>();
        }

        public string Start(ICollection<IPlayer> players)
        {
            foreach (var player in players)
            {
                if (player is Terrorist)
                {
                    terrorists.Add(player);
                }
                if (player is CounterTerrorist)
                {
                    counterTerrorists.Add(player);
                }
            }

            while (true)
            {
                //SHOULD BE:
                //Attack(terrorists,counterTerrorists);

                //if (counterTerrorists.All(x=>x.IsAlive==false))
                //{
                //    return "Terrorist wins!";
                //}

                //Attack(counterTerrorists, terrorists);

                //if (terrorists.All(x => x.IsAlive == false))
                //{
                //    return "Counter Terrorist wins!";
                //}

                Attack(terrorists, counterTerrorists);
                Attack(counterTerrorists, terrorists);

                if (counterTerrorists.All(x => x.IsAlive == false))
                {
                    return "Terrorist wins!";
                }
                if (terrorists.All(x => x.IsAlive == false))
                {
                    return "Counter Terrorist wins!";
                }
            }
        }

        private void Attack(ICollection<IPlayer> attackers,
            ICollection<IPlayer> defenders)
        {
            foreach (var attacker in attackers)
            {
                //SHOULD BE:
                //if (!attacker.IsAlive)
                //{
                //    continue;
                //}
                foreach (var defender in defenders)
                {
                    if (defender.IsAlive)
                    {
                    defender.TakeDamage(attacker.Gun.Fire());
                    }
                }
            }
        }

    }
}
