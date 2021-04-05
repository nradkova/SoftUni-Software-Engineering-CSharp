using System;

using PlayersAndMonsters.Repositories.Contracts;
using PlayersAndMonsters.Models.Players.Contracts;


namespace PlayersAndMonsters.Models.Players
{
    public abstract class Player : IPlayer
    {
        private string username;
        private int health;

        protected Player(ICardRepository cardRepository,
            string username, int health)
        {
            Username = username;
            Health = health;
            CardRepository = cardRepository;
        }

        public ICardRepository CardRepository { get; private set; }

        public string Username
        {
            get => username;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException
                    ("Player's username cannot be null or an empty string.");
                }
                username = value;
            }
        }

        public int Health
        {
            get => health;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException
                    ("Player's health bonus cannot be less than zero.");
                }
                health = value;
            }
        }

        public bool IsDead { get; private set; } = false;


        public void TakeDamage(int damagePoints)
        {
            if (damagePoints < 0)
            {
                throw new ArgumentException
                    ("Damage points cannot be less than zero.");
            }

            if (Health <= damagePoints)
            {
                Health = 0;
                IsDead = true;
            }
            else
            {
                Health -= damagePoints;
            }
        }
    }
}
