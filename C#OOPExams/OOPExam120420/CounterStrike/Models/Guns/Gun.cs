using CounterStrike.Models.Guns.Contracts;
using CounterStrike.Utilities.Messages;
using System;

namespace CounterStrike.Models.Guns
{
    public abstract class Gun : IGun
    {
        private string name;
        private int bulletsCount;

        protected Gun(string name, int bulletsCount)
        {
            Name = name;
            BulletsCount = bulletsCount;
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException
                        (ExceptionMessages.InvalidGunName);
                }
                name = value;
            }
        }

        public int BulletsCount
        {
            get => bulletsCount;
            protected set
            {
                if (value<0)
                {
                    throw new ArgumentException
                        (ExceptionMessages.InvalidGunBulletsCount);
                }
                bulletsCount=value;
            }
        }

        public abstract int Fire();
    }
}
