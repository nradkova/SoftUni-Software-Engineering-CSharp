using System;
using System.Collections.Generic;

using EasterRaces.Utilities.Messages;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Models.Drivers.Contracts;

namespace EasterRaces.Models.Races
{
    public class Race : IRace
    {
        private const int MinNameLenght = 5;
        private const int MinLapsCount = 1;


        private string name;
        private int laps;
        private readonly ICollection<IDriver> drivers;
        public Race(string name, int laps)
        {
            Name = name;
            Laps= laps;
            drivers = new List<IDriver>();
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
                        value, MinNameLenght));
                }
                name = value;
            }
        }
        public int Laps
        {
            get => laps;
            private set
            {
                if (value< MinLapsCount)
                {
                    throw new ArgumentException(String.Format
                        (ExceptionMessages.InvalidNumberOfLaps,
                        value, MinLapsCount));
                }
                laps = value;
            }
        }

        public IReadOnlyCollection<IDriver> Drivers =>
            (IReadOnlyCollection<IDriver>)drivers;

        public void AddDriver(IDriver driver)
        {
            if (driver==null)
            {
                throw new ArgumentNullException
                    (ExceptionMessages.DriverInvalid);
            }
            if (driver.CanParticipate==false)
            {
                throw new ArgumentException(String.Format 
                   (ExceptionMessages.DriverNotParticipate,driver.Name));
            }
            if (drivers.Contains(driver))
            {
                throw new ArgumentNullException(String.Format
                   (ExceptionMessages.DriverAlreadyAdded,
                   driver.Name,Name));
            }
            drivers.Add(driver);
        }
    }
}
