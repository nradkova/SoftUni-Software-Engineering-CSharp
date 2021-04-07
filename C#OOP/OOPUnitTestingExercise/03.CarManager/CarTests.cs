using CarManager;
using NUnit.Framework;
using System;

namespace Tests
{
    public class CarTests
    {
        [SetUp]
        public void Setup()
        {
            //Car car = new Car(make, model, fuelConsumption, fuelCapacity);
        }

        [Test]
        public void ConstructorShouldWorkCorrectly()
        {
            Car car = new Car("AAA", "bbb", 5.00, 50.00);
            Assert.AreEqual(car.Make, "AAA");
            Assert.AreEqual(car.Model, "bbb");
            Assert.AreEqual(car.FuelConsumption, 5);
            Assert.AreEqual(car.FuelCapacity, 50);
            Assert.AreEqual(car.FuelAmount, 0);
        }
        
        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void ValidationOfMakeShoulddWorkCorrectly(string make)
        {
            Assert.Throws<ArgumentException>(() 
                => new Car(make, "bbb", 5.00, 50.00));
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void ValidationOfModelShoulddWorkCorrectly(string model)
        {
            Assert.Throws<ArgumentException>(()
                => new Car("AAA", model, 5.00, 50.00));
        }
       
        [Test]
        [TestCase(0)]
        [TestCase(-10)]
        public void ValidationOfFuelConsumptionShoulddWorkCorrectly
            (double fuelConsumption)
        {
            Assert.Throws<ArgumentException>(()
                => new Car("AAA", "bbb", fuelConsumption, 50.00));
        }
        
        [Test]
        [TestCase(0)]
        [TestCase(-10)]
        public void ValidationOfFuelCapacityShoulddWorkCorrectly
           (double fuelCapacity)
        {
            Assert.Throws<ArgumentException>(()
                => new Car("AAA", "bbb", 5.00, fuelCapacity));
        }
        
        [Test]
        [TestCase(0)]
        [TestCase(-10)]
        public void ValidationInRefuellingAmountShoulddWorkCorrectly
          (double fuel)
        {
            Car car = new Car("AAA", "bbb", 5.00, 50.00);
            Assert.Throws<ArgumentException>(()
                => car.Refuel(fuel));
        }
       
        [Test]
        [TestCase(20,20)]
        [TestCase(100, 50)]
        public void RefuellingShoulddWorkCorrectly
         (double fuel,double expectedFuel)
        {
            Car car = new Car("AAA", "bbb", 5.00, 50.00);
            car.Refuel(fuel);
            Assert.AreEqual(car.FuelAmount, expectedFuel);
        }

        [Test]
        [TestCase(5,200)]
        public void ValidationInDrivingDistanceShoulddWorkCorrectly
          (double fuel,double distance)
        {
            Car car = new Car("AAA", "bbb", 5.00, 50.00);
            car.Refuel(fuel);
            Assert.Throws<InvalidOperationException>(()
                => car.Drive(distance));
        }

        [Test]
        [TestCase(20, 200,10)]
        public void DrivingDistanceShoulddWorkCorrectly
         (double fuel, double distance,double expectedFuel)
        {
            Car car = new Car("AAA", "bbb", 5.00, 50.00);
            car.Refuel(fuel);
            car.Drive(distance);
            Assert.AreEqual(car.FuelAmount,expectedFuel);
        }
    }
}