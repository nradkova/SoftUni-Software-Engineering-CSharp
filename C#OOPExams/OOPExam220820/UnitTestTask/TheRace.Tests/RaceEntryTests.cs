using NUnit.Framework;
using System;
//using TheRace;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {
        private UnitCar car;
        private UnitDriver firstDriver;
        private UnitDriver secondDriver;
        private RaceEntry race;

        [SetUp]
        public void Setup()
        {
            car = new UnitCar("XXX", 200, 200);
            firstDriver = new UnitDriver("AAA", car);
            secondDriver = new UnitDriver("BBB", car);
            race = new RaceEntry();
        }

        [Test]
        public void SetDriversList_WhenInitialized()
        {
            Assert.AreEqual(race.Counter, 0);
        }

        [Test]
        public void AddingNonExistingDriver_ThrowsException()
        {
            Assert.Throws<InvalidOperationException>(()
                => race.AddDriver(null));
        }

        [Test]
        public void AddingSameDriverTwice_ThrowsException()
        {
            race.AddDriver(firstDriver);
            Assert.Throws<InvalidOperationException>(()
                => race.AddDriver(firstDriver),
                $"Driver {firstDriver.Name} is already added.");
        }

        [Test]
        public void AddingDriver_WorksProperly()
        {
            string result = race.AddDriver(firstDriver);
            string expectedResult = $"Driver {firstDriver.Name} added in race.";
            Assert.AreEqual(expectedResult, result);
            Assert.AreEqual(race.Counter, 1);
        }
      
        [Test]
        public void CalculatingHorsePowerForLessDrivers_ThrowsException()
        {
            race.AddDriver(firstDriver);
            Assert.Throws<InvalidOperationException>(()
                => race.CalculateAverageHorsePower());
        }

        [Test]
        public void CalculatingAverageHorsePower_WorksProperly()
        {
            race.AddDriver(firstDriver);
            race.AddDriver(secondDriver);
            Assert.AreEqual(race.CalculateAverageHorsePower(), 200);
        }
    }
}