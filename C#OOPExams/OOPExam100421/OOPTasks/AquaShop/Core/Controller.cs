using AquaShop.Core.Contracts;
using AquaShop.Models.Aquariums;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Repositories;
using AquaShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Core
{
    public  class Controller:IController
    {
        private DecorationRepository decorations;
        private readonly ICollection<IAquarium> aquariums;

        public Controller()
        {
            decorations = new DecorationRepository();
            aquariums = new List<IAquarium>();
        }

        public string AddAquarium(string aquariumType, 
            string aquariumName)
        {
            IAquarium aquarium = null;
            if (aquariumType== "FreshwaterAquarium")
            {
                aquarium = new FreshwaterAquarium(aquariumName);
            }
            else if (aquariumType == "SaltwaterAquarium")
            {
                aquarium = new SaltwaterAquarium(aquariumName);
            }
            else
            {
                throw new InvalidOperationException
                    (ExceptionMessages.InvalidAquariumType);
            }

            aquariums.Add(aquarium);

            return string.Format(OutputMessages
                .SuccessfullyAdded, aquariumType);
        }

        public string AddDecoration(string decorationType)
        {
            IDecoration decoration = null;
            if (decorationType == "Ornament")
            {
                decoration = new Ornament();
            }
            else if (decorationType == "Plant")
            {
                decoration = new Plant();
            }
            else
            {
                throw new InvalidOperationException
                    (ExceptionMessages.InvalidDecorationType);
            }

            decorations.Add(decoration);

            return string.Format(OutputMessages
                .SuccessfullyAdded, decorationType);
        }

        public string InsertDecoration(string aquariumName, 
            string decorationType)
        {
            IDecoration decoration 
                = decorations.FindByType(decorationType);

            if (decoration==null)
            {
                throw new InvalidOperationException
                    (string.Format( ExceptionMessages
                    .InexistentDecoration, decorationType));
            }

            IAquarium aquarium = GetAquariumByName(aquariumName);
            //null
            aquarium.AddDecoration(decoration);
            decorations.Remove(decoration);

            return string.Format(OutputMessages
                .EntityAddedToAquarium, decorationType, aquariumName);
        }

        public string AddFish(string aquariumName, 
            string fishType, string fishName,
            string fishSpecies, decimal price)
        {

            IFish fish = null;
            if (fishType== "FreshwaterFish")
            {
                fish = new FreshwaterFish(fishName, fishSpecies, price);
            }
            else if (fishType == "SaltwaterFish")
            {
                fish = new SaltwaterFish(fishName, fishSpecies, price);
            }
            else
            {
                throw new InvalidOperationException
                    (ExceptionMessages.InvalidFishType);
            }

            IAquarium aquarium = GetAquariumByName(aquariumName);

            if(((fish is FreshwaterFish)&& (aquarium is FreshwaterAquarium))
                || ((fish is SaltwaterFish) && (aquarium is SaltwaterAquarium)))
            {
                aquarium.AddFish(fish);
                return string.Format(OutputMessages
                    .EntityAddedToAquarium, fishType, aquariumName);
            }

            return OutputMessages.UnsuitableWater;
        }

        public string FeedFish(string aquariumName)
        {
            IAquarium aquarium = GetAquariumByName(aquariumName);
            aquarium.Feed();

            return string.Format(OutputMessages
                .FishFed, aquarium.Fish.Count);
        }

        public string CalculateValue(string aquariumName)
        {
            IAquarium aquarium = GetAquariumByName(aquariumName);

            decimal price =
                aquarium.Fish.Sum(x => x.Price)
                + aquarium.Decorations.Sum(x => x.Price);

            return $"The value of Aquarium {aquariumName} is {price:f2}.";
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var aquarium in aquariums)
            {
                sb.AppendLine(aquarium.GetInfo());
            }

            return sb.ToString().TrimEnd();
        }

        private IAquarium GetAquariumByName(string aquariumName)
        {
            return aquariums
                .FirstOrDefault(x => x.Name == aquariumName);
        }
    }
}
