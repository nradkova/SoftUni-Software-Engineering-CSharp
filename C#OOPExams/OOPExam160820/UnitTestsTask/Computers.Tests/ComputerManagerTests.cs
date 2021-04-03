using NUnit.Framework;
using System;

namespace Computers.Tests
{
    public class Tests
    {
        private Computer first;
        private Computer second;
        private Computer third;
        private ComputerManager manager;

        [SetUp]
        public void Setup()
        {
            first = new Computer("AAA", "A", 100);
            second = new Computer("BBB", "B", 200);
            third = new Computer("AAA", "C", 100);
            manager = new ComputerManager();
        }

        [Test]
        public void Initializing_WorksCorrectly()
        {
            manager = new ComputerManager();

            Assert.IsNotNull(manager.Computers);
            Assert.AreEqual(manager.Count, 0);
        }
       
        [Test]
        public void AddingComputer_WorksCorrectly()
        {
            manager.AddComputer(first);
            manager.AddComputer(second);

            CollectionAssert.Contains(manager.Computers, first);
            Assert.AreEqual(manager.Count, 2);
        }

        [Test]
        public void AddingSameComputer_Throws()
        {
            manager.AddComputer(first);

            Assert.Throws<ArgumentException>(()
                => manager.AddComputer(first));
        }

        [Test]
        public void AddingNullComputer_Throws()
        {
            Computer computer = null;

            Assert.Throws<ArgumentNullException>(()
                => manager.AddComputer(computer));
        }

        [Test]
        public void GettingComputerByNullManufacturer_Throws()
        {
            manager.AddComputer(first);

            Assert.Throws<ArgumentNullException>(()
                => manager.GetComputer(null,"A"));
        }

        [Test]
        public void GettingComputerByNullModel_Throws()
        {
            manager.AddComputer(first);

            Assert.Throws<ArgumentNullException>(()
                => manager.GetComputer("AAA",null));
        }

        [Test]
        public void GettingNonExistingComputer_Throws()
        {
            manager.AddComputer(first);

            Assert.Throws<ArgumentException>(()
                => manager.GetComputer("AAA", "B"));
        }

        [Test]
        public void GettingExistingComputer_WorksCorrectly()
        {
            manager.AddComputer(first);
            Computer computer 
                = manager.GetComputer(first.Manufacturer, first.Model);

            Assert.AreEqual(first.Manufacturer, computer.Manufacturer);
            Assert.AreEqual(first.Model, computer.Model);
        }
      
        [Test]
        public void RemovingExistingComputer_WorksCorrectly()
        {
            manager.AddComputer(first);
            Computer computer 
                = manager.RemoveComputer(first.Manufacturer, first.Model);

            Assert.AreEqual(first.Manufacturer, computer.Manufacturer);
            Assert.AreEqual(first.Model, computer.Model);
            Assert.AreEqual(manager.Count, 0);
        }

        [Test]
        public void RemovingNonExistingComputer_Throws()
        {
            manager.AddComputer(first);

            Assert.Throws<ArgumentException>(()
                => manager.RemoveComputer("AAA", "B"));
        }

        [Test]
        public void SelectingComputersByManufacturer_WorksCorrectly()
        {
            manager.AddComputer(first);
            manager.AddComputer(second);
            manager.AddComputer(third);
            var selected = manager
                .GetComputersByManufacturer(first.Manufacturer);

            Assert.AreEqual(selected.Count, 2);
            CollectionAssert.Contains(selected, first);
        }
    }
}