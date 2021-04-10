namespace Aquariums.Tests
{
    using System;
    using System.Collections.Generic;
    using NUnit.Framework;

    public class AquariumsTests
    {
        private Fish first;
        private Fish second;
        private Aquarium aquarium;

        [SetUp]
        public void Setup()
        {
            first = new Fish("AAA");
            second = new Fish("BBB");
            aquarium = new Aquarium("CCC", 10);
        }

        [Test]
        public void Initializing_Works()
        {
            aquarium = new Aquarium("CCC", 10);
            Assert.AreEqual(aquarium.Name, "CCC");
            Assert.AreEqual(aquarium.Capacity, 10);
            Assert.AreEqual(aquarium.Count, 0);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void Initializing_Throws(string name)
        {
            Assert.Throws<ArgumentNullException>(()
                => aquarium = new Aquarium(name, 10));
        }

        [Test]
        [TestCase(-10)]
        public void InitializingNegativeCapacity_Throws(int capacity)
        {
            Assert.Throws<ArgumentException>(()
                => aquarium = new Aquarium("CCC", capacity));
        }
       
        [Test]
        public void Adding_Works()
        {
            aquarium.Add(first);
            aquarium.Add(second);

            Assert.AreEqual(aquarium.Count, 2);
        }

        [Test]
        public void Adding_Throws()
        {
            aquarium = new Aquarium("CCC", 1);
            aquarium.Add(first);
            Assert.Throws<InvalidOperationException>(()
                => aquarium.Add(second));
        }


        [Test]
        public void Removing_Works()
        {
            aquarium.Add(first);
            aquarium.Add(second);
            aquarium.RemoveFish(first.Name);
            Assert.AreEqual(aquarium.Count, 1);
        }

        [Test]
        public void Removing_Throws()
        {
            aquarium.Add(first);
            aquarium.Add(second);
            Assert.Throws<InvalidOperationException>(()
                => aquarium.RemoveFish("XXX"));
        }

        
        [Test]
        public void Selling_Works()
        {
            aquarium.Add(first);
            aquarium.Add(second);
            Fish sold = aquarium.SellFish(first.Name);
            Assert.AreEqual(sold, first);
            Assert.AreEqual(aquarium.Count, 2);
            Assert.IsFalse(first.Available);
        }

        [Test]
        public void Selling_Throws()
        {
            aquarium.Add(first);
            aquarium.Add(second);
            Assert.Throws<InvalidOperationException>(()
                => aquarium.SellFish("XXX"));
        }

        [Test]
        public void Report_Works()
        {
            List<string> fishes = new List<string>();
            fishes.Add(first.Name);
            fishes.Add(second.Name);

            aquarium.Add(first);
            aquarium.Add(second);

           string expected= $"Fish available at {aquarium.Name}: " +
                $"{string.Join(", ", fishes)}";
            string result = aquarium.Report();
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void EmptyAquariumReport_Works()
        {
            List<string> fishes = new List<string>();

            string expected = $"Fish available at {aquarium.Name}: " +
                 $"{string.Join(", ", fishes)}";
            string result = aquarium.Report();
            Assert.AreEqual(expected, result);
        }
    }
}
