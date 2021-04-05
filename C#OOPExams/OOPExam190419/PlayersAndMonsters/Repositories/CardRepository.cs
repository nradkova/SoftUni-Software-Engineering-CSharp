using System;
using System.Linq;
using System.Collections.Generic;

using PlayersAndMonsters.Models.Cards.Contracts;
using PlayersAndMonsters.Repositories.Contracts;

namespace PlayersAndMonsters.Repositories
{
    public class CardRepository : ICardRepository
    {
        private readonly ICollection<ICard> cards;

        public CardRepository()
        {
            cards = new List<ICard>();
        }

        public int Count => cards.Count;

        public IReadOnlyCollection<ICard> Cards
            => (IReadOnlyCollection<ICard>)cards;

        public void Add(ICard card)
        {
            if (card == null)
            {
                throw new ArgumentException
                    ("Card cannot be null!");
            }
            if (cards.Any(x => x.Name == card.Name))
            {
                throw new ArgumentException
                    ($"Card {card.Name} already exists!");
            }
            cards.Add(card);
        }

        public ICard Find(string name)
        {
            return cards.FirstOrDefault(x => x.Name == name);
        }

        public bool Remove(ICard card)
        {
            if (!cards.Any(x => x.Name == card.Name))
            {
                throw new ArgumentException
                     ("Card cannot be null!");
            }
            return cards.Remove(card);
        }
    }
}
