using System;
using System.Linq;
using System.Collections.Generic;

using WarCroft.Entities.Items;

namespace WarCroft.Entities.Inventory
{
    public abstract class Bag : IBag
    {
        private const int DefaultCapacity = 100;
        private ICollection<Item> items;

        protected Bag(int capacity)
        {
            Capacity = capacity;
            items = new List<Item>();
        }

        public int Capacity { get; set; } = DefaultCapacity;
      
        public int Load => items.Sum(x => x.Weight);

        public IReadOnlyCollection<Item> Items
            => (IReadOnlyCollection<Item>)items;

        public void AddItem(Item item)
        {
            if (Load + item.Weight > Capacity)
            {
                throw new InvalidOperationException
                    (Constants.ExceptionMessages
                    .ExceedMaximumBagCapacity);
            }
            items.Add(item);
        }

        public Item GetItem(string name)
        {
            if (items.Count == 0)
            {
                throw new InvalidOperationException
                    (Constants.ExceptionMessages.EmptyBag);
            }

            Item item = items
                .FirstOrDefault(x => x.GetType().Name == name);
            if (item == null)
            {
                throw new ArgumentException
                    (String.Format(Constants.ExceptionMessages
                    .ItemNotFoundInBag, name));
            }
            items.Remove(item);
            return item;
        }
    }
}
