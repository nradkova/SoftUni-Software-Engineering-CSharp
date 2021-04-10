using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Models.Aquariums
{
    public abstract class Aquarium : IAquarium
    {
        private string name;

        private readonly ICollection<IDecoration> decorations;
        private readonly ICollection<IFish> fish;

        protected Aquarium(string name, int capacity)
        {
            Name = name;
            decorations = new List<IDecoration>();
            fish = new List<IFish>();
            Capacity = capacity;
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException
                        (ExceptionMessages.InvalidAquariumName);
                }
                name = value;
            }
        }

        public int Capacity { get; private set; }

        public int Comfort => decorations.Sum(x => x.Comfort);

        public ICollection<IDecoration> Decorations
           => decorations;
        public ICollection<IFish> Fish
            => fish;

        public void AddDecoration(IDecoration decoration)
        {
            decorations.Add(decoration);
        }

        public void AddFish(IFish fish)
        {
            if (this.fish.Count >= Capacity)
            {
                throw new InvalidOperationException
                    (ExceptionMessages.NotEnoughCapacity);
            }
            this.fish.Add(fish);
        }

        public void Feed()
        {
            foreach (var item in fish)
            {
                item.Eat();
            }
        }

        public string GetInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{name} ({GetType().Name}):");
            if (fish.Count == 0)
            {
                sb.AppendLine("Fish: none");
            }
            else
            {
                var names = new List<string>();
                foreach (var item in fish)
                {
                    names.Add(item.Name);
                }
                sb.AppendLine($"Fish: {string.Join(", ", names)}");
            }
            sb.AppendLine($"Decorations: { decorations.Count}");
            sb.AppendLine($"Comfort: { Comfort}");

            return sb.ToString().TrimEnd();
        }

        public bool RemoveFish(IFish fish)
        {
            return this.fish.Remove(fish);
        }
    }
}
