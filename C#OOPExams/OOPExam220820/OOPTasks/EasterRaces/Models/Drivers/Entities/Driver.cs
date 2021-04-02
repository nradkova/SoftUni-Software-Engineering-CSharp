using System;

using EasterRaces.Utilities.Messages;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Drivers.Contracts;


namespace EasterRaces.Models.Drivers.Entities
{
    public  class Driver : IDriver
    {
        private const int MinNameLenght= 5;

        private string name;
        private ICar car;
        public Driver(string name)
        {
            Name = name;
        }

        public string Name
        {
            get => name;
            private set
            {
                if (String.IsNullOrWhiteSpace(value)
                    || value.Length < MinNameLenght)
                {
                    throw new ArgumentException(String.Format
                        (ExceptionMessages.InvalidName,
                        value,MinNameLenght));
                }
                name = value;
            }
        }

        public ICar Car => car;

        public int NumberOfWins { get; private set; }

        public bool CanParticipate { get; private set; } = false;

        public void AddCar(ICar car)
        {
            if (car==null)
            {
                throw new ArgumentNullException
                    (ExceptionMessages.CarInvalid);
            }
            this.car = car;
            CanParticipate = true;
        }

        public void WinRace()
        {
            NumberOfWins++;
        }
    }
}
