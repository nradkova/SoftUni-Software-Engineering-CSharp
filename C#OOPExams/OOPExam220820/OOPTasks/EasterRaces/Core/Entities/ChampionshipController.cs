using System;
using System.Text;
using System.Linq;

using EasterRaces.Models.Races;
using EasterRaces.Core.Contracts;
using EasterRaces.Utilities.Messages;
using EasterRaces.Models.Cars.Entities;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Repositories.Entities;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Models.Drivers.Entities;
using EasterRaces.Models.Drivers.Contracts;

namespace EasterRaces.Core.Entities
{
    public class ChampionshipController : IChampionshipController
    {
        private readonly CarRepository carRepository;
        private readonly DriverRepository driverRepository;
        private readonly RaceRepository raceRepository;
        public ChampionshipController()
        {
            carRepository = new CarRepository();
            driverRepository = new DriverRepository();
            raceRepository = new RaceRepository();
        }
        public string AddCarToDriver(string driverName, string carModel)
        {
            IDriver driver = driverRepository.GetByName(driverName);
            if (driver == null)
            {
                throw new InvalidOperationException
                    (String.Format(ExceptionMessages.
                    DriverNotFound, driverName));
            }
            ICar car = carRepository.GetByName(carModel);
            if (car == null)
            {
                throw new InvalidOperationException
                    (String.Format(ExceptionMessages.
                    CarNotFound, carModel));
            }
            driver.AddCar(car);
            return string.Format(OutputMessages.CarAdded,
                driverName, carModel);
        }

        public string AddDriverToRace(string raceName, string driverName)
        {
            IRace race = raceRepository.GetByName(raceName);
            if (race == null)
            {
                throw new InvalidOperationException
                    (String.Format(ExceptionMessages.
                    RaceNotFound, raceName));
            }
            IDriver driver = driverRepository.GetByName(driverName);
            if (driver == null)
            {
                throw new InvalidOperationException
                    (String.Format(ExceptionMessages.
                    DriverNotFound, driverName));
            }
            race.AddDriver(driver);
            return string.Format
                (OutputMessages.DriverAdded, driverName, raceName);
        }

        public string CreateCar(string type, string model, int horsePower)
        {
            ICar car = null;
            if (type == "Muscle")
            {
                car = new MuscleCar(model, horsePower);
            }
            if (type == "Sports")
            {
                car = new SportsCar(model, horsePower);
            }
            if (carRepository.GetByName(model) != null)
            {
                throw new ArgumentException(String.Format
                    (ExceptionMessages.CarExists, model));
            }
            if (car == null)
            {
                return null;
            }
            carRepository.Add(car);
            return string.Format
                (OutputMessages.CarCreated, car.GetType().Name, model);
        }

        public string CreateDriver(string driverName)
        {
            IDriver driver = new Driver(driverName);
            if (driverRepository.GetByName(driverName) != null)
            {
                throw new ArgumentException(String.Format
                    (ExceptionMessages.DriversExists, driverName));
            }
            if (driver == null)
            {
                return null;
            }
            driverRepository.Add(driver);
            return string.Format
                (OutputMessages.DriverCreated, driverName);
        }

        public string CreateRace(string name, int laps)
        {
            IRace race = new Race(name, laps);
            if (raceRepository.GetByName(name) != null)
            {
                throw new InvalidOperationException(String.Format
                    (ExceptionMessages.RaceExists, name));
            }
            if (race == null)
            {
                return null;
            }
            raceRepository.Add(race);
            return string.Format
                (OutputMessages.RaceCreated, name);
        }

        public string StartRace(string raceName)
        {
            IRace race = raceRepository.GetByName(raceName);
            if (race==null)
            {
                throw new InvalidOperationException
                    (string.Format(ExceptionMessages
                    .RaceNotFound, raceName));
            }
            if (race.Drivers.Count<3)
            {
                throw new InvalidOperationException
                    (string.Format(ExceptionMessages
                    .RaceInvalid, raceName,3));
            }

            var orderedDrivers = race.Drivers
                .OrderByDescending(x => x.Car
                .CalculateRacePoints(race.Laps)).ToList();

            raceRepository.Remove(race);

            StringBuilder sb = new StringBuilder();
                    sb.AppendLine
                        (string.Format(OutputMessages
                        .DriverFirstPosition, 
                        orderedDrivers[0].Name, raceName));
                    sb.AppendLine
                        (string.Format(OutputMessages
                        .DriverSecondPosition, 
                        orderedDrivers[1].Name, raceName));
                    sb.AppendLine
                        (string.Format(OutputMessages
                        .DriverThirdPosition,
                        orderedDrivers[2].Name, raceName));
           
            return sb.ToString().TrimEnd();
        }
    }
}
