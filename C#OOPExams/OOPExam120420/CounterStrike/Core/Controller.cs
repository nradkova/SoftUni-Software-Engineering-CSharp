using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

using CounterStrike.Models.Guns;
using CounterStrike.Models.Maps;
using CounterStrike.Repositories;
using CounterStrike.Core.Contracts;
using CounterStrike.Models.Players;
using CounterStrike.Utilities.Messages;
using CounterStrike.Models.Guns.Contracts;
using CounterStrike.Models.Maps.Contracts;
using CounterStrike.Repositories.Contracts;
using CounterStrike.Models.Players.Contracts;

namespace CounterStrike.Core
{
    public class Controller : IController
    {
        private readonly IRepository<IGun> guns;
        private readonly IRepository<IPlayer> players;
        private readonly IMap map;

        public Controller()
        {
            guns = new GunRepository();
            players = new PlayerRepository();
            map = new Map();
        }

        public string AddGun(string type, string name, int bulletsCount)
        {
            IGun gun = null;
            if (type == nameof(Pistol))
            {
                gun = new Pistol(name, bulletsCount);
            }
            else if (type == nameof(Rifle))
            {
                gun = new Rifle(name, bulletsCount);
            }
            else
            {
                throw new ArgumentException
                    (ExceptionMessages.InvalidGunType);
            }
            guns.Add(gun);

            return string.Format(OutputMessages
                .SuccessfullyAddedGun, name);
        }

        public string AddPlayer(string type, string username,
            int health, int armor, string gunName)
        {
            IGun gun = guns.FindByName(gunName);
            if(gun==null)
            {
                throw new ArgumentException
                    (ExceptionMessages.GunCannotBeFound);
            }

            IPlayer player = null;
            if (type == nameof(Terrorist))
            {
                player 
                    = new Terrorist(username, health,armor,gun);
            }
            else if (type == nameof(CounterTerrorist))
            {
                player 
                    = new CounterTerrorist(username, health, armor, gun);
            }
            else
            {
                throw new ArgumentException
                    (ExceptionMessages.InvalidPlayerType);
            }
            players.Add(player);

            return string.Format(OutputMessages
                .SuccessfullyAddedPlayer, username);
        }

        public string Report()
        {
            var sorted
                = (ICollection<IPlayer>)players.Models
                .OrderBy(x => x.GetType().Name)
                .ThenByDescending(x=>x.Health)
                .ThenBy(x=>x.Username).ToList();

            StringBuilder sb = new StringBuilder();
            foreach (var player in sorted)
            {
                sb.AppendLine(player.ToString());
            }
            return sb.ToString().TrimEnd();
        }

        public string StartGame()
        {
            //SHOULD BE:
            //var allAlivePlayers
            //    = players.Models.
            //    Where(x => x.IsAlive == true).ToList();
            //return map.Start(allAlivePlayers);

            return map.Start(players.Models.ToList());
        }
    }
}
